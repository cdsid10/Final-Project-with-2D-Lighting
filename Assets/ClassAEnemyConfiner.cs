using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassAEnemyConfiner : MonoBehaviour
{
    public GameObject doorCollider;

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
        doorCollider.SetActive(true);
    }
}
