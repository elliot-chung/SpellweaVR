using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellRaycast : MonoBehaviour
{
    const float RAY_LENGTH = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public RaycastHit GetHitPosition()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RAY_LENGTH);
        return hit;
    }
}
