using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static Teleport instance;

    public Transform player;
    public Animator anim;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tele()
    {
        
        transform.position = new Vector3(player.position.x + 2, player.position.y , player.position.z);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        
        
    }
}
