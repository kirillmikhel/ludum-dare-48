using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class LumberjackAnimationEvents : MonoBehaviour
{
    public StudioEventEmitter footstepsEventEmitter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TreeHit()
    {
        GetComponentInParent<WoodCuttingState>().TreeHit();
    }

    public void Footstep()
    {
        footstepsEventEmitter.Play();
    }
}
