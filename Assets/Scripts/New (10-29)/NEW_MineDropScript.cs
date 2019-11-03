using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class NEW_MineDropScript : MonoBehaviour
{
    [InfoBox("NOTE!: Dropping mine currently hardcoded to RightMouseButtonUp")]
    [SerializeField]
    GameObject playerMine;

    [SerializeField]
    SubmarineSettingsScript subSettings;

    bool canFire = true;
    float mineSpeed = -1;
    float mineDelay = -1;
    int currMines = -1;

    GameObject droppedMine;

    // Start is called before the first frame update
    // Set variables here that will only ever be set once at start of game
    void Awake()
    {
        mineSpeed = subSettings.GetMineSpeed();
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
        Debug.Log("[[PlayerMineDropScript]] Level Loaded: " + scene.name + " [LoadSceneMode = " + mode + "]");

        mineDelay = subSettings.GetMineDelay();
        currMines = subSettings.GetCurrentMines();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
            if (droppedMine == null)
                StartCoroutine(DropMine());
            else
                StartCoroutine(DetonateMine());
    }

    IEnumerator DropMine()
    {
        if (canFire && currMines > 0)
        {
            canFire = false;
            currMines -= 1;
            subSettings.SetCurrentMines(currMines);

            GameObject newMine = Instantiate(playerMine, this.transform.parent);
            newMine.name = "PlayerMine[" + Time.realtimeSinceStartup.ToString("#.###") + "]";
            newMine.transform.SetSiblingIndex(this.transform.GetSiblingIndex() - 1);

            RectTransform subRect = this.gameObject.GetComponent<RectTransform>();
            newMine.transform.position = this.transform.position;

            Rigidbody2D mine_r2d = newMine.GetComponent<Rigidbody2D>();
            mine_r2d.velocity = new Vector2(0, -mineSpeed);

            PlayerMineCollisionScript colScript = newMine.GetComponent<PlayerMineCollisionScript>();
            colScript.SetMineDamage(subSettings);

            droppedMine = newMine;

            yield return new WaitForSeconds(mineDelay);
            canFire = true;
        }
    }
    IEnumerator DetonateMine()
    {
        droppedMine.GetComponent<PlayerMineCollisionScript>().Detonate();
        yield return null;
    }
}
