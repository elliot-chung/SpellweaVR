using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOrigin : MonoBehaviour
{
    public Rigidbody MagicBoltPrefab;
    public LineRenderer TeleportSpellPrefab;

    private static Dictionary<List<int>, string> spellDictionary = new Dictionary<List<int>, string>(new ListEqualityComparator())
    {
        {new List<int>{5, 1, 2},  "Magic Bolt"},
        {new List<int>{2, 1, 5},  "Magic Bolt"},
        {new List<int>{4, 1, 3, 2},  "Teleport"},
        {new List<int>{2, 3, 1, 4},  "Teleport"},
        {new List<int>{1, 2, 3, 4, 5},  "Telekinesis"},
        {new List<int>{5, 4, 3, 2, 1},  "Telekinesis"},
    };

    private LineRenderer _teleIndicator;
    private string _spellName;
    private bool _spellActive;
    
    // Start is called before the first frame update
    void Start()
    {
        _spellName = "";
        _spellActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateCurrentSpell()
    {
        _spellActive = true;
        if (_spellName == "Magic Bolt")
        {

            Rigidbody bolt = Instantiate(MagicBoltPrefab, transform.position, Quaternion.identity);
            bolt.velocity = transform.forward;
        }
        else if (_spellName == "Teleport")
        {
            _teleIndicator = Instantiate(TeleportSpellPrefab, transform);
        }
        else if (_spellName == "Telekinesis")
        {

        }
    }

    private void DeactivateCurrentSpell()
    {
        _spellActive = false;
        if (_spellName == "Magic Bolt")
        {

        }
        else if (_spellName == "Teleport")
        {
            RaycastHit hit = _teleIndicator.GetComponent<SpellRaycast>().GetHitPosition();
            Destroy(_teleIndicator);
            Debug.Log("DESTORYING TP INDICATOR");
            Debug.Log(hit);
        }
        else if (_spellName == "Telekinesis")
        {

        }
    }

    public void SetSpell(List<int> spellCode)
    {
        _spellName = spellDictionary.GetValueOrDefault(spellCode, _spellName);
    }

    public void SetSpellActive(bool toggle)
    {   
        if (_spellActive == toggle) { return; }
        if (toggle) // Turning spell on
        {
            ActivateCurrentSpell();
        } else      // Turning spell off
        {
            DeactivateCurrentSpell();
        }
    }
}
