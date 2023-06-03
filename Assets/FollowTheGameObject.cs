using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheGameObject : MonoBehaviour
{
    private GameObject whatToFollow;
    // Start is called before the first frame update
    void Start()
    {
        whatToFollow = GameObject.Find("RightHandAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.SetPositionAndRotation(whatToFollow.transform.position, whatToFollow.transform.rotation);
    }
}
