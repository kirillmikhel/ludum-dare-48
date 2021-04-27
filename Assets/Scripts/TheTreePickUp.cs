using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
            var _transform = transform;

            _transform.SetParent(other.transform);
            _transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            _transform.localPosition = new Vector3(0, 0.4f, -1);
            _transform.localRotation = Quaternion.Euler(new Vector3(30, 11.45f, 0));
            GetComponent<NavMeshObstacle>().enabled = false;
            enabled = false;
        }
    }
}