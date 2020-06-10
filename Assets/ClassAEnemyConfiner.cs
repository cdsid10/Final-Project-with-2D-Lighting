using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassAEnemyConfiner : MonoBehaviour
{
    public bool openWhenClear;
    //private bool roomActive;

    public GameObject doorCollider;
    public GameObject janitor;

    public List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count > 0 && openWhenClear)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }

            if(enemies.Count == 0)
            {
                //doorCollider.SetActive(false);
                janitor.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //roomActive = true;
        //doorCollider.SetActive(true);
    }
}
