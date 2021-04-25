using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGoal : MonoBehaviour
{
    public LumberjackData lumberjackData;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var theTree = lumberjackData.transform.Find("The Tree");

        text.text = theTree == null ? "Find the Legendary Tree" : "Get the Tree back home";
    }
}