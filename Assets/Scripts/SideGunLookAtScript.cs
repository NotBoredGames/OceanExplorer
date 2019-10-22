using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideGunLookAtScript : MonoBehaviour
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

    Vector3 aimVector;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 aimpointScreenSpace = Input.mousePosition;
        aimpointScreenSpace.z = _submarineCanvas.transform.position.z - _2dCanvasCamera.transform.position.z;

        Vector3 aimpointWorldSpace = _2dCanvasCamera.ScreenToWorldPoint(aimpointScreenSpace);

        Debug.DrawLine(aimpointWorldSpace, Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>().transform.position, Color.cyan);

        // Setting aimVector so it is available from other scripts (ie the turret firing script)
        aimVector = aimpointWorldSpace - Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>().transform.position;

        float aimpointSubmarineSpaceX = (_submarine.transform.position.x - _2dCanvasCamera.transform.position.x) + aimpointWorldSpace.x;
        float aimpointSubmarineSpaceY = (_submarine.transform.position.y - _2dCanvasCamera.transform.position.y) + aimpointWorldSpace.y;
        float aimpointSubmarineSpaceZ = _gunMeshes[0].transform.position.z;

        Vector3 aimpointSubmarineSpace = new Vector3(aimpointSubmarineSpaceX, aimpointSubmarineSpaceY, aimpointSubmarineSpaceZ);

        Debug.DrawLine(_gunMeshes[0].transform.position, aimpointSubmarineSpace, Color.green);


        foreach (GameObject gunMesh in _gunMeshes)
        {
            if (gunMesh.activeSelf)
            {
                Vector3 lookPos = aimpointSubmarineSpace - gunMesh.transform.position;

                Vector3 lookPosTest = aimpointWorldSpace - Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>().transform.position;
                float newX = Vector3.SignedAngle(_submarine.transform.forward, lookPosTest, _submarine.transform.right);

                gunMesh.transform.localRotation = Quaternion.Euler(newX, 0, 0);
            }
        }
    }

    public void SetSubmarineSprite(GameObject obj)
    {
        _submarineSprite = obj;
    }

    void SetAimVector(Vector3 v)
    {
        aimVector = v;
    }

    public Vector3 GetAimVector()
    {
        return aimVector;
    }
}
