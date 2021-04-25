using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScaredState : MonoBehaviour
{
    private LumberjackData _lumberjackData;

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

        Debug.Log("So scary!");
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