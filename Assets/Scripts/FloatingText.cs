using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
