using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public class EnergyFeedbackBehavior : ConnectionBaseComponent
    {
        [SerializeField] Material noEnergyMaterial;
        [SerializeField] Material withEnergyMaterial;

        [SerializeField] MeshRenderer renderer;
        
        public void SetEnergy(bool newValue)
        {
            renderer.material = newValue ? withEnergyMaterial : noEnergyMaterial;
        }
    }   
}