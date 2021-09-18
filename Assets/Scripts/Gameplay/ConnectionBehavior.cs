using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public class ConnectionBehavior : MonoBehaviour
    {
        [SerializeField] float rotateAmount;
        [SerializeField] float rotationSpeed = 0.1f;
        
        [Space]
        [SerializeField] Vector3 debugFrom;
        [SerializeField] Vector3 debugTo;
        [SerializeField] float debugDif;
        
        [SerializeField] bool isRotating;
        Quaternion from;
        Quaternion to;
        void Update()
        {
            if (isRotating)
            {
                Rotating();
                TryStopRotation();
            }
        }

        void OnMouseDown()
        {
            CalculateNewRotation(this.transform.rotation, rotateAmount, ref from, ref to);
        }

        void CalculateNewRotation(Quaternion curRotation, float rotateAmount, ref Quaternion from, ref Quaternion to)
        {
            isRotating = false;
            Vector3 curRotVector3 = curRotation.eulerAngles;
            Vector3 targetRotation = new Vector3(curRotVector3.x, (curRotVector3.y + rotateAmount), curRotation.z);
            from = curRotation;
            to = Quaternion.Euler(targetRotation);

            debugFrom = from.eulerAngles;
            debugTo = to.eulerAngles;
            isRotating = true;
        }

        void TryStopRotation()
        {
            //TODO fix this bug - Lerp is not running smooth
            debugDif = Math.Abs(from.eulerAngles.y) - Math.Abs(to.eulerAngles.y);
            
            // if (debugDif < 0.001f)
            //     isRotating = false;
        }

        void Rotating()
        {
            transform.rotation = Quaternion.Lerp(from, to, Time.time * rotationSpeed);
        }
    }   
}
