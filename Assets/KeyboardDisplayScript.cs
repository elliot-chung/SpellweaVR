using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyboardDisplayScript : MonoBehaviour
{
    bool nameExists;
    string message;
    // Start is called before the first frame update
    void Start()
    {
        message = "";
        nameExists = false;
    }

    // Update is called once per frame
    void Update()
    {
        string text = "";
        if (nameExists) {
            text = "Name Already Exists, Try Another";
        } else
        {
            text = "Enter name: " + message + "|";
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = text; 
    }

    public void keyStroke(string s)
    {
        if (nameExists)
        {
            nameExists = false;
        }
        message += s;
    }

    public void bksp()
    {
        message = message.Substring(0, message.Length - 1);
    }

    public void space()
    {
        message += " ";
    }

    public void submit()
    {
        LeaderboardDisplayScript controls = GameObject.Find("LeaderboardDisplay").GetComponent<LeaderboardDisplayScript>();
        if (controls.addToLeaderboard(message, PlayerPrefs.GetInt("CurrentScore"))) {
            SceneManager.LoadScene("MenuScene");
        } else
        {
            message = "";
            nameExists = true;
        }
    }
}
