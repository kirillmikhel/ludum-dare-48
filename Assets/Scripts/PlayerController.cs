using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LumberjackStateMachine>().TransitionTo(GetComponent<MovingState>());
    }

    // Update is called once per frame
    void Update()
    {
    }
}