using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpen;
    public GameObject janitor;

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
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
            janitor.SetActive(true);
        }
    }

}
