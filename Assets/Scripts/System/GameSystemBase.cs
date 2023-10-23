using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public abstract partial class GameSystemBase : SystemBase
{
    protected readonly GameWorld m_world;

    protected GameSystemBase() { }
    protected GameSystemBase(GameWorld world)
    {
        m_world = world;
    }
}
