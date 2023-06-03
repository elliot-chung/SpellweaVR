using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int maxHealth = 100;
    
    public int currHealth = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int val)
    {
        currHealth += val;
        if (currHealth < 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this);
    }
}
