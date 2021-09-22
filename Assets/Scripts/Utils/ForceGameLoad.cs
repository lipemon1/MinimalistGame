#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using MinimalGame.Data;
using MinimalGame.GameFlow;
using UnityEngine;

namespace MinimalGame.Utils
{
    public class ForceGameLoad : MonoBehaviour
    {
        public bool ForceLoad;
        public int LevelToLoad;
        
        void Start()
        {
            if (ForceLoad)
            {
                GameStartupLoader.SetNewCurrentLevel(new Level(LevelToLoad, false, null));   
                GameStartupLoader.LoadLevel();
            }
        }
    }   
}
#endif
