using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public interface IConnection
    {
        void CalculatePoints();
        void DisableEnergy();
        bool HasEnergy();
        void OnWin();
    }
}
