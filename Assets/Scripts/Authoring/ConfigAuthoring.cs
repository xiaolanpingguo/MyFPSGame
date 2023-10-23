using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


public class GameConfigAuthoring : MonoBehaviour
{
    public float PlayerSpeed = 5;

    class Baker : Baker<GameConfigAuthoring>
    {
        public override void Bake(GameConfigAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new GameConfig
            {
                PlayerSpeed = authoring.PlayerSpeed,
            });
        }
    }
}
