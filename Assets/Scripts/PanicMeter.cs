using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicMeter : MonoBehaviour
{
    public Slider slider;
    public GameObject woodHintGO;
    public GameObject panicAttackGO;
    public Image fillImage;
    public LumberjackData lumberjackData;
    public Text text;
    public Animator animator;
    private static readonly int TooMuchPanic = Animator.StringToHash("TooMuchPanic");

    // Start is called before the first frame update
    void Start()
    {
        slider.gameObject.SetActive(false);
        woodHintGO.SetActive(false);
        panicAttackGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lumberjackData.panic <= 0) return;

        // panicAttackGO.SetActive(lumberjackData.panic >= lumberjackData.panicLimit);
        woodHintGO.SetActive(true);
        slider.gameObject.SetActive(true);

        slider.value = lumberjackData.panic;

        var panicPercentage = (float) lumberjackData.panic / lumberjackData.panicLimit;

        fillImage.color = Color.Lerp(Color.grey, Color.red, panicPercentage);

        var tooMuchPanic = lumberjackData.panic > lumberjackData.panicLimit - 5;

        animator.SetBool(TooMuchPanic, tooMuchPanic);

        if (lumberjackData.isRelaxing)
        {
            text.text =
                $"Relaxing   ({lumberjackData.GetPanicRate()})";
            return;
        }

        if (panicPercentage >= 1.0f)
        {
            text.text = "Panic Attack!";
            return;
        }

        text.text = tooMuchPanic ? "Panicking..." : $"Fear intensifies   (+{lumberjackData.GetPanicRate()})";
    }
}