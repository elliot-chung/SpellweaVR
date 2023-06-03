using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterTrackingSpace : MonoBehaviour
{
    public GameObject CenterEyeAnchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CenterEyeAnchor.transform.localPosition;
    }
}
