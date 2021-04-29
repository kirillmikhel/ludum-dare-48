using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActiveEffectsUI : MonoBehaviour
{
    public LumberjackData lumberjackData;
    public Text text;

    void Update()
    {
        text.text = $"{GetOvercomings()}{GetActiveQuirks()}".Trim();
    }

    private string GetActiveQuirks()
    {
        return lumberjackData.activeQuirks
            .Aggregate("", (s, quirk) => $"{s}\n<color=red>{quirk.ToReadableString()}</color>");
    }

    private string GetOvercomings()
    {
        return lumberjackData.overcomings
            .Aggregate("", (s, overcoming) => $"{s}\n{overcoming.ToReadableString()}");
    }
}