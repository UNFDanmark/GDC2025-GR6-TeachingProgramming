using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AIEyes : MonoBehaviour
{
    bool hitsomething;
    public bool seesPlayer;

    RaycastHit hit;

    public float sightDistance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitsomething = Physics.Raycast(transform.position, transform.forward, out hit, sightDistance);
        seesPlayer = false;
        if (hitsomething)
        {
            if (hit.transform.CompareTag("Player"))
            {

                seesPlayer = true;
            }

        }
    }

    void OnDrawGizmos()
    {
        if (hitsomething && hit.transform.CompareTag("Player"))
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position,transform.forward*sightDistance);
    }
}

