using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public enum BulletType
    {
        Pencil,
        Eraser,
        Ruler
    }

    public BulletType currentBullet;

    public float speed = 10f;
    public Rigidbody2D theRB;
    SpriteRenderer sprite;

    public GameObject impactEffect;

    public int damageToGive = 150;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.Rotate(0, 0, 90);
        //sprite.transform.Rotate(0, 0, Random.Range(0, 360));

        theRB.velocity = transform.right * speed;

        if(currentBullet == BulletType.Pencil)
        {
            damageToGive = 50;
        }
        else if(currentBullet == BulletType.Eraser)
        {
            damageToGive = 25;
        }
        else if(currentBullet == BulletType.Ruler)
                {
            damageToGive = 75;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
        }

        if(other.tag == "Boss")
        {
            BossController.instance.TakeDamage(damageToGive);

            Instantiate(BossController.instance.hitEffect, transform.position, transform.rotation);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
