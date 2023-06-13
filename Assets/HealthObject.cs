using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    private bool justHit = false;
    private float hitAnimationTimer;

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

    public void CheckAnimationFrame()
    {
        Material mat = GetComponent<Renderer>().material;
        if (justHit)
        {
            hitAnimationTimer = 0.3f;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.red * hitAnimationTimer * 4);
            justHit = false;
        }

        if (hitAnimationTimer > 0)
        {
            hitAnimationTimer -= Time.deltaTime;
            mat.SetColor("_EmissionColor", Color.red * hitAnimationTimer * 4);
        }

        if (hitAnimationTimer < 0)
        {
            mat.DisableKeyword("_EMISSION");
        }
    }

    public virtual void ChangeHealth(int val)
    {
        justHit = true;
        currHealth += val;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
