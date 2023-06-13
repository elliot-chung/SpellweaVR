using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthObject : HealthObject
{
    [SerializeField]
    private GameObject HealthOrb;

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
        SceneManager.LoadScene("EndScreen");
    }

    public override void ChangeHealth(int val)
    {
        base.ChangeHealth(val);
        float healthScale = (currHealth * 1.0f / maxHealth) * 0.45f;
        HealthOrb.transform.localScale = new Vector3(healthScale, healthScale, healthScale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-20);
        }
    }
}
