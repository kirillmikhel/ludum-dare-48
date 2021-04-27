using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class WoodCuttingState : MonoBehaviour
{
    public Tree target;
    private LumberjackData _lumberjackData;
    private static readonly int IsSwingingAxe = Animator.StringToHash("IsSwingingAxe");

    private void Awake()
    {
        enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _lumberjackData = GetComponent<LumberjackData>();
    }

    private void OnEnable()
    {
        GetComponent<PlayerInput>().actions["Axe Swing"].canceled += TransitionToMovingState;
        GetComponentInChildren<Animator>().SetBool(IsSwingingAxe, true);
    }


    private void OnDisable()
    {
        GetComponent<PlayerInput>().actions["Axe Swing"].canceled -= TransitionToMovingState;

        target = null;

        GetComponentInChildren<Animator>().SetBool(IsSwingingAxe, false);
    }

    private void Update()
    {
        if (_lumberjackData.activeQuirks.Contains(Quirk.TooScaredToMove))
        {
            GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<ScaredState>());
        }

        var transform1 = transform;
        var direction = target.transform.position - transform1.position;
        transform.rotation = Quaternion.Slerp(transform1.rotation, Quaternion.LookRotation(direction),
            _lumberjackData.rotationSpeed * Time.deltaTime);
    }

    private void TransitionToMovingState(InputAction.CallbackContext ctx)
    {
        GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<MovingState>());
    }

    public void TreeHit()
    {
        if (target == null) return;

        target.ReceiveDamage(_lumberjackData.GetAxeDamage());

        if (target.IsDead)
        {
            target = null;
            GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<TargetSearchState>());
        }
    }
}