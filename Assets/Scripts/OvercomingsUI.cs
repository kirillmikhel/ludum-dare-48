using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OvercomingsUI : MonoBehaviour
{
    public LumberjackData lumberjackData;
    public Text text;

    void Update()
    {
        text.text = lumberjackData.overcomings.Aggregate("", (s, overcoming) => $"{s}\n{overcoming}").Trim();
    }
}