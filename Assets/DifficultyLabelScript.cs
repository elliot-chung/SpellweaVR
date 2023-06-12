using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyLabelScript : MonoBehaviour
{
    private TextMeshProUGUI textbox;
    private void Start()
    {
        textbox = GetComponent<TextMeshProUGUI>();
    }
    public void SetDifficultyLevel(System.Single level)
    {
        if (level == 1)
        {
            textbox.text = "Difficulty: Easy";
        }
        else if (level == 2)
        {
            textbox.text = "Difficulty: Medium";
        }
        else if (level == 3)
        {
            textbox.text = "Difficulty: Hard";
        }
    }
}
