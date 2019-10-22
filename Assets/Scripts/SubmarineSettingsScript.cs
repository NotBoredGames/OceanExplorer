using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SubmarineSettingsScript : MonoBehaviour
{
    [BoxGroup("Turret Settings")]
    [SerializeField]
    float shotDelay = 0.5f;

    [BoxGroup("Turret Settings")]
    [SerializeField]
    float bulletSpeed = 50;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    int startingMines = 3;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    int maxMines;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    int currentMines;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    float mineDelay = 2;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    float mineSpeed = 30;

    [BoxGroup("Other Settings")]
    [SerializeField]
    int startingHP = 10;

    [BoxGroup("Other Settings")]
    [SerializeField]
    int maxHP;

    [BoxGroup("Other Settings")]
    [SerializeField]
    int currentHP;

    [BoxGroup("Other Settings")]
    [SerializeField]
    int currentScrap = 0;

    // Start is called before the first frame update
    void Start()
    {
        //currentMines = startingMines;
        //maxMines = startingMines;
    }

    void Awake()
    {
        currentMines = startingMines;
        maxMines = startingMines;

        maxHP = startingHP;
        currentHP = startingHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetShotDelay(float t)
    {
        shotDelay = t;
    }

    public float GetShotDelay()
    {
        return shotDelay;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public void SetMaxMines(int i)
    {
        maxMines = i;
    }

    public int GetMaxMines()
    {
        return maxMines;
    }

    public void SetCurrentMines(int i)
    {
        currentMines = i;
    }

    public int GetCurrentMines()
    {
        return currentMines;
    }

    public float GetMineSpeed()
    {
        return mineSpeed;
    }

    public float GetMineDelay()
    {
        return mineDelay;
    }

    public void SetCurrentHP(int i)
    {
        currentHP = i;
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public void SetMaxHP(int i)
    {
        maxHP = i;
    }

    public int GetMaxHP()
    {
        return maxHP;
    }
}
