using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public interface IConnection
    {
        void EnableEnergy();
        void CalculatePoints();
        void DisableEnergy();
    }
}
