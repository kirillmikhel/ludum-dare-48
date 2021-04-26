using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PanicAttackState : MonoBehaviour
{
    public float overcomingSuccessRate = 0.25f;
    public float panicAttackDuration = 2.0f;
    public float overcomingDuration = 5.0f;
    private LumberjackStateMachine _lumberjackStateMachine;
    private LumberjackData _lumberjackData;
    private MovingState _movingState;
    private static readonly int IsPanicking = Animator.StringToHash("IsPanicking");

    private void Awake()
    {
        enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _movingState = GetComponent<MovingState>();
        _lumberjackStateMachine = GetComponent<LumberjackStateMachine>();
    }

    private void OnEnable()
    {
        _lumberjackData = GetComponent<LumberjackData>();
        _lumberjackData.panic = _lumberjackData.panicLimit / 2;
        
        GetComponentInChildren<Animator>().SetBool(IsPanicking, true);

        StartCoroutine(PanicAttackResolving());
    }

    private void OnDisable()
    {
        GetComponentInChildren<Animator>().SetBool(IsPanicking, false);
    }

    private IEnumerator PanicAttackResolving()
    {
        Debug.Log("shaking and screaming...");

        yield return new WaitForSeconds(panicAttackDuration);

        var hasOvercome = Random.value < overcomingSuccessRate;

        Debug.Log(hasOvercome ? "Overcoming" : "Quirk");

        if (hasOvercome)
        {
            _lumberjackData.overcomings.Add(Overcoming.InstantTreeCutting);
            StartCoroutine(ClearAllOvercomings());
        }
        else
        {
            _lumberjackData.quirks.Add(Quirk.TooScaredToMove);
        }

        _lumberjackStateMachine.TransitionTo(_movingState);
    }

    private IEnumerator ClearAllOvercomings()
    {
        yield return new WaitForSeconds(overcomingDuration);
        
        _lumberjackData.overcomings.Clear();
    }

    // Update is called once per frame
    void Update()
    {
    }
}