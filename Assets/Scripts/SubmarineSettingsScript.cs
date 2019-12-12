using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

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
    public int currentBulletDamage;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    int startingMines = 3;

    [BoxGroup("Mine Settings")]
    [SerializeField]
    public int maxMines;

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
    public int maxHP;

    [BoxGroup("Other Settings")]
    [SerializeField]
    int currentHP;

    [BoxGroup("Other Settings")]
    [ShowInInspector]
    public static int currentScrap = 0;

    [BoxGroup("Other Settings")]
    [ShowInInspector]
    public static int scrapCollectionMultiplier = 1;


    // for storing if a crew member has been found yet
    // may want to store elsewhere for save system
    public static bool foundEngineer;
    public static bool foundWeaponsmith;
    public static bool foundScrapper;
    public static bool foundMarineBio;
    public static bool foundScrap;
	
	
	public int eLvl;
	public int wLvl;
	public int nLvl;
	public int sLvl;
	public int mbLvl;
	
	public int subSpeed;
	public int scrapIncrease;


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

        
        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
		
				
		eLvl=0;
		wLvl=0;
		nLvl=0;
		sLvl=0;
		mbLvl=0;
		
		subSpeed=25;
		scrapIncrease=0;
            
    }

    public void Reset()
    {
        scrapCollectionMultiplier = 1;
        currentScrap = 0;
        maxMines = startingMines;
        maxHP = startingHP;
        currentBulletDamage = startingBulletDamage;
        currentMineDamage = startingMineDamage;

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
        Debug.Log("[[SubmarineSettingsScript]] Level Loaded: " + scene.name + " [LoadSceneMode = " + mode + "]");

        currentHP = maxHP;
        currentMines = maxMines;
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
