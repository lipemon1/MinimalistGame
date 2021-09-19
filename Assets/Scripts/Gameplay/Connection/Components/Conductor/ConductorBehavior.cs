using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public class ConductorBehavior : ConnectionBaseComponent
    {
        public ConductorPointBehavior TopConductor;
        public ConductorPointBehavior BottomConductor;

        public void ReceiveEnergyFromPoint(ConductorPointBehavior conductorPointBehavior)
        {
            ConnectionBehavior.EnableEnergy();
            
            if(conductorPointBehavior.gameObject.GetInstanceID() == TopConductor.gameObject.GetInstanceID())
                BottomConductor.ReceiveEnergyFromPipe();
            else
                TopConductor.ReceiveEnergyFromPipe();
        }

        public void CalculatePoints()
        {
            TopConductor.CalculatePoint();
            BottomConductor.CalculatePoint();
        }
    }   
}