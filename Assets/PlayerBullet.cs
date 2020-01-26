using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D theRB;
    SpriteRenderer sprite;

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

        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
