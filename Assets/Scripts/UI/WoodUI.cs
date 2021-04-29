using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WoodUI : MonoBehaviour
{
    public LumberjackData lumberjackData;
    public Text text;

    private void Update()
    {
        if (lumberjackData.isRelaxing)
        {
            text.text = "Press F to stop resting";
            return;
        }

        text.text = lumberjackData.wood >= lumberjackData.woodRequiredForFire
            ? "Press F to set up a bonfire"
            : $"Wood: {lumberjackData.wood}/{lumberjackData.woodRequiredForFire}";
    }
}