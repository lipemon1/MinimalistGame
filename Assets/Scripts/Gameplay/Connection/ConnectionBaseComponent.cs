using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public abstract class ConnectionBaseComponent : MonoBehaviour
    {
        protected ConnectionBehavior ConnectionBehavior;
        [SerializeField]
        protected bool IsEnable;
        void Awake()
        {
            ConnectionBehavior = this.gameObject.GetComponent<ConnectionBehavior>();
        }

        public void ToggleComponent(bool value)
        {
            IsEnable = value;
        }
    }   
}
