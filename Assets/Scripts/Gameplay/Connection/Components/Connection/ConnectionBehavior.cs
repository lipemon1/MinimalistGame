using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public class ConnectionBehavior : MonoBehaviour, IConnection
    {
        [SerializeField] bool Interactable;

        RotationBehavior rotationBehavior;
        EnergyFeedbackBehavior energyFeedbackBehavior;
        ConductorBehavior conductorBehavior;

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
            energyFeedbackBehavior.SetEnergy(true);
        }
        
        public void DisableEnergy()
        {
            energyFeedbackBehavior.SetEnergy(false);
        }

        public void CalculatePoints()
        {
            conductorBehavior.CalculatePoints();
        }
    }
}
