using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicSystem : MonoBehaviour
{
    public float tick = 2.0f;
    private Coroutine _growingPanic;
    private LumberjackData _lumberjackData;

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

            if (_lumberjackData.panic >= _lumberjackData.panicLimit)
            {
                var panicAttackState = _lumberjackData.GetComponent<PanicAttackState>();

                _lumberjackData.GetComponent<LumberjackStateMachine>().TransitionTo(panicAttackState);

                yield return new WaitForSeconds(panicAttackState.panicAttackDuration);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}