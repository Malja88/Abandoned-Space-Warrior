using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using static PauseTag;

public class PauseInputSystem : ComponentSystem
{
    private InputAction pauseAction;
    private float pauseInput;

    protected override void OnStartRunning()
    {
        pauseAction = new InputAction("pause", binding: "<Keyboard>/escape");
        pauseAction.performed += context => { pauseInput = context.ReadValue<float>(); };
        pauseAction.started += context => { pauseInput = context.ReadValue<float>(); };
        pauseAction.canceled += context => { pauseInput = context.ReadValue<float>(); };
        pauseAction.Enable();
    }
    protected override void OnStopRunning()
    {
        pauseAction.Disable();
    }
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref PauseData pauseData) =>
        {
            pauseData.Pause= pauseInput;
        });
    }

}
