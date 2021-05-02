using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using UnityEngine;
using Random = UnityEngine.Random;

public class PanicSystem : MonoBehaviour
{
    public float tick = 2.0f;
    public float overcomingSuccessRate = 0.25f;
    public float overcomingDuration = 10.0f;
    public SplashUI overcomingSplash;
    public SplashUI quirkSplash;
    public StudioEventEmitter panicEventEmitter;
    public StudioEventEmitter overcomingEventEmitter;
    public StudioEventEmitter quirkEventEmitter;
    private Coroutine _growingPanic;
    private LumberjackData _lumberjackData;

    private readonly Overcoming[] _possibleOvercomings =
    {
        Overcoming.InstantTreeCutting,
        Overcoming.DoubleSpeed,
    };

    private readonly Quirk[] _possibleQuirks =
    {
        Quirk.Weak,
        Quirk.CanNotUseBonfire,
        Quirk.TooScaredToMove,
    };

    // Start is called before the first frame update
    void Start()
    {
        _lumberjackData = GetComponent<LumberjackData>();
        _growingPanic = StartCoroutine(GrowingPanic());
    }

    private IEnumerator GrowingPanic()
    {
        while (true)
        {
            yield return new WaitForSeconds(tick);

            _lumberjackData.panic = Mathf.Max(0, _lumberjackData.panic + _lumberjackData.GetPanicRate());

            if (_lumberjackData.panic < 95)
            {
                panicEventEmitter.SetParameter("Panic", 0);
            }

            if (_lumberjackData.panic > 95)
            {
                panicEventEmitter.SetParameter("Panic", 1);
            }

            if (_lumberjackData.panic >= _lumberjackData.panicLimit)
            {
                panicEventEmitter.SetParameter("Panic", 2);

                var panicAttackState = _lumberjackData.GetComponent<PanicAttackState>();

                _lumberjackData.GetComponent<LumberjackStateMachine>().TransitionTo(panicAttackState);

                yield return new WaitForSeconds(panicAttackState.panicAttackDuration);
            }
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_growingPanic);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Resolve()
    {
        var hasOvercome = Random.value < overcomingSuccessRate;

        panicEventEmitter.SetParameter("Panic", 0);

        if (hasOvercome)
        {
            var overcoming = _possibleOvercomings[Random.Range(0, _possibleOvercomings.Length)];

            _lumberjackData.overcomings.Add(overcoming);

            overcomingSplash.Show(overcoming.ToReadableString());

            overcomingEventEmitter.Play();

            StartCoroutine(ClearAllOvercomings());
        }
        else
        {
            var quirk = _possibleQuirks[Random.Range(0, _possibleQuirks.Length)];

            _lumberjackData.quirks.Add(quirk);

            quirkEventEmitter.Play();

            quirkSplash.Show(quirk.ToReadableString());
        }

        _lumberjackData.panic = _lumberjackData.panicLimit / 2;
    }

    private IEnumerator ClearAllOvercomings()
    {
        yield return new WaitForSeconds(overcomingDuration);

        _lumberjackData.overcomings.Clear();
    }
}