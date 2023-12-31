using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;
using UnityEngine.InputSystem;
using System.Drawing.Printing;
using UnityEngine.Rendering.Universal;

[DisableAutoCreation]
public partial class PlayerInputSystem : GameSystemBase
{
    private PlayerInputActions m_playerInputActions;
    private float angleY;
    private float angleX;

    public PlayerInputSystem(GameWorld world) : base(world)
    {
        m_playerInputActions = new PlayerInputActions();
        m_playerInputActions.Enable();
        m_playerInputActions.Gameplay.Enable();
    }

    protected override void OnCreate()
    {
        RequireForUpdate<Player>();
    }

    protected override void OnUpdate()
    {
        var mainCamera = Camera.main;


        float2 inputMove = Vector2.ClampMagnitude(m_playerInputActions.Gameplay.Move.ReadValue<Vector2>(), 1f);
        float2 inputLook = m_playerInputActions.Gameplay.Look.ReadValue<Vector2>() * 2f;

        var config = SystemAPI.GetSingleton<GameConfig>();
        var playerSpeed = config.PlayerSpeed;

        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (transform, entity) in
                 SystemAPI.Query<RefRW<LocalTransform>>()
                 .WithAll<Player>()
                 .WithEntityAccess())
        {
            var characterController = m_world.GetEntityManager().GetComponentObject<CharacterController>(entity);

            // Move
            var move = new float3(inputMove.x, 0, inputMove.y);
            move = move * playerSpeed * deltaTime;
            transform.ValueRW.Position += move;
            characterController.Move(move);
            
            mainCamera.transform.position = transform.ValueRW.Position;

            // Look
            angleY = angleY + inputLook.x;
            transform.ValueRW = transform.ValueRW.RotateY(angleY);

            angleX = angleX + (-inputLook.y);
            angleX = Mathf.Clamp(angleX, -90f, 90f);
            mainCamera.transform.eulerAngles = new Vector3(angleX, angleY, mainCamera.transform.eulerAngles.z);
        }
    }
}
