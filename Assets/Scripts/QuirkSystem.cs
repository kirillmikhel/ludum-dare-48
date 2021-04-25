using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuirkSystem : MonoBehaviour
{
    public float maxQuirkActivationPeriod = 10.0f;
    public float minimumQuirkActivationPeriod = 4.0f;
    public float quirkDuration = 3.0f;
    private LumberjackData _lumberjackData;

    // Start is called before the first frame update
    void Start()
    {
        _lumberjackData = GetComponent<LumberjackData>();

        StartCoroutine(ActivateRandomQuirk());
    }

    private IEnumerator ActivateRandomQuirk()
    {
        while (true)
        {
            // Reduce quirkActivationPeriod by amount of quirks
            // The more quirks, the sooner they trigger
            // But not sooner than quirk duration
            yield return new WaitForSeconds(Mathf.Max(maxQuirkActivationPeriod - _lumberjackData.quirks.Count,
                minimumQuirkActivationPeriod));

            var quirks = _lumberjackData.quirks;

            if (quirks.Count > 0)
            {
                _lumberjackData.activeQuirks.Add(quirks[Random.Range(0, quirks.Count - 1)]);

                StartCoroutine(ClearAllQuirks());
            }
        }
    }

    private IEnumerator ClearAllQuirks()
    {
        yield return new WaitForSeconds(quirkDuration);

        _lumberjackData.activeQuirks.Clear();
    }
}