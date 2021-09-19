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
    
    public class RotationBehavior : ConnectionBaseComponent
    {
        [SerializeField] public ConnectionPositionMode CurPositionMode;
        [SerializeField] float rotateAmount;

        Quaternion from;
        Quaternion to;

        int interactionAmount;
        bool canInteractWith = true;

        void OnMouseDown()
        {
            if (!IsEnable) return;

            StartCoroutine(ExecuteTouch());
        }

        IEnumerator ExecuteTouch()
        {
            if (canInteractWith)
                canInteractWith = false;
            
            CalculateNewRotation(this.transform.rotation, rotateAmount, ref from, ref to);
            CalculationNewPositionMode();

            yield return new WaitForSeconds(0.1f);
            ConnectionBehavior.MarkConnectionAsRotated();

            canInteractWith = true;
        }

        void CalculationNewPositionMode()
        {
            int curPos = (int) CurPositionMode;
            
            if (curPos == 3)
                curPos = 0;
            else
                curPos += 1;

            CurPositionMode = (ConnectionPositionMode) curPos;
        }

        void CalculateNewRotation(Quaternion curRotation, float rotateAmount, ref Quaternion from, ref Quaternion to)
        {
            Vector3 curRotVector3 = curRotation.eulerAngles;
            Vector3 targetRotation = new Vector3(curRotVector3.x, (curRotVector3.y + rotateAmount), curRotation.z);
            
            from = curRotation;
            to = Quaternion.Euler(targetRotation);

            this.transform.rotation = to;
        }
    }   
}
