using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOnscreenScript : MonoBehaviour
{

    [SerializeField]
    BoxCollider2D activator;

    [SerializeField]
    string scriptActivatorName;

    [SerializeField]
    AudioClip bossMusic;

    Collider2D scriptActivator;

    float t = 5;
    bool hasPrinted = false;

    // Start is called before the first frame update
    void Start()
    {
        scriptActivator = GameObject.Find(scriptActivatorName).GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptActivator.bounds.Intersects(activator.bounds))
        {
            if (!hasPrinted)
            {
                Debug.Log("Boss " + this.gameObject.name + " is onscreen!");
                hasPrinted = true;
            }
            LevelScrollControlScript.Scroll = false;
            this.gameObject.GetComponent<Animator>().SetBool("isOnscreen", true);

            ShortWait();

            if (t <= 0)
            {
                this.gameObject.GetComponent<KrakenAttackScript>().enabled = true;
                this.gameObject.GetComponent<KrakenAttackScript>().runCode = true;
                this.gameObject.GetComponent<KrakenAttackScript>().Awake();

                if (activator.gameObject != this.gameObject)
                {
                    activator.gameObject.SetActive(false);
                    this.enabled = false;
                }
            }
        }
    }

    void ShortWait()
    {
        t -= Time.deltaTime;
    }

    public void PlayMusic()
    {
        SoundManagerScript audioScript =  GameObject.Find("SoundManager").GetComponent<SoundManagerScript>();

        if (audioScript)
            audioScript.PlayMusic(bossMusic);
    }
}
