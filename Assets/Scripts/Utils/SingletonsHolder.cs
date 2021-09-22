using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Utils
{
    public class SingletonsHolder : MonoBehaviour
    {
        public static SingletonsHolder Instance { get; set; }
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }
    }   
}
