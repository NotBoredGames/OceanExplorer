using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineEnemyExplosion : MonoBehaviour
{

    [SerializeField]
    GameObject mineExplosion;

    [SerializeField]
    [Range(0, 50)]
    float explosionRadius = 10;




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

        /*
        // once player collides with mine take damage
        if (other.gameObject.tag == "Player")
        {
            subSettings.SetCurrentHP(subSettings.GetCurrentHP() - 1);
        }
        */

        // if other enemies collide with mine it won't detonate
        if (other.gameObject.tag != "Enemy")
        {
            Detonate(point);
        }
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
