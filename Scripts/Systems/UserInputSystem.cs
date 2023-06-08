using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UserInputData;

public class UserInputSystem : ComponentSystem
{
    private EntityQuery inputQuery;
    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction reloadAction;
    private float2 moveInput;
    private float shootInput;
    private float reloadInput;
    protected override void OnCreate()
    {
        inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }
    protected override void OnStartRunning()
    {
        moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");
        moveAction.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        moveAction.performed += context => {moveInput =context.ReadValue<Vector2>();};
        moveAction.started += context => { moveInput = context.ReadValue<Vector2>(); };
        moveAction.canceled += context => { moveInput = context.ReadValue<Vector2>(); };
        moveAction.Enable();

        shootAction = new InputAction("shoot", binding: "<Mouse>/leftButton");
        shootAction.performed += context => { shootInput = context.ReadValue<float>();};
        shootAction.started += context => { shootInput = context.ReadValue<float>(); };
        shootAction.canceled += context => { shootInput = context.ReadValue<float>(); };
        shootAction.Enable();

        reloadAction = new InputAction("reload", binding: "<Mouse>/rightButton");
        reloadAction.performed += context => { reloadInput = context.ReadValue<float>(); };
        reloadAction.started += context => { reloadInput = context.ReadValue<float>(); };
        reloadAction.canceled += context => { reloadInput = context.ReadValue<float>(); };
        reloadAction.Enable();
    }
    protected override void OnStopRunning()
    {
        moveAction.Disable();   
        shootAction.Disable();
        reloadAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(inputQuery).ForEach((Entity entity, ref InputData inputData) => 
        {
            inputData.Move = moveInput;
            inputData.Shoot= shootInput;
            inputData.Reload= reloadInput;
        });
    }
}
