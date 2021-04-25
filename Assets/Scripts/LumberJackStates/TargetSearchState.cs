using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TargetSearchState : MonoBehaviour
{
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
        GetComponent<PlayerInput>().actions["Axe Swing"].canceled += TransitionToMovingState;
        GetComponentInChildren<TargetDetection>().GetComponent<SphereCollider>().enabled = true;
    }


    private void OnDisable()
    {
        GetComponent<PlayerInput>().actions["Axe Swing"].canceled -= TransitionToMovingState;
        GetComponentInChildren<TargetDetection>().GetComponent<SphereCollider>().enabled = false;
    }

    private void TransitionToMovingState(InputAction.CallbackContext ctx)
    {
        GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<MovingState>());
    }
}