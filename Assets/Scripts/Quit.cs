using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    [SerializeField] private InputAction quitAction;

    private void Start()
    {
        quitAction.performed += HandleQuit;
    }

    private void OnEnable()
    {
        quitAction.Enable();
    }

    private void OnDisable()
    {
        quitAction.Disable();
    }

    private static void HandleQuit(InputAction.CallbackContext ctx)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}