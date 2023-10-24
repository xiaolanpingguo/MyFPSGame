using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CharacterModule
{
    protected readonly GameWorld m_world;

    private PlayerSpawnSystem m_playerSpawnSystem;
    private PlayerInputSystem m_playerInputSystem;

    public CharacterModule(GameWorld world)
    {
        m_world = world;
        World ecsWorld = m_world.GetECSWorld();

        m_playerSpawnSystem = ecsWorld.AddSystemManaged(new PlayerSpawnSystem(m_world));
        m_playerInputSystem = ecsWorld.AddSystemManaged(new PlayerInputSystem(m_world));
    }

    public void Update()
    {
        m_playerSpawnSystem.Update();
        m_playerInputSystem.Update();
    }
}
