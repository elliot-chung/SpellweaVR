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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.gameObject.CompareTag("Enemy") && collision.collider.gameObject.GetComponent<HealthObject>() != null)
            {
                collision.collider.gameObject.GetComponent<HealthObject>().ChangeHealth(-20);
                Debug.Log("Damaged object " + collision.collider.gameObject.name + " for 20");
            }
        }
        Destroy(gameObject);
    }
}
