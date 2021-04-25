using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateMachine : MonoBehaviour
{
    public MonoBehaviour currentState;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TransitionTo(MonoBehaviour newState)
    {
        if (currentState is { })
        {
            currentState.enabled = false;

        }

        newState.enabled = true;

        currentState = newState;
    }
}