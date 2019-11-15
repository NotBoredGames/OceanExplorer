using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMineCollisionScript : MonoBehaviour
{
    [SerializeField]
    SubmarineSettingsScript subSettings;

    [SerializeField]
    GameObject mineExplosion;

    [SerializeField]
    [Range(0, 50)]
    float explosionRadius = 10;

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

        Detonate(point);
    }

    public void Detonate(Vector2 _point)
    {
        GameObject _mineExplosion = Instantiate(mineExplosion);
        _mineExplosion.name = this.gameObject.name + " Explosion";
        _mineExplosion.transform.position = _point;
        Destroy(this.gameObject);
    }

    public void Detonate()
    {
        GameObject _mineExplosion = Instantiate(mineExplosion);
        _mineExplosion.name = this.gameObject.name + " Explosion";
        _mineExplosion.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

    // These are the old versions of Detonate, before we were instantiating a mineExplosion prefab
    /*
    public void Detonate(Vector2 _point, float _radius)
    {
        Collider2D[] explosionTargets = Physics2D.OverlapCircleAll(_point, _radius);

        DrawCircle(_point, _radius, Color.red, 10);

        foreach (Collider2D target in explosionTargets)
        {
            if (target.tag == "Enemy")
            {
                DrawCircle(target.ClosestPoint(_point), 0.5f, Color.red, 10, 4);
                DrawCircle(target.transform.position, 1, Color.red, 10, 8);
                Debug.DrawLine(target.ClosestPoint(_point), target.transform.position, Color.red, 10);
                Destroy(target.gameObject);
            }
        }

        Destroy(this.gameObject);
    }

    public void Detonate()
    {
        Collider2D[] explosionTargets = Physics2D.OverlapCircleAll(this.transform.position, explosionRadius);

        DrawCircle(this.transform.position, explosionRadius, Color.red, 10);

        foreach (Collider2D target in explosionTargets)
        {
            if (target.tag == "Enemy")
            {
                DrawCircle(target.ClosestPoint(this.transform.position), 1, Color.red, 10, 4);
                DrawCircle(target.transform.position, 1, Color.red, 10, 8);
                Debug.DrawLine(target.ClosestPoint(this.transform.position), target.transform.position, Color.red, 10);
                Destroy(target.gameObject);
            }
        }

        Destroy(this.gameObject);
    }
    */

    // Requied for instantiating a new mine in the game scene
    public void SetMineDamage(SubmarineSettingsScript _subSettings)
    {
        subSettings = _subSettings;
        damage = subSettings.GetMineDamage();
    }

    private void DrawCircle(Vector3 pos, float radius, Color color, float duration = 0, int segments = 180)
    {
        float angle = 0f;
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        Vector3 lastPoint = Vector3.zero;
        Vector3 thisPoint = Vector3.zero;

        for (int i = 0; i < segments + 1; i++)
        {
            thisPoint.x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            thisPoint.y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            if (i > 0)
            {
                Debug.DrawLine(rot * lastPoint + pos, rot * thisPoint + pos, color, duration);
            }

            lastPoint = thisPoint;
            angle += 360f / segments;
        }
    }
}
