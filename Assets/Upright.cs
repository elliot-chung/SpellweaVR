using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upright : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRot = transform.rotation.eulerAngles;
        newRot.x = 0;
        newRot.z = 0;
        transform.rotation = Quaternion.Euler(newRot);
    }
}
