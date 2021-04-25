using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuirksUI : MonoBehaviour
{
    public LumberjackData lumberjackData;
    public Text text;

    void Update()
    {
        text.text = lumberjackData.quirks.Aggregate("",
            (s, quirk) => $"{s}\n<color={GetTextColor(quirk)}>{quirk}</color>"
            ).Trim();
    }

    private string GetTextColor(Quirk quirk)
    {
        return lumberjackData.activeQuirks.Contains(quirk) ? "red" : "grey";
    }
}