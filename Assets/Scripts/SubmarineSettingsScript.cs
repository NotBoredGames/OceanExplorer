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

    [BoxGroup("Turret Settings")]
    [SerializeField]
    int startingBulletDamage = 1;

    [BoxGroup("Turret Settings")]
    [SerializeField]
    int currentBulletDamage;

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

    [BoxGroup("Mine Settings")]
    [SerializeField]
    int startingMineDamage = 5;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    int currentMineDamage;

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
    public static int currentScrap = 0;

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

        currentBulletDamage = startingBulletDamage;
        currentMineDamage = startingMineDamage;

        DontDestroyOnLoad(this.gameObject);
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

    public void SetBulletDamage(int i)
    {
        currentBulletDamage = i;
    }

    public int GetBulletDamage()
    {
        return currentBulletDamage;
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

    public void SetMineDamage(int i)
    {
        currentMineDamage = i;
    }

    public int GetMineDamage()
    {
        return currentMineDamage;
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
    /*
    // sets the current amount of scrap after player picks it up
    public void SetScrapTotal(int i)
    {
        currentScrap += i;
    }

    // returns total
    public int GetScrapTotal()
    {
        return currentScrap;
    }
    */
}
