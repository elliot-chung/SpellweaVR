using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public OVRCameraRig CameraRig;

    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - CameraRig.centerEyeAnchor.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraRig.centerEyeAnchor.position + _offset;
    }
}
