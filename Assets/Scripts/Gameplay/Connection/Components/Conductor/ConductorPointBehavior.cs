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
        public bool HasEnergy;
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
            SetEnergy(true);
            
            StartCoroutine(PassEnergyToPipe());
        }

        IEnumerator PassEnergyToPipe()
        {
            yield return new WaitForSeconds(0.1f);

            SendEnergyToPipe();
        }

        void SendEnergyToPipe()
        {
            conductorBehavior.ReceiveEnergyFromPoint(this);
        }

        void ReceiveEnergyFromPoint(GameObject emitterPoint)
        {
            SetEnergy(true);
            SendEnergyToPipe();
        }

        public void ReceiveEnergyFromPipe()
        {
            SetEnergy(true);
            List<ConductorPointBehavior> pointsToPassEnergy = pointsIntersecting;

            foreach (ConductorPointBehavior conductorPointBehavior in pointsToPassEnergy)
                conductorPointBehavior.ReceiveEnergyFromPoint(this.gameObject);
        }

        void SetEnergy(bool value)
        {
            HasEnergy = value;
        }

        List<ConductorPointBehavior> GetConductorsToPassEnergy(GameObject emitterPoint)
        {
            return pointsIntersecting.Where(p => p.gameObject.GetInstanceID() != emitterPoint.GetInstanceID()).ToList();
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