using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMG.UnitSelection
{
    [Flags]
    public enum CollisionLayers
    {
        Player = 1 << 0,
        Floor = 1 << 1,
        Obstacle = 1 << 2,
        Ray = 1 << 3,
        RayShoot = 1 << 8,
        Enemy = 1 << 9,
        Bullet = 1 << 10,
    }
}
