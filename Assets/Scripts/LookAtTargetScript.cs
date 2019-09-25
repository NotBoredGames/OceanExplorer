using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetScript : MonoBehaviour
{
    [SerializeField]
    Camera _2dCanvasCamera;

    [SerializeField]
    Canvas _submarineCanvas;

    [SerializeField]
    RectTransform _submarineSprite;

    [SerializeField]
    GameObject _submarine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimpointScreenSpace = Input.mousePosition;
        aimpointScreenSpace.z = _submarineCanvas.transform.position.z - _2dCanvasCamera.transform.position.z;

        Vector3 aimpointWorldSpace = _2dCanvasCamera.ScreenToWorldPoint(aimpointScreenSpace);
        aimpointWorldSpace = aimpointWorldSpace - _submarineSprite.transform.position;

        float aimpointSubmarineSpaceX = (_submarine.transform.position.x - _2dCanvasCamera.transform.position.x) + aimpointWorldSpace.x;
        float aimpointSubmarineSpaceY = (_submarine.transform.position.y - _2dCanvasCamera.transform.position.y) + aimpointWorldSpace.y;
        float aimpointSubmarineSpaceZ = _submarine.transform.position.z - 10;

        Vector3 aimpointSubmarineSpace = new Vector3(aimpointSubmarineSpaceX, aimpointSubmarineSpaceY, aimpointSubmarineSpaceZ);

        Debug.DrawLine(_submarine.transform.position, aimpointSubmarineSpace, Color.green);

        _submarine.transform.LookAt(aimpointSubmarineSpace);
    }

    public void SetSubmarineSprite(RectTransform rect)
    {
        _submarineSprite = rect;
    }
    
}
