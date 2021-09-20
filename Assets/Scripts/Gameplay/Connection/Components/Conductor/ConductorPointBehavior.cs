using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public class ConductorPointBehavior : MonoBehaviour
    {
        public SphereCollider Collider;
        ConductorBehavior conductorBehavior;

        [Space] 
        [SerializeField] List<ConductorPointBehavior> pointsIntersecting = new List<ConductorPointBehavior>();
        [SerializeField] List<Collider> colliders = new List<Collider>();
        
        void Awake()
        {
            conductorBehavior = transform.parent.GetComponent<ConductorBehavior>();
        }

        public void ReceiveEnergyFromEnergyPoint()
        {
            SendEnergyToPipe();
        }

        void SendEnergyToPipe()
        {
            conductorBehavior.ReceiveEnergyFromPoint(this);
        }

        void ReceiveEnergyFromPoint(GameObject emitterPoint)
        {
            SendEnergyToPipe();
        }

        public void ReceiveEnergyFromPipe()
        {
            List<ConductorPointBehavior> pointsToPassEnergy = pointsIntersecting;

            foreach (ConductorPointBehavior conductorPointBehavior in pointsToPassEnergy)
                conductorPointBehavior.ReceiveEnergyFromPoint(this.gameObject);
        }

        public void CalculatePoint()
        {
            Vector3 center = Collider.transform.position + Collider.center;
            float radius = Collider.radius;
 
            colliders = Physics.OverlapSphere(center, radius).ToList();
            
            pointsIntersecting = new List<ConductorPointBehavior>();
            
            foreach (Collider overlappingCollider in colliders)
            {
                ConductorPointBehavior pointToConduct =
                    overlappingCollider.gameObject.GetComponent<ConductorPointBehavior>();

                if (pointToConduct != null)
                {
                    int pointId = pointToConduct.gameObject.GetInstanceID();
                    int myId = this.gameObject.GetInstanceID(); 
                    if(pointId != myId)
                        pointsIntersecting.Add(pointToConduct);
                }
            }
        }
    }   
}