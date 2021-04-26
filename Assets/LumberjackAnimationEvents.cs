using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackAnimationEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TreeHit()
    {
        GetComponentInParent<WoodCuttingState>().TreeHit();
    }
}
