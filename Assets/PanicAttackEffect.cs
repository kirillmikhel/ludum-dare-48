using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PanicAttackEffect : MonoBehaviour
{
    public float timeMod = 2.0f;
    public float rangeMod = 0.10f;

    private ChromaticAberration chromaticAberration;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Volume>().profile.TryGet(typeof(ChromaticAberration), out chromaticAberration);
    }

    // Update is called once per frame
    void Update()
    {
        chromaticAberration.intensity.value = Mathf.Sin(Time.realtimeSinceStartup * timeMod) + rangeMod;
    }
}