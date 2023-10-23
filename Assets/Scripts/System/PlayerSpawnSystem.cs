using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;


[DisableAutoCreation]
public partial class PlayerSpawnSystem : GameSystemBase
{
    public PlayerSpawnSystem(GameWorld world) : base(world)
    {
    }

    protected override void OnCreate()
    {
        RequireForUpdate<PlayerSpawner>();
    }

    protected override void OnUpdate()
    {
        var entityManager = m_world.GetEntityManager();
        var prefab = SystemAPI.GetSingleton<PlayerSpawner>().Prefab;
        var entity = entityManager.Instantiate(prefab);

        var player = new Player();
        entityManager.AddComponentData(entity, player);
        entityManager.SetComponentData(entity, new LocalTransform
        {
            Position = 0,
            Rotation = quaternion.identity,
            Scale = 1
        });
        Enabled = false;
    }
}
