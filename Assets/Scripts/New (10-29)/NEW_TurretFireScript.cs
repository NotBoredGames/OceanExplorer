﻿using System.Collections;
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
            Debug.LogError("No SideGunLookAtScript attached to submarineOBJ!");
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

            GameObject newBullet = Instantiate(playerBullet, this.transform.parent);
            newBullet.name = "TurretBullet[" + Time.realtimeSinceStartup.ToString("#.###") + "]";

            Vector3 aimVector = aimScript.GetAimVector().normalized;

            newBullet.transform.position = this.transform.position + turretReference.localPosition;
            newBullet.transform.position += turretOffset * aimVector;

            Rigidbody2D bullet_r2d = newBullet.GetComponent<Rigidbody2D>();
            bullet_r2d.velocity = bulletSpeed * aimVector;
            Debug.Log(bullet_r2d.velocity);

            yield return new WaitForSeconds(shotDelay);
            canFire = true;
        }
    }
}
