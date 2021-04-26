using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToHand : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        var _transform = transform;

        _transform.parent = target;
        _transform.localPosition = Vector3.zero;
        _transform.localRotation = Quaternion.Euler(new Vector3(1.20326221f, 264.349884f, 266.515564f));
    }
}