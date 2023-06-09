using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportSpellScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool InitiateTeleport(out Vector3 pos)
    {
        RaycastHit rayHit = GetComponent<SpellRaycast>().GetHitPosition();
        
        if (rayHit.distance == 50) {
            pos = Vector3.zero;
            return false; 
        }
        NavMeshHit navHit;
        if (NavMesh.SamplePosition(rayHit.point, out navHit, 1.0f, NavMesh.AllAreas))
        {
            pos = navHit.position;
            return true;
        }
        pos = Vector3.zero;
        return false;
    }
}
