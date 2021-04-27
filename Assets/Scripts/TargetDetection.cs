using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    private readonly HashSet<GameObject> _treesAround = new HashSet<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _treesAround.Add(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_treesAround.Count <= 0) return;

        var closestTree = _treesAround.OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).First();

        var lumberjack = transform.parent;

        lumberjack.GetComponent<WoodCuttingState>().target = closestTree.GetComponentInParent<Tree>();
        lumberjack.GetComponent<LumberjackStateMachine>().TransitionTo(GetComponentInParent<WoodCuttingState>());

        _treesAround.Clear();
    }
}