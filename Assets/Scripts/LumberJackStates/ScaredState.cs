using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScaredState : MonoBehaviour
{
    private LumberjackData _lumberjackData;
    private static readonly int IsScared = Animator.StringToHash("IsScared");

    private void Awake()
    {
        enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        _lumberjackData = GetComponent<LumberjackData>();

        GetComponentInChildren<Animator>().SetBool(IsScared, true);
    }

    private void OnDisable()
    {
        GetComponentInChildren<Animator>().SetBool(IsScared, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_lumberjackData.activeQuirks.Contains(Quirk.TooScaredToMove))
        {
            GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<MovingState>());
        }
    }
}