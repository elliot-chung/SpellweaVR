using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisSpellScript : MonoBehaviour
{
    private Rigidbody _grabbedObject;

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
        if (rayHit.rigidbody != null && rayHit.rigidbody.gameObject.GetComponent<SpellweaVRGrabbable>()?.grabbed == false)
        {
            _grabbedObject = rayHit.rigidbody;
            _grabbedObject.gameObject.GetComponent<SpellweaVRGrabbable>().grabbed = true;
            _grabbedObject.isKinematic = true;
            _grabbedObject.transform.position = transform.position + transform.forward * 1.0f;

            _grabbedObject.transform.forward = transform.forward;
            _grabbedObject.transform.parent = transform;
        }
    }

    public void DisableGrab()
    {
        if (_grabbedObject != null)
        {
            _grabbedObject.isKinematic = false;
            _grabbedObject.gameObject.GetComponent<SpellweaVRGrabbable>().grabbed = false;
            _grabbedObject.velocity = _grabbedObject.gameObject.GetComponent<SpellweaVRGrabbable>().velocity;
        }
        transform.DetachChildren();
    }
}
