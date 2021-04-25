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
        text.text = lumberjackData.wood >= lumberjackData.woodRequiredForFire
            ? $"Wood (ready!): {lumberjackData.wood}/{lumberjackData.woodRequiredForFire}"
            : $"Wood (to make fire): {lumberjackData.wood}/{lumberjackData.woodRequiredForFire}";
    }
}