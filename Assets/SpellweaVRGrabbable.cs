using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellweaVRGrabbable : MonoBehaviour
{

    public bool grabbed = false;
    public Vector3 velocity;

    private Vector3 prevPosition;
    // Start is called before the first frame update
    void Start()
    {
        prevPosition = transform.position;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - prevPosition) / Time.deltaTime;
        prevPosition = transform.position;
    }
}
