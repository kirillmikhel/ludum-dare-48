using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDepthVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lumberjack"))
        {
            other.GetComponent<LumberjackData>().IncreaseForestDepth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lumberjack"))
        {
            other.GetComponent<LumberjackData>().DecreaseForestDepth();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
    }
}