using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOrigin : MonoBehaviour
{
    public Rigidbody MagicBoltPrefab;
    private static Dictionary<List<int>, string> spellDictionary = new Dictionary<List<int>, string>(new ListEqualityComparator())
    {
        {new List<int>{5, 1, 2},  "Magic Bolt"},
        {new List<int>{2, 1, 5},  "Magic Bolt"},
        {new List<int>{4, 1, 3, 2},  "Teleport"},
        {new List<int>{2, 3, 1, 4},  "Teleport"},
        {new List<int>{1, 2, 3, 4, 5},  "Telekinesis"},
        {new List<int>{5, 4, 3, 2, 1},  "Telekinesis"},
    };

    private string spellName;
    private bool spellActive;
    
    // Start is called before the first frame update
    void Start()
    {
        spellName = "";
        spellActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateCurrentSpell()
    {
        if (spellName == "Magic Bolt")
        {

            Rigidbody bolt = Instantiate(MagicBoltPrefab, transform.position, Quaternion.identity);
            bolt.velocity = transform.forward;
        }
        else if (spellName == "Teleport")
        {

        }
        else if (spellName == "Telekinesis")
        {

        }
    }

    private void DeactivateCurrentSpell()
    {
        if (spellName == "Magic Bolt")
        {

        }
        else if (spellName == "Teleport")
        {

        }
        else if (spellName == "Telekinesis")
        {

        }
    }

    public void SetSpell(List<int> spellCode)
    {
        spellName = spellDictionary.GetValueOrDefault(spellCode, spellName);
    }

    public void SetSpellActive(bool toggle)
    {   
        if (spellActive == toggle) { return; }
        if (toggle) // Turning spell on
        {
            ActivateCurrentSpell();
        } else      // Turning spell off
        {
            DeactivateCurrentSpell();
        }
    }
}
