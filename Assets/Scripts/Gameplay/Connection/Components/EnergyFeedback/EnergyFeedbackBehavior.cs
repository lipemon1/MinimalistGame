using System;
using System.Collections;
using System.Collections.Generic;
using MinimalGame.GameFlow;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public class EnergyFeedbackBehavior : ConnectionBaseComponent, IEnergyPoint
    {
        [SerializeField] Material noEnergyMaterial;
        [SerializeField] Material withEnergyMaterial;

        [SerializeField] MeshRenderer renderer;
        bool hasEnergy;

        void Start()
        {
            LevelEnderController.RegisterEnergyPoint(this);
        }

        public void SetEnergy(bool newValue)
        {
            hasEnergy = newValue;
            renderer.material = hasEnergy ? withEnergyMaterial : noEnergyMaterial;
        }

        public bool HasEnergy()
        {
            return hasEnergy;
        }
    }   
}