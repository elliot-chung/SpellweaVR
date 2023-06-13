using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardButtonScript : MonoBehaviour
{
    private GameObject displayObject;
    // Start is called before the first frame update
    void Start()
    {
        displayObject = GameObject.Find("MainDisplay");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;
    }

    public void keyClicked()
    {
        displayObject.GetComponent<KeyboardDisplayScript>().keyStroke(gameObject.name);
    }
}
