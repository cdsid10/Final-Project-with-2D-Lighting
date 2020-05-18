using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject[] Light2d;
    public GameObject TileMap;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SideTarget.instance.sIsTriggered && FrontTarget.instance.fisTriggered)
        {
            Destroy(TileMap);
        }
    }
}
