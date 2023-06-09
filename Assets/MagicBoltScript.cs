using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoltScript : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
