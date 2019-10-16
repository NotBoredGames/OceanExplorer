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
    

    Vector3 startRot;

    float vel = 0;

    // Start is called before the first frame update
    void Start()
    {
        //startRot = _submarine.transform.rotation.eulerAngles;
        startRot = new Vector3(0, 90, 0);
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

                //gunMesh.transform.LookAt(aimpointSubmarineSpace);
                //gunMesh.transform.forward = aimpointWorldSpace - Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>().transform.position;

                Vector3 lookPosTest = aimpointWorldSpace - Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>().transform.position;
                float newX = Vector3.SignedAngle(_submarine.transform.forward, lookPosTest, _submarine.transform.right);
                //Debug.Log(newX);

                gunMesh.transform.localRotation = Quaternion.Euler(newX, 0, 0);
            }
        }
        
        if (_submarineSprite.GetComponent<Rigidbody2D>().velocity.y > 1)
        {
            //_submarine.transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(_submarine.transform.rotation.eulerAngles.x, -30 + startRot.x, ref vel, 0.5f), 0 + startRot.y, 0 + startRot.z);
            //_submarineSprite.transform.Find(_submarineSpriteCenter).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -1 * startRot.y / Mathf.Abs(startRot.y) * _submarine.transform.rotation.eulerAngles.x);
        }
        else if (_submarineSprite.GetComponent<Rigidbody2D>().velocity.y < -1)
        {
            //_submarine.transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(_submarine.transform.rotation.eulerAngles.x, 30 + startRot.x, ref vel, 0.5f), 0 + startRot.y, 0 + startRot.z);
            //_submarineSprite.transform.Find(_submarineSpriteCenter).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -1 * startRot.y / Mathf.Abs(startRot.y) * _submarine.transform.rotation.eulerAngles.x);
        }
        else
        {
            //_submarine.transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(_submarine.transform.rotation.eulerAngles.x, 0 + startRot.x, ref vel, 0.25f), 0 + startRot.y, 0 + startRot.z);
            //_submarineSprite.transform.Find(_submarineSpriteCenter).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -1 * startRot.y / Mathf.Abs(startRot.y) * _submarine.transform.rotation.eulerAngles.x);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            //_submarine.transform.rotation = Quaternion.Euler(_submarine.transform.rotation.eulerAngles.x, -90, _submarine.transform.rotation.eulerAngles.z);
            //startRot = new Vector3(0, -90, 0);
            //RectTransform gpRect = Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>();
            //gpRect.localPosition = new Vector3(-1 * Mathf.Abs(gpRect.localPosition.x), gpRect.localPosition.y, gpRect.localPosition.z);
        }
        else if ((Input.GetAxis("Horizontal") > 0))
        {
            //_submarine.transform.rotation = Quaternion.Euler(_submarine.transform.rotation.eulerAngles.x, 90, _submarine.transform.rotation.eulerAngles.z);
            //startRot = new Vector3(0, 90, 0);
            //RectTransform gpRect = Globals.FindDeepChild(_submarineSprite.transform, _gunPivot).GetComponent<RectTransform>();
            //gpRect.localPosition = new Vector3(Mathf.Abs(gpRect.localPosition.x), gpRect.localPosition.y, gpRect.localPosition.z);
        }
    }

    public void SetSubmarineSprite(GameObject obj)
    {
        _submarineSprite = obj;
    }
}
