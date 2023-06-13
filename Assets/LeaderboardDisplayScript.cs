using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class LeaderboardDisplayScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Entries;

    [SerializeField]
    private GameObject LeaderboardLine;

    private Dictionary<string, int> leaderboard;
    // Start is called before the first frame update
    void Start()
    {
        leaderboard = decodeLeaderboardString(PlayerPrefs.GetString("Leaderboard"));
        var sorted_leaderboard = from entry in leaderboard orderby entry.Value descending select entry;

        int i = 1;
        foreach (KeyValuePair<string, int> entry in sorted_leaderboard)
        {
            GameObject leaderboardEntry = Instantiate(LeaderboardLine, Entries.transform);
            leaderboardEntry.transform.Find("NumericLabel").GetComponent<TMP_Text>().text = i.ToString() + ". ";
            leaderboardEntry.transform.Find("Name").GetComponent<TMP_Text>().text = entry.Key;
            leaderboardEntry.transform.Find("Score").GetComponent<TMP_Text>().text = entry.Value.ToString("D3");
            i++;
            if (i > 8) break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool addToLeaderboard(string player, int score)
    {
        leaderboard = decodeLeaderboardString(PlayerPrefs.GetString("Leaderboard"));
        if (leaderboard.ContainsKey(player)) return false;
        leaderboard.Add(player, score);
        PlayerPrefs.SetString("Leaderboard", encodeLeaderboard(leaderboard));
        return true;
    }

    Dictionary<string, int> decodeLeaderboardString(string s)
    {
        Dictionary<string, int> d = new Dictionary<string, int>();

        if (s.Length > 0)
        {
            var pairs = s.Split(';');
            foreach (var pair in pairs)
            {
                if (!string.IsNullOrEmpty(pair))
                {
                    var keyValue = pair.Split(':');
                    d.Add(keyValue[0], int.Parse(keyValue[1]));
                }
            }
        }
        
        return d;
    }

    string encodeLeaderboard(Dictionary<string, int> d)
    {
        StringBuilder output = new StringBuilder();

        foreach (KeyValuePair<string, int> entry in d)
        {
            output.Append(entry.Key + ":" + entry.Value.ToString() + ";");
        }

        return output.ToString();
    }
}
