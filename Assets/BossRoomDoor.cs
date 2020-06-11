using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpen;
    public GameObject janitor;
    public GameObject arrow;

    public bool canAccess;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canAccess)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorClosed.SetActive(false);
                doorOpen.SetActive(true);
                janitor.SetActive(true);

                AudioManager.instance.LightsIn();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            arrow.SetActive(true);
            canAccess = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        arrow.SetActive(false);
        canAccess = false;
    }

}
