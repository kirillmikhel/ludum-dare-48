using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTreePickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lumberjack"))
        {
            transform.SetParent(other.transform);
            transform.localPosition = Vector3.zero;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            enabled = false;
        }
    }
}
