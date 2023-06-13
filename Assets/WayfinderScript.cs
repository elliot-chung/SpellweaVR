using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayfinderScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] enemyList;
    private GameObject closest;

    [SerializeField]
    private Material activeMat;
    [SerializeField]
    private Material transparentMat;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClosest();
        if (closest != null) {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = activeMat;
            Vector3 closestDirection = closest.transform.position - gameObject.transform.position;
            gameObject.transform.up = closestDirection.normalized;
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = transparentMat;
        }
        
    }
    
    public void UpdateClosest()
    {
        float closestDistance = 100f;
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in enemyList)
        {
            float dist = Vector3.Distance(g.transform.position, gameObject.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = g;
            }
        }
        if (enemyList.Length == 0)
        {
            closest = null;
        }
    }


}
