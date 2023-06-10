using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorActiveSpell : MonoBehaviour 
    // I was going to call this ActiveSpellIndicator but in Unity the l and the I look too similar
{
    // Start is called before the first frame update

    public Material boltMaterial; // using placeholder materials for now
    public Material teleportMaterial;
    public Material telekinesisMaterial;
    public Material transparentMaterial;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setCurrentlyActiveSpell(string _spellName)
    {
        if (_spellName == "Magic Bolt")
        {
            gameObject.GetComponent<Renderer>().material = boltMaterial;
        } else if (_spellName == "Teleport")
        {
            gameObject.GetComponent<Renderer>().material = teleportMaterial;
        } else if( _spellName == "Telekinesis")
        {
            gameObject.GetComponent<Renderer>().material = telekinesisMaterial;
        } else
        {
            gameObject.GetComponent<Renderer>().material = transparentMaterial;
        }
    }
}
