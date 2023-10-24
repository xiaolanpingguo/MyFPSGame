using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public struct SpawnPlayerRequest : IComponentData
{
    public FixedString64Bytes Name;
    public int Id;
}
