using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public enum ConnectionPositionMode
    {
        Vertical = 0,
        RightCorner = 1,
        Horizontal = 2,
        LeftCorner = 3
    }
    
    public class ConnectionBehavior : MonoBehaviour
    {
        [SerializeField] ConnectionPositionMode curPositionMode;
        [SerializeField] float rotateAmount;
        [SerializeField] float rotationSpeed = 0.1f;

        bool isRotating;
        Quaternion from;
        Quaternion to;

        int interactionAmount;
        bool canInteractWith = true;
        
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
            if (canInteractWith)
                canInteractWith = false;
            
            CalculateNewRotation(this.transform.rotation, rotateAmount, ref from, ref to);
            CalculationNewPositionMode();

            canInteractWith = true;
        }

        void CalculationNewPositionMode()
        {
            int curPos = (int) curPositionMode;
            
            if (curPos == 3)
                curPos = 0;
            else
                curPos += 1;

            curPositionMode = (ConnectionPositionMode) curPos;
        }

        void CalculateNewRotation(Quaternion curRotation, float rotateAmount, ref Quaternion from, ref Quaternion to)
        {
            isRotating = false;
            Vector3 curRotVector3 = curRotation.eulerAngles;
            Vector3 targetRotation = new Vector3(curRotVector3.x, (curRotVector3.y + rotateAmount), curRotation.z);
            
            from = curRotation;
            to = Quaternion.Euler(targetRotation);
            
            isRotating = true;
        }

        void TryStopRotation()
        {
            //TODO fix this bug - Lerp is not running smooth
            float diff = Math.Abs(from.eulerAngles.y) - Math.Abs(to.eulerAngles.y);
            
            // if (debugDif < 0.001f)
            //     isRotating = false;
        }

        void Rotating()
        {
            transform.rotation = Quaternion.Lerp(from, to, Time.time * rotationSpeed);
        }
    }   
}
