using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicMeter : MonoBehaviour
{
    public Slider slider;
    public LumberjackData lumberjackData;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = lumberjackData.panic;
    }
}
