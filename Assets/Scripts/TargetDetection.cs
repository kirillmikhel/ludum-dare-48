using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            var lumberjack = transform.parent;

            lumberjack.GetComponent<WoodCuttingState>().target = other.GetComponentInParent<Tree>();
            lumberjack.GetComponent<LumberjackStateMachine>().TransitionTo(GetComponentInParent<WoodCuttingState>());
        }
    }
}