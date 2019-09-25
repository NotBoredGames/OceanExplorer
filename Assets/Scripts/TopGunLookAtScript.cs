using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopGunLookAtScript : MonoBehaviour
{

    [SerializeField]
    Camera _2dCanvasCamera;

    [SerializeField]
    Canvas _submarineCanvas;

    [SerializeField]
    GameObject _submarineSprite;

    [SerializeField]
    string _submarineSpriteCenter;

    [SerializeField]
    string _gunPivot;

    [SerializeField]
    GameObject _submarine;

    [SerializeField]
    GameObject[] _gunMeshes = new GameObject[2];
    
    Vector3 startRot;

    float vel = 0;

    // Start is called before the first frame update
    void Start()
    {
        //startRot = _submarine.transform.rotation.eulerAngles;
        startRot = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimpointScreenSpace = Input.mousePosition;
        aimpointScreenSpace.z = _submarineCanvas.transform.position.z - _2dCanvasCamera.transform.position.z;

        Vector3 aimpointWorldSpace = _2dCanvasCamera.ScreenToWorldPoint(aimpointScreenSpace);
        //aimpointWorldSpace = aimpointWorldSpace - _submarineSprite.transform.position;

        Debug.DrawLine(aimpointWorldSpace, Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>().transform.position, Color.cyan);

        float aimpointSubmarineSpaceX = (_submarine.transform.position.x - _2dCanvasCamera.transform.position.x) + aimpointWorldSpace.x;
        float aimpointSubmarineSpaceY = (_submarine.transform.position.y - _2dCanvasCamera.transform.position.y) + aimpointWorldSpace.y;
        float aimpointSubmarineSpaceZ = _gunMeshes[0].transform.position.z;

        Vector3 aimpointSubmarineSpace = new Vector3(aimpointSubmarineSpaceX, aimpointSubmarineSpaceY, aimpointSubmarineSpaceZ);

        Debug.DrawLine(_gunMeshes[0].transform.position, aimpointSubmarineSpace, Color.green);


        /// Not looking at target properly - angle is off slightly
        foreach (GameObject gunMesh in _gunMeshes)
        {
            if (gunMesh.activeSelf)
            {
                Vector3 lookPos = aimpointSubmarineSpace - gunMesh.transform.position;

                gunMesh.transform.forward = aimpointWorldSpace - Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>().transform.position;

                if (gunMesh.transform.localRotation.eulerAngles.z == 270)
                    gunMesh.transform.localRotation = Quaternion.Euler(0, gunMesh.transform.localRotation.eulerAngles.y, 90);

            }
        }

        Debug.DrawRay(_submarine.transform.position, _submarine.transform.forward * 50, Color.yellow);

        if (_submarineSprite.GetComponent<Rigidbody2D>().velocity.x > 1)
        {
            _submarine.transform.localRotation = Quaternion.Euler(startRot.x, startRot.y, Mathf.SmoothDampAngle(_submarine.transform.localRotation.eulerAngles.z, 30 + startRot.z, ref vel, 0.5f));
            //_submarine.transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(_submarine.transform.rotation.eulerAngles.x, -30 + startRot.x, ref vel, 0.5f), startRot.y, startRot.z);
            _submarineSprite.transform.Find(_submarineSpriteCenter).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, _submarine.transform.rotation.eulerAngles.z);
        }
        else if (_submarineSprite.GetComponent<Rigidbody2D>().velocity.x < -1)
        {
            _submarine.transform.localRotation = Quaternion.Euler(startRot.x, startRot.y, Mathf.SmoothDampAngle(_submarine.transform.localRotation.eulerAngles.z, -30 + startRot.z, ref vel, 0.5f));
            //_submarine.transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(_submarine.transform.rotation.eulerAngles.x, 30 + startRot.x, ref vel, 0.5f), startRot.y, startRot.z);
            _submarineSprite.transform.Find(_submarineSpriteCenter).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, _submarine.transform.rotation.eulerAngles.z);
        }
        else
        {
            _submarine.transform.rotation = Quaternion.Euler(startRot.x, startRot.y, Mathf.SmoothDampAngle(_submarine.transform.rotation.eulerAngles.z, startRot.z, ref vel, 0.5f));
            //_submarine.transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(_submarine.transform.rotation.eulerAngles.x, 0 + startRot.x, ref vel, 0.5f), startRot.y, startRot.z);
            _submarineSprite.transform.Find(_submarineSpriteCenter).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, _submarine.transform.rotation.eulerAngles.z);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            //_submarine.transform.rotation = Quaternion.Euler(270, 180, _submarine.transform.rotation.eulerAngles.z);
        }
        else if ((Input.GetAxis("Vertical") < 0))
        {
            //_submarine.transform.rotation = Quaternion.Euler(90, 0, _submarine.transform.rotation.eulerAngles.z);
        }

    }

    public void SetSubmarineSprite(GameObject obj)
    {
        _submarineSprite = obj;
    }
}
