using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPointScript : MonoBehaviour
{

    public Material activeMat;
    public Material inactiveMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.gameObject.name == "user_point")
    //    {
    //        gameObject.GetComponent<Renderer>().material = activeMat;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "user_point")
        {
            gameObject.GetComponent<Renderer>().material = activeMat;
            gameObject.transform.parent.GetComponent<SpellcastingScript>().PointTouched(int.Parse(gameObject.name.Substring(gameObject.name.Length - 1)), gameObject.transform.position);
        }
    }
}
