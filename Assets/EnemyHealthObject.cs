using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthObject : HealthObject 
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimationFrame();
    }

    public override void Die()
    {
        PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") + 1);
        base.Die();
    }

}

