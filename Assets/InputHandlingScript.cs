using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlingScript : MonoBehaviour
{
    public GameObject leftHandAnchor;
    public GameObject rightHandAnchor;
    public GameObject centerEyeAnchor;

    public GameObject leftSpellOrigin;
    public GameObject rightSpellOrigin;

    public GameObject spellcastingRig;
    
    private GameObject currentSpellcastingRig;
    private List<int> leftSpellCode;
    private List<int> rightSpellCode;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            currentSpellcastingRig = Instantiate(spellcastingRig, rightHandAnchor.transform.position, rightHandAnchor.transform.rotation);
            currentSpellcastingRig.transform.forward = rightHandAnchor.transform.position - centerEyeAnchor.transform.position;
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            rightSpellCode = currentSpellcastingRig.GetComponent<SpellcastingScript>().ReleaseSpell();
            Destroy(currentSpellcastingRig);
            rightSpellOrigin.GetComponent<SpellOrigin>().SetSpell(rightSpellCode);
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            rightSpellOrigin.GetComponent<SpellOrigin>().SetSpellActive(true);
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            rightSpellOrigin.GetComponent<SpellOrigin>().SetSpellActive(false);
        }
    }
}
