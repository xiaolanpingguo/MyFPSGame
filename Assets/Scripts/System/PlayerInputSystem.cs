using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;


[DisableAutoCreation]
public partial class PlayerInputSystem : GameSystemBase
{
    public PlayerInputSystem(GameWorld world) : base(world)
    {

    }

    protected override void OnCreate()
    {
        RequireForUpdate<Player>();
    }

    protected override void OnUpdate()
    {
        var mainCamera = Camera.main;

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        horizontal = math.clamp(horizontal, -1, 1);
        vertical = math.clamp(vertical, -1, 1);

        var config = SystemAPI.GetSingleton<GameConfig>();
        var playerSpeed = config.PlayerSpeed;

        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var transform in
                 SystemAPI.Query<RefRW<LocalTransform>>()
                 .WithAll<Player>())
        {
            var move = new float3(horizontal, 0, vertical);
            move = move * playerSpeed * deltaTime;
            transform.ValueRW.Position += move;

            mainCamera.transform.position = transform.ValueRW.Position;
            mainCamera.transform.rotation = transform.ValueRW.Rotation;
        }
    }
}
