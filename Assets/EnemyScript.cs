using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float approachSpeed;

    private GameObject player;

    private float knockbackTimer = 0.0f;

    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = (player.transform.position - gameObject.transform.position).normalized * Time.deltaTime;
        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
            offset = -offset * 5.0f;
        }
        if (knockbackTimer <= 0)
        {
            offset = offset * approachSpeed;
        }

        GetComponent<Rigidbody>().MovePosition(transform.position + offset);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            knockbackTimer = 0.1f;
        }
    }
}
