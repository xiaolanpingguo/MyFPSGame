using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    private class Baker : Baker<PlayerSpawnerAuthoring>
    {
        public override void Bake(PlayerSpawnerAuthoring authoring)
        {
            var entity = GetEntity(authoring.gameObject, TransformUsageFlags.None);
            AddComponent(entity, new PlayerSpawner { Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic) });
        }
    }
}
