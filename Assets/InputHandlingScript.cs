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
    
    private GameObject rightSpellCastingRig;
    private GameObject leftSpellCastingRig;
    private List<int> leftSpellCode;
    private List<int> rightSpellCode;


    const float SNAP_UPPER_THRESHOLD = 0.75f;
    const float SNAP_LOWER_THRESHOLD = 0.25f;
    private bool snapped;

    // Start is called before the first frame update
    void Start()
    {
        snapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Right Hand
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            rightSpellOrigin.GetComponent<SpellOrigin>().InitiateCasting();
            rightSpellCastingRig = Instantiate(spellcastingRig, rightHandAnchor.transform.position, rightHandAnchor.transform.rotation);
            rightSpellCastingRig.transform.Find("user_point").GetComponent<FollowTheGameObject>().whatToFollow = rightHandAnchor;
            rightSpellCastingRig.transform.forward = rightHandAnchor.transform.position - centerEyeAnchor.transform.position;
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            rightSpellCode = rightSpellCastingRig.GetComponent<SpellcastingScript>().ReleaseSpell();
            Destroy(rightSpellCastingRig);
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

        //Left Hand
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            leftSpellOrigin.GetComponent<SpellOrigin>().InitiateCasting();
            leftSpellCastingRig = Instantiate(spellcastingRig, leftHandAnchor.transform.position, leftHandAnchor.transform.rotation);
            leftSpellCastingRig.transform.Find("user_point").GetComponent<FollowTheGameObject>().whatToFollow = leftHandAnchor;
            leftSpellCastingRig.transform.forward = leftHandAnchor.transform.position - centerEyeAnchor.transform.position;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            leftSpellCode = leftSpellCastingRig.GetComponent<SpellcastingScript>().ReleaseSpell();
            Destroy(leftSpellCastingRig);
            leftSpellOrigin.GetComponent<SpellOrigin>().SetSpell(leftSpellCode);
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            leftSpellOrigin.GetComponent<SpellOrigin>().SetSpellActive(true);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            leftSpellOrigin.GetComponent<SpellOrigin>().SetSpellActive(false);
        }

        Vector2 rotDirection = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        if (rotDirection.x > SNAP_UPPER_THRESHOLD && !snapped)
        { // Right Stick
            snapped = true;
            GameObject.Find("PlayerCharacter").transform.Rotate(Vector3.up, 90);
        }
        else if (rotDirection.x < -1 * SNAP_UPPER_THRESHOLD && !snapped)
        {
            snapped = true;
            GameObject.Find("PlayerCharacter").transform.Rotate(Vector3.up, -90);
        }
        else if (snapped && rotDirection.x <= SNAP_LOWER_THRESHOLD && rotDirection.x >= -1 * SNAP_LOWER_THRESHOLD)
        {
            snapped = false;
        }
    }
}
