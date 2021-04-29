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
        text.text = lumberjackData.quirks.GroupBy(q => q)
            .Select(g => new {name = g.Key, amount = g.Count()})
            .Aggregate("",
                (s, quirk) =>
                    $"{s}\n<color={GetTextColor(quirk.name)}>{quirk.name.ToReadableString()}{GetAmountSubstring(quirk.amount)}</color>")
            .Trim();
    }

    private string GetTextColor(Quirk quirk)
    {
        return lumberjackData.activeQuirks.Contains(quirk) ? "red" : "grey";
    }

    private string GetAmountSubstring(int amount)
    {
        return amount > 1 ? $" x{amount}" : "";
    }
}