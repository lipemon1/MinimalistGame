using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MinimalGame.Gameplay.Connections
{
    public class EnergyPointBehavior : MonoBehaviour, IEnergyStart
    {
        public SphereCollider EnergyPointCollider;
        [SerializeField] List<Collider> colliders = new List<Collider>();
        [SerializeField] List<ConductorPointBehavior> pointsToConduct = new List<ConductorPointBehavior>();
        [SerializeField] Animator Anim;
        static readonly int Win = Animator.StringToHash("Win");

        void Awake()
        {
            ConnectionsObservable.RegisterEnergyPoints(this);
        }

        public void TryEmitEnergy()
        {
            if (pointsToConduct.Count > 0)
            {
                foreach (ConductorPointBehavior conductorPointBehavior in pointsToConduct)
                {
                    conductorPointBehavior.ReceiveEnergyFromEnergyPoint();
                }
            }
        }

        public void CalculateEnergyPointsToConduct()
        {
            Vector3 center = EnergyPointCollider.transform.position + EnergyPointCollider.center;
            float radius = EnergyPointCollider.radius;
 
            colliders = Physics.OverlapSphere(center, radius).ToList();
            pointsToConduct = new List<ConductorPointBehavior>();
            
            foreach (Collider overlappingCollider in colliders)
            {
                ConductorPointBehavior pointToConduct =
                    overlappingCollider.gameObject.GetComponent<ConductorPointBehavior>();

                if (pointToConduct != null)
                {
                    if(pointToConduct.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
                        pointsToConduct.Add(pointToConduct);
                }
            }
        }

        public void OnWin()
        {
            Anim.SetTrigger(Win);
        }
    }   
}