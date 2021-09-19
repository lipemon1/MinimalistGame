using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public interface IEnergyStart
    {
        void TryEmitEnergy();
        void CalculateEnergyPointsToConduct();
    }   
}
