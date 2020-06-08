using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTele : MonoBehaviour
{

    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8, enemy9, enemy10;
    public GameObject key;
    public GameObject janitor;
    public GameObject light1;
    public GameObject fuse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy3.SetActive(true);
        enemy4.SetActive(true);
        enemy5.SetActive(true);
        enemy6.SetActive(true);
        enemy7.SetActive(true);
        enemy8.SetActive(true);
        enemy9.SetActive(true);
        enemy10.SetActive(true);

        key.SetActive(false);

        janitor.SetActive(true);

        light1.SetActive(true);

        fuse.SetActive(true);

        Destroy(gameObject);
    }
}
