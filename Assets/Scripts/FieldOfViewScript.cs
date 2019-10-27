using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class FieldOfViewScript : MonoBehaviour
{
    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;

    public Vector3 forward;

    [SerializeField]
    [Range(1, 16)]
    int meshResolution = 1;

    [SerializeField]
    [Range(1, 16)]
    int edgeResolveIterations = 4;

    [SerializeField]
    float edgeDistanceThreshold;

    [SerializeField]
    float maskCutawayDistance;

    [SerializeField]
    bool useTurretAim;

    [SerializeField]
    SideGunLookAtScript lookAtScript;

    [SerializeField]
    Transform gunPivot;

    [SerializeField]
    LayerMask targetMask;

    [SerializeField]
    LayerMask obstacleMask;

    [SerializeField]
    int copyLayer = -1;

    [SerializeField]
    Transform copyParent;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    [HideInInspector]
    public List<Transform> circleTargets = new List<Transform>();

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;

    [HideInInspector]
    public Vector3 position;
    RectTransform gunPivotRect;

    List<GameObject> visibleCopies = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;

        gunPivotRect = gunPivot.gameObject.GetComponent<RectTransform>();

        if (useTurretAim && lookAtScript == null)
        {
            Debug.Break();
            Debug.LogError("[[FieldOfViewScript]] useTurretAim set to true but lookAtScript is null!");
        }

        if (copyLayer < 0)
        {
            Debug.Break();
            Debug.LogError("[[FieldOfViewScript]] Set a value for copyLayer (0 to not make copies)");
        }

        //StartCoroutine(FindTargetsWithDelay(0.25f));
    }

    // Update is called once per frame
    void Update()
    {
        if (useTurretAim)
        {
            position = gunPivot.position;
            forward = lookAtScript.GetAimVector().normalized;
        }
        else
            position = this.transform.position;
        
    }

    void LateUpdate()
    {
        FindVisibleSprites();
        DrawFOV();
        CopyVisibleTargets();
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            //FindVisibleTargets();
            FindVisibleSprites();

            //PrintVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        circleTargets.Clear();

        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(position, viewRadius, targetMask);

        foreach(Collider2D col in targetsInViewRadius)
        {
            Transform target = col.transform;
            Vector3 dirToTarget = (target.position - position).normalized;

            circleTargets.Add(target);

            if(Vector3.Angle(forward, dirToTarget) <= viewAngle / 2)
            {
                float dist = Vector3.Distance(position, target.position);

                // How the tutorial handles it, which doesn't account for one sprite tile blocking another
                if (!Physics2D.Raycast(position, dirToTarget, dist, obstacleMask))
                {
                    visibleTargets.Add(target);
                }

            }
        }
    }

    void FindVisibleSprites()
    {
        visibleTargets.Clear();
        circleTargets.Clear();

        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(position, viewRadius, targetMask);

        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngle = viewAngle / stepCount;

        foreach (Collider2D col in targetsInViewRadius)
        {
            Transform target = col.transform;
            float dist = Vector3.Distance(position, target.position);

            //circleTargets.Add(target);

            for (int i = 0; i < stepCount; i++)
            {
                Vector3 dir = Quaternion.Euler(0, 0, -viewAngle / 2) * Quaternion.Euler(0, 0, stepAngle * i) * forward;
                RaycastHit2D hit = Physics2D.Raycast(position, dir, dist, targetMask);

                if (hit && hit.collider.transform == target)
                {
                    if (!visibleTargets.Contains(hit.collider.transform)) {
                        visibleTargets.Add(hit.collider.transform);
                        break;
                    }
                }
            }
        }
    }

    void DrawFOV()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngle = viewAngle / stepCount;

        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();

        for (int i = 0; i <= stepCount; i++)
        {
            Vector3 dir = (Quaternion.Euler(0, 0, -viewAngle / 2) * Quaternion.Euler(0, 0, stepAngle * i) * forward);
            ViewCastInfo newViewCast = ViewCast(dir);

            if (i > 0)
            {
                bool edgeDistThresholdExceeded = Mathf.Abs(oldViewCast.dist - newViewCast.dist) > edgeDistanceThreshold;
                if (oldViewCast.hit != newViewCast.hit || oldViewCast.hit && newViewCast.hit && edgeDistThresholdExceeded)
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);

                    if (edge.pointA != Vector3.zero)
                        viewPoints.Add(edge.pointA);

                    if (edge.pointB != Vector3.zero)
                        viewPoints.Add(edge.pointB);
                }
            }

            viewPoints.Add(newViewCast.point);

            oldViewCast = newViewCast;
        }

        int vertCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertCount];
        int[] triangles = new int[3 * (vertCount - 2)];

        // Set to Vector3.zero because the viewMesh is a child of the sprite obj, and therefore 
        // vertex positions are in LOCAL SPACE!
        vertices[0] = Vector3.zero + gunPivotRect.localPosition;
        //vertices[0] = gunPivot.position;

        for (int i = 0; i < vertCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]) + (forward * maskCutawayDistance);

            if (i < vertCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[(i * 3) + 1] = i + 1;
                triangles[(i * 3) + 2] = i + 2;
            }
        }

        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
        ReverseNormals(viewMesh);
    }

    ViewCastInfo ViewCast(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, direction, viewRadius, targetMask);

        if (hit)
        {
            Vector3 point = new Vector3(hit.point.x, hit.point.y);
            point.z = transform.position.z;
            return new ViewCastInfo(true, point, hit.distance, direction);
        }
        else 
        {
            Vector3 point = position + direction * viewRadius;
            point.z = transform.position.z;
            return new ViewCastInfo(false, point, viewRadius, direction);
        }
    }

    EdgeInfo FindEdge (ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
    {
        Vector3 minDir = minViewCast.dir;
        Vector3 maxDir = maxViewCast.dir;

        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            Vector3 direction = (minDir + maxDir) / 2;
            ViewCastInfo newViewCast = ViewCast(direction);
            bool edgeDistThresholdExceeded = Mathf.Abs(minViewCast.dist - newViewCast.dist) > edgeDistanceThreshold;

            if (newViewCast.hit == minViewCast.hit && !edgeDistThresholdExceeded)
            {
                minDir = direction;
                minPoint = newViewCast.point;
            }
            else
            {
                maxDir = direction;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);
    }

    Vector3 DirFromAngle(float angleInDeg, bool isGlobal)
    {
        if (!isGlobal)
            angleInDeg += transform.eulerAngles.z;

        //return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), Mathf.Cos(angleInDeg * Mathf.Deg2Rad), 0);
    }

    void PrintVisibleTargets()
    {
        string objectsString = "";
        if (visibleTargets.Count > 0)
        {
            foreach (Transform t in visibleTargets)
                objectsString += t.gameObject.name + ", ";
            objectsString = objectsString.Substring(0, objectsString.Length - 2);
        }
        Debug.Log("Time " + Time.realtimeSinceStartup + ": " + objectsString);
    }

    void CopyVisibleTargets()
    {
        if (copyLayer != 0)
        {
            foreach(GameObject obj in visibleCopies)
                Destroy(obj);
            visibleCopies.Clear();

            foreach (Transform transform in visibleTargets)
            {
                if (transform == null)
                    continue;

                GameObject obj = transform.gameObject;
                GameObject copy = Instantiate(obj, copyParent);
                copy.GetComponent<RectTransform>().position = obj.GetComponent<RectTransform>().position;

                copy.name = "Visible Target Copy - " + obj.name;
                copy.layer = copyLayer;

                visibleCopies.Add(copy);

                SpriteRenderer[] spriteRenderers = copy.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sr in spriteRenderers)
                {
                    sr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    sr.sortingOrder = 99;
                }
            }
        }
    }

    struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dist;
        public Vector3 dir;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dist, Vector3 _dir)
        {
            hit = _hit;
            point = _point;
            dist = _dist;
            dir = _dir;
        }
    }

    struct EdgeInfo
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }

    void ReverseNormals(Mesh mesh)
    {
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
            normals[i] = -normals[i];
        mesh.normals = normals;

        int[] triangles = mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int temp = triangles[i + 0];
            triangles[i + 0] = triangles[i + 1];
            triangles[i + 1] = temp;
        }
        mesh.triangles = triangles;
    }

    public Mesh GetViewMesh()
    {
        return viewMesh;
    }
}
