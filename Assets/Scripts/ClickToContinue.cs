using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour
{
    public InputAction clickAction;

    private void OnEnable()
    {
        clickAction.Enable();
        clickAction.performed += NextScene;
    }

    private void OnDisable()
    {
        clickAction.Disable();
        clickAction.performed -= NextScene;
    }

    public void NextScene(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}