using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEW_InheritScrollScript : MonoBehaviour
{
    // public GameObject thisObjectRightHereOfficer;

    [SerializeField]
    [Range(0.125f, 16)]
    public float scrollRate = 4;
    //  public static float scrollRateMG = 3;
    //   public static float scrollRateBG = 1;
    // since this is now static, will need different scrollRate for each layer
    // ie) one for each Level Geometry/Enemies, Background, Middleground

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // check for tag/layer to see what scrollRate will be used


        // if game object is on the environment level
        //  if (this.gameObject.layer == 16)
      //  {
            if (LevelScrollControlScript.Scroll)
            {
                float scrollX = scrollRate * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedX(Time.timeSinceLevelLoad) * Time.deltaTime;
                float scrollY = scrollRate * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad) * Time.deltaTime;
                //Debug.Log(scrollY);

                transform.position += new Vector3(scrollX, scrollY, 0);
            }
            //  }

            // No longer necessary,there is a bool in the level control script to stop everything
            /*
            // if the game object is on the enemy layer
            if (this.gameObject.layer == 11)
            {
                if (LevelScrollControlScript.Scroll)
                {
                    float scrollX = scrollRate * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedX(Time.timeSinceLevelLoad) * Time.deltaTime;
                    float scrollY = scrollRate * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad) * Time.deltaTime;
                    //Debug.Log(scrollY);

                    transform.position += new Vector3(scrollX, scrollY, 0);
                }
            }

            // if the game object is on the MiddleGround Non-Collidable layer
            if (this.gameObject.layer == 17)
            {
                if (LevelScrollControlScript.Scroll)
                {
                    float scrollX = scrollRateMG * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedX(Time.timeSinceLevelLoad) * Time.deltaTime;
                    float scrollY = scrollRateMG * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad) * Time.deltaTime;
                    //Debug.Log(scrollY);

                    transform.position += new Vector3(scrollX, scrollY, 0);
                }
            }


            // if the game object is on the Background layer
            if (this.gameObject.layer == 8)
            {
                if (LevelScrollControlScript.Scroll)
                {
                    float scrollX = (scrollRateBG / 4) * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedX(Time.timeSinceLevelLoad) * Time.deltaTime;
                    float scrollY = (scrollRateBG / 4) * LevelScrollControlScript.ScrollDirection * LevelScrollControlScript.GetScrollSpeedY(Time.timeSinceLevelLoad) * Time.deltaTime;
                    //Debug.Log(scrollY);

                    transform.position += new Vector3(scrollX, scrollY, 0);
                }
            }
            */
        }

    }

