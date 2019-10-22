using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovementScript : MonoBehaviour
{
    Rigidbody2D body;
    RectTransform rect;

    [SerializeField]
    GameObject submarineOBJ;
    [SerializeField]
    RectTransform spriteGunPivot;
    [SerializeField]
    float moveAcceleration = 20.0f;
    [SerializeField]
    float maxSpeed = 15.0f;
    [SerializeField]
    string subCenterString = "Sub_Center";
    [SerializeField]
    BoxCollider2D subCollider;
    
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    bool acceptHorizontal = true;
    Vector2 oldVelocity = Vector2.zero;

    float cappedY = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (acceptHorizontal)
            // Gives a value between -1 and 1
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        else
            horizontal = 0;

        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (horizontal != 0 || vertical != 0) // Check for any movement
        {
            //Debug.Log(body.velocity.SqrMagnitude());
            if (body.velocity.SqrMagnitude() < (maxSpeed * maxSpeed) )
                body.velocity = body.velocity + new Vector2(horizontal * moveAcceleration, vertical * moveAcceleration) * Time.fixedDeltaTime;
        }
        else
        {
            body.velocity = body.velocity;
        }

        oldVelocity = body.velocity;
    }
    private void LateUpdate()
    {
        if (submarineOBJ.transform.forward.normalized.x > 0 && horizontal < 0)
        {
            //Debug.Log("facing right, moving left");
            //Debug.Log(submarineOBJ.transform.localEulerAngles);

            StartCoroutine(RotateSub(90, 270, 0.25f));
        }
        else if (submarineOBJ.transform.forward.normalized.x < 0 && horizontal > 0)
        {
            //Debug.Log("facing left, moving right");
            //Debug.Log(submarineOBJ.transform.localEulerAngles);

            StartCoroutine(RotateSub(270, 90, 0.25f));
        }

            //submarineOBJ.transform.localRotation = Quaternion.Euler(-30 * vertical * (body.velocity.sqrMagnitude / (maxSpeed * maxSpeed)),
                //submarineOBJ.transform.localRotation.eulerAngles.y, submarineOBJ.transform.localRotation.eulerAngles.z);

        if (body.velocity.y > 0)
        {
            submarineOBJ.transform.localRotation = Quaternion.Euler(Mathf.SmoothStep(0, -30, body.velocity.y / (maxSpeed) ),
                submarineOBJ.transform.localRotation.eulerAngles.y, submarineOBJ.transform.localRotation.eulerAngles.z);
        }
        else if (body.velocity.y < 0)
        {
            submarineOBJ.transform.localRotation = Quaternion.Euler(Mathf.SmoothStep(0, 30, -body.velocity.y / (maxSpeed) ),
                submarineOBJ.transform.localRotation.eulerAngles.y, submarineOBJ.transform.localRotation.eulerAngles.z);
        }

        RectTransform subCenterRect = this.transform.Find(subCenterString).GetComponent<RectTransform>();

        if (submarineOBJ.transform.forward.normalized.x > 0)
            subCenterRect.localRotation = Quaternion.Euler(subCenterRect.localRotation.eulerAngles.x, subCenterRect.localRotation.eulerAngles.y, -submarineOBJ.transform.localRotation.eulerAngles.x);
        else
            subCenterRect.localRotation = Quaternion.Euler(subCenterRect.localRotation.eulerAngles.x, subCenterRect.localRotation.eulerAngles.y, submarineOBJ.transform.localRotation.eulerAngles.x);

        if (cappedY != 0)
        {
            if (cappedY > 0)
            {
                rect.localPosition = new Vector3(rect.localPosition.x, Mathf.Clamp(rect.localPosition.y, 0, cappedY), rect.localPosition.z);
            }
            else if (cappedY < 0)
            {
                rect.localPosition = new Vector3(rect.localPosition.x, Mathf.Clamp(rect.localPosition.y, cappedY, 0), rect.localPosition.z);
            }
        }

        RectTransform colliderRect = subCollider.gameObject.GetComponent<RectTransform>();
        colliderRect.localRotation = Quaternion.Euler(colliderRect.localRotation.eulerAngles.x, colliderRect.localRotation.eulerAngles.y, 
            -1 * Mathf.Sign(submarineOBJ.transform.forward.x) * submarineOBJ.transform.localRotation.eulerAngles.x);

        if (cappedY > 0 && rect.localPosition.y < cappedY)
        {
            cappedY = 0;
        }
        else if (cappedY < 0 && rect.localPosition.y > cappedY)
        {
            cappedY = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cappedY == 0)
        {
            if (collision.gameObject.name == "Top Boundary" || collision.gameObject.name == "Bottom Boundary")
            {
                cappedY = rect.localPosition.y;
            }
        }
        /*
        if (collision.gameObject.name == "Top Boundary" && cappedY == 0)
        {
            cappedY = rect.localPosition.y;
        }
        else if (collision.gameObject.name == "Bottom Boundary" && cappedY == 0)
        {
            cappedY = rect.localPosition.y;
        }
        */
    }

    IEnumerator RotateSub(float startAngle, float targetAngle, float rotationTime)
    {
        float t = 0, currAngle = startAngle, gunPivotStartX = spriteGunPivot.localPosition.x,
            gunPivotCurrX = gunPivotStartX, gunPivotTargetX = -gunPivotStartX;

        while (currAngle != targetAngle)
        {
            acceptHorizontal = false;

            currAngle = Mathf.Lerp(startAngle, targetAngle, t);
            gunPivotCurrX = Mathf.Lerp(gunPivotStartX, gunPivotTargetX, t);

            submarineOBJ.transform.localEulerAngles = new Vector3(submarineOBJ.transform.localEulerAngles.x, currAngle, submarineOBJ.transform.localEulerAngles.z);
            spriteGunPivot.localPosition = new Vector3(gunPivotCurrX, spriteGunPivot.localPosition.y, spriteGunPivot.localPosition.z);

            t += Time.deltaTime / rotationTime;
            yield return new WaitForEndOfFrame();
        }

        acceptHorizontal = true;
    }
   
}
