using System;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public class ConnectionBehavior : MonoBehaviour, IConnection
    {
        [SerializeField] bool Interactable;
        [SerializeField] Animator Anim;

        bool hasEnergy;

        RotationBehavior rotationBehavior;
        EnergyFeedbackBehavior energyFeedbackBehavior;
        ConductorBehavior conductorBehavior;
        static readonly int Win = Animator.StringToHash("Win");

        void Awake()
        {
            rotationBehavior = GetComponent<RotationBehavior>();
            energyFeedbackBehavior = GetComponent<EnergyFeedbackBehavior>();
            conductorBehavior = GetComponent<ConductorBehavior>();

            if (Interactable)
            {
                rotationBehavior.ToggleComponent(true);
                energyFeedbackBehavior.ToggleComponent(true);
                conductorBehavior.ToggleComponent(true);
                
                ConnectionsObservable.RegisterConnections(this);   
            }
            else
            {
                rotationBehavior.ToggleComponent(false);
                energyFeedbackBehavior.ToggleComponent(false);
                conductorBehavior.ToggleComponent(false);
            }
        }

        public void MarkConnectionAsRotated()
        {
            ConnectionsObservable.ConnectionRotated(this);
        }

        public void EnableEnergy()
        {
            hasEnergy = true;
            energyFeedbackBehavior.SetEnergy(true);
        }
        
        public void DisableEnergy()
        {
            hasEnergy = false;
            energyFeedbackBehavior.SetEnergy(false);
        }

        public bool HasEnergy()
        {
            return hasEnergy;
        }

        public void OnWin()
        {
            Anim.SetTrigger(Win);
        }

        public void CalculatePoints()
        {
            conductorBehavior.CalculatePoints();
        }
    }
}
