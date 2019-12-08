using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class NEW_TurretFireScript : MonoBehaviour
{
    [InfoBox("NOTE!: Firing turret currently hardcoded to LeftMouseButton")]
    [SerializeField]
    GameObject submarineOBJ;

    [SerializeField]
    GameObject playerBullet;

    [SerializeField]
    Transform turretReference;

    [SerializeField]
    SubmarineSettingsScript subSettings;

    [SerializeField]
    float turretOffset = 1;

    [SerializeField]
    public AudioClip shootSound;

    bool canFire = true;
    NEW_TurretAimScript aimScript;
    float bulletSpeed = -1;
    float shotDelay = -1;

    // Start is called before the first frame update
    // Set variables here that will only ever be set once at start of game
    void Start()
    {
        aimScript = submarineOBJ.GetComponent<NEW_TurretAimScript>();

        if (aimScript == null)
        {
            Debug.Break();
            Debug.LogError("[[" + this.name + "]] No TurretAimtScript attached to submarineOBJ!");
        }

        bulletSpeed = subSettings.GetBulletSpeed();
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
        Debug.Log("[[PlayerTurretFireScript]] Level Loaded: " + scene.name + " [LoadSceneMode = " + mode + "]");

        shotDelay = subSettings.GetShotDelay();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
            StartCoroutine(FireTurret());
    }

    IEnumerator FireTurret()
    {
        if (canFire)
        {
            canFire = false;

            SoundManagerScript.instance.PlaySingle(shootSound);

            GameObject newBullet = Instantiate(playerBullet, this.transform.parent);
            newBullet.name = "TurretBullet[" + Time.realtimeSinceStartup.ToString("#.###") + "]";

            Vector3 aimVector = aimScript.GetAimVector().normalized;

            //newBullet.transform.position = this.transform.position + turretReference.position;
            //newBullet.transform.position += turretOffset * aimVector;
            newBullet.transform.position = turretReference.position + turretOffset * aimVector;

            Rigidbody2D bullet_r2d = newBullet.GetComponent<Rigidbody2D>();
            bullet_r2d.velocity = bulletSpeed * aimVector;

            yield return new WaitForSeconds(shotDelay);
            canFire = true;
        }
    }
}
