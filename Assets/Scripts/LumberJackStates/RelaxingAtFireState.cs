using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RelaxingAtFireState : MonoBehaviour
{
    public GameObject bonfirePrefab;
    private GameObject bonfireInstance;

    private void Awake()
    {
        enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        GetComponent<LumberjackData>().isRelaxing = true;
        GetComponent<PlayerInput>().actions["Stop Relaxing"].performed += StopRelaxing;

        bonfireInstance = Instantiate(bonfirePrefab, transform);
        bonfireInstance.transform.localPosition = new Vector3(0, -0.5f, 2.0f);
    }

    private void OnDisable()
    {
        GetComponent<LumberjackData>().isRelaxing = false;
        GetComponent<PlayerInput>().actions["Stop Relaxing"].performed -= StopRelaxing;

        Destroy(bonfireInstance);
    }

    private void StopRelaxing(InputAction.CallbackContext ctx)
    {
        GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<MovingState>());
    }

    // Update is called once per frame
    void Update()
    {
    }
}