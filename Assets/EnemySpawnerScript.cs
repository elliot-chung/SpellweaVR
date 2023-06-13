using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float spawnTimer;
    private float spawnInterval;

    [SerializeReference]
    private GameObject enemyObject;
    void Start()
    {
        spawnInterval = (4 - PlayerPrefs.GetInt("difficulty")) * 5;
        spawnTimer = spawnInterval;
        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        } else
        {
            spawnTimer = spawnInterval;
            Instantiate(enemyObject, new Vector3((Random.value - 0.5f) * 35f, 1.5f, (Random.value - 0.5f) * 35f), gameObject.transform.rotation);
        }
    }
}
