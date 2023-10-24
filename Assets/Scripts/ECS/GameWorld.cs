using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Entities;
using UnityEngine;

public class GameWorld
{
    private readonly World m_ECSWorld;
    private EntityManager m_EntityManager;

    public int TickRate;
    public float TickInterval;

    public GameWorld(World world, int tickrate)
    {
        m_ECSWorld = world;
        TickRate = tickrate;
        TickInterval = 1.0f / TickRate;
        m_EntityManager = world.EntityManager;
    }

    public static GameWorld CreateMainGameplayWorld(int tickrate)
    {
        GameWorld world = new GameWorld(World.DefaultGameObjectInjectionWorld, tickrate);
        return world;
    }

    public EntityManager GetEntityManager()
    {
        return m_EntityManager;
    }

    public World GetECSWorld()
    {
        return m_ECSWorld;
    }
}
