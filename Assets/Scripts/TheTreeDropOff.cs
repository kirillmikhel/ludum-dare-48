using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheTreeDropOff : MonoBehaviour
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
        if (other.CompareTag("The Tree"))
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.zero;
            enabled = false;

            SceneManager.LoadScene("Victory");
        }
    }
}
