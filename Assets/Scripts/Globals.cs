using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class Globals : MonoBehaviour
{
    [SerializeField]
    string verticalGameplayCanvasString;

    static GameObject verticalGameplayCanvas;

    [ShowInInspector]
    public static int lastSubLevelPlayed = -1;

    private static GameObject instance;
    // Start is called before the first frame update
    void Awake()
    {
        verticalGameplayCanvas = GameObject.Find(verticalGameplayCanvasString);

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }

    // Set variables here that may change in between levels (ie from upgrade during hub level)
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("[[Globals]] Level Loaded: " + scene.name + " [LoadSceneMode = " + mode + "]");

        verticalGameplayCanvas = GameObject.Find(verticalGameplayCanvasString);

        if (!verticalGameplayCanvas)
            Debug.Log("[[Globals]] FAILED TO FIND SUB LEVEL UI!");

        if (SceneManager.GetActiveScene().name != "SubHub")
        {
            for(int i = 0; i < SceneManager.sceneCount; i++)
            {
                string name = SceneManager.GetSceneAt(i).name;
                string lastChar = name.Substring(name.Length - 1);
                int testNum;
                if (System.Int32.TryParse(lastChar, out testNum))
                {
                    lastSubLevelPlayed = int.Parse(name.Substring(name.Length - 1));
                    break;
                }
                
            }
            //lastLevelPlayed = int.Parse(name.Substring(name.Length - 1));
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        //if (Input.GetKeyUp(KeyCode.R))
            //Application.LoadLevel(Application.loadedLevel);

        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Break();
        }
    }

    public static Transform FindDeepChild(Transform aParent, string aName)
    {
        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(aParent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.name == aName)
                return c;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }

    public static void LevelOutro(int nextLevel)
    {
        UI_LevelIntroOutroScript uiScript = verticalGameplayCanvas.GetComponent<UI_LevelIntroOutroScript>();
        if (uiScript != null)
        {
            uiScript.LevelOutro();
        }
        else
            Debug.Log("Globals->LevelOutro: Could not find UI_LevelIntroOutroScript on the sub level UI!");
    }

    public static void LoadSubHub()
    {

    }
}
