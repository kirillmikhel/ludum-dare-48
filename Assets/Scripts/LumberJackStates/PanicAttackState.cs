using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PanicAttackState : MonoBehaviour
{
    public float panicAttackDuration = 3.0f;
    public PanicAttackEffect panicAttackEffect;
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

        GetComponentInChildren<Animator>().SetBool(IsPanicking, true);

        StartCoroutine(PanicAttackResolving());

        panicAttackEffect.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        GetComponentInChildren<Animator>().SetBool(IsPanicking, false);
        panicAttackEffect.gameObject.SetActive(false);
    }

    private IEnumerator PanicAttackResolving()
    {
        yield return new WaitForSeconds(panicAttackDuration);

        GetComponent<PanicSystem>().Resolve();

        _lumberjackStateMachine.TransitionTo(_movingState);
    }
}