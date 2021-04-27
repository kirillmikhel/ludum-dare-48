using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class WoodCuttingState : MonoBehaviour
{
    public Tree target;
    private LumberjackData _lumberjackData;
    private Coroutine _cuttingCoroutine;
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
        // _cuttingCoroutine = StartCoroutine(Cutting());

        var direction = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z).normalized);
        
        GetComponentInChildren<Animator>().SetBool(IsSwingingAxe, true);
    }


    private void OnDisable()
    {
        GetComponent<PlayerInput>().actions["Axe Swing"].canceled -= TransitionToMovingState;

        if (_cuttingCoroutine != null)
        {
            StopCoroutine(_cuttingCoroutine);
        }

        target = null;
        
        GetComponentInChildren<Animator>().SetBool(IsSwingingAxe, false);
    }

    private void Update()
    {
        if (_lumberjackData.activeQuirks.Contains(Quirk.TooScaredToMove))
        {
            GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<ScaredState>());
        }
    }

    private void TransitionToMovingState(InputAction.CallbackContext ctx)
    {
        GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<MovingState>());
    }

    public void TreeHit()
    {
        if (target == null) return;
        
        target.ReceiveDamage(_lumberjackData.GetAxeDamage());
    }

    private IEnumerator Cutting()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            target.ReceiveDamage(_lumberjackData.GetAxeDamage());

            if (target.IsDead)
            {
                target = null;
                GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<MovingState>());
            }
        }
    }
}