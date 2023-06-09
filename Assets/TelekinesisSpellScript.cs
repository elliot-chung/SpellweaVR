using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisSpellScript : MonoBehaviour
{
    Rigidbody _grabbedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableGrab()
    {
        RaycastHit rayHit = GetComponent<SpellRaycast>().GetHitPosition();
        if (rayHit.rigidbody != null)
        {
            _grabbedObject = rayHit.rigidbody;
            _grabbedObject.isKinematic = true;
            _grabbedObject.transform.position = transform.position + transform.forward * 1.0f;
            _grabbedObject.transform.forward = transform.forward;
            _grabbedObject.transform.parent = transform;
        }


    }

    public void DisableGrab()
    {
        _grabbedObject.isKinematic = false;
        transform.DetachChildren();
    }
}
