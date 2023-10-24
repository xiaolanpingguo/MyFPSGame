using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Playables;

public struct Player : IComponentData
{
    public float Horizontal;
    public float Vertical;
}

public struct PlayerSpawner : IComponentData
{
    public Entity Prefab;
}

public struct PlayerInput : IComponentData
{
    public float Horizontal;
    public float Vertical;
}
