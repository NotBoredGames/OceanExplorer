using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEW_TurretAimScript : MonoBehaviour
{
    [SerializeField]
    Camera _camera;

    [SerializeField]
    Canvas _inputCanvas;

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
        //aimpointScreenSpace.z = _inputCanvas.transform.position.z - _camera.transform.position.z;
        aimpointScreenSpace.z = _submarineSprite.transform.position.z - _camera.transform.position.z;

        Vector3 aimpointWorldSpace = _camera.ScreenToWorldPoint(aimpointScreenSpace);

        Debug.DrawLine(aimpointWorldSpace, Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).transform.position, Color.cyan);

        // Setting aimVector so it is available from other scripts (ie the turret firing script)
        aimVector = aimpointWorldSpace - Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).transform.position;

        float aimpointSubmarineSpaceX = (_submarine.transform.position.x - _camera.transform.position.x) + aimpointWorldSpace.x;
        float aimpointSubmarineSpaceY = (_submarine.transform.position.y - _camera.transform.position.y) + aimpointWorldSpace.y;
        float aimpointSubmarineSpaceZ = _gunMeshes[0].transform.position.z;

        Vector3 aimpointSubmarineSpace = new Vector3(aimpointSubmarineSpaceX, aimpointSubmarineSpaceY, aimpointSubmarineSpaceZ);

        Debug.DrawLine(_gunMeshes[0].transform.position, aimpointSubmarineSpace, Color.green);


        foreach (GameObject gunMesh in _gunMeshes)
        {
            if (gunMesh.activeSelf)
            {
                Vector3 lookPos = aimpointSubmarineSpace - gunMesh.transform.position;

                Vector3 lookPosTest = aimpointWorldSpace - Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).transform.position;
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
