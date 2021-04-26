using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MovingState : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private Camera _camera;

    private LumberjackData _lumberjackData;
    private PlayerInput _playerInput;
    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _lumberjackData = GetComponent<LumberjackData>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        GetComponent<PlayerInput>().actions["Axe Swing"].started += StartTargetSearch;
        GetComponent<PlayerInput>().actions["Start Relaxing"].performed += StartRelaxing;
    }

    private void OnDisable()
    {
        GetComponent<PlayerInput>().actions["Axe Swing"].started -= StartTargetSearch;
        GetComponent<PlayerInput>().actions["Start Relaxing"].performed -= StartRelaxing;

        GetComponentInChildren<Animator>().SetFloat(Speed, 0);
    }

    private void StartRelaxing(InputAction.CallbackContext obj)
    {
        if (_lumberjackData.IsCarryingTheTree()) return;
        if (!_lumberjackData.HasEnoughWood()) return;

        _lumberjackData.wood -= _lumberjackData.woodRequiredForFire;

        GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<RelaxingAtFireState>());
    }

    private void StartTargetSearch(InputAction.CallbackContext ctx)
    {
        if (_lumberjackData.IsCarryingTheTree()) return;

        GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<TargetSearchState>());
    }

    void Update()
    {
        Move();

        if (_lumberjackData.activeQuirks.Contains(Quirk.TooScaredToMove))
        {
            GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<ScaredState>());
        }
    }

    private void Move()
    {
        var cameraRotation = Quaternion.AngleAxis(_camera.transform.rotation.eulerAngles.y, Vector3.up);

        var inputDirection = _playerInput.actions["Move"].ReadValue<Vector2>();

        var direction = cameraRotation * new Vector3(inputDirection.x, 0, inputDirection.y).normalized;

        if (direction.sqrMagnitude > 0)
        {
            _navMeshAgent.Move(direction * (_lumberjackData.speed * Time.deltaTime));

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                _lumberjackData.rotationSpeed * Time.deltaTime);
        }

        _animator.SetFloat(Speed, direction.sqrMagnitude);
    }
}