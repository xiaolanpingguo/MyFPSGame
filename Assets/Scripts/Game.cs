using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameWorld m_world;
    private CharacterModule m_characterModule;

    // Start is called before the first frame update
    void Start()
    {
        m_world = GameWorld.CreateMainGameplayWorld(60);
        m_characterModule = new CharacterModule(m_world);
    }

    // Update is called once per frame
    void Update()
    {
        m_characterModule.Update();
    }
}
