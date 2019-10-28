using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMineCollisionScript : MonoBehaviour
{
    [SerializeField]
    SubmarineSettingsScript subSettings;

    [SerializeField]
    [Range(0, 16)]
    float explosionRadius = 1;

    int damage;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 point = other.GetContact(0).point;

        Collider2D[] explosionTargets = Physics2D.OverlapCircleAll(point, explosionRadius);

        foreach(Collider2D target in explosionTargets)
        {
            if (target.tag == "Enemy")
            {
                Destroy(target.gameObject);
            }
        }

        Destroy(this.gameObject);
    }

    public void SetSubSettings(SubmarineSettingsScript _subSettings)
    {
        subSettings = _subSettings;
        damage = subSettings.GetMineDamage();
    }
}
