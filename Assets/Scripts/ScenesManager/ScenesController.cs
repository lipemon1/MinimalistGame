using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinimalGame.ScenesController
{
    public static class ScenesController
    {
        public delegate void OnSceneLoadedDelegate();
        public static OnSceneLoadedDelegate onMenuLoaded;
        public static OnSceneLoadedDelegate onGameLoaded;
        
        static ScenesController()
        {
            SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;    
        }

        static void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            switch ((SceneKey)arg0.buildIndex)
            {
                case SceneKey.Game:
                    onGameLoaded?.Invoke();
                    break;
                case SceneKey.Menu:
                    onMenuLoaded?.Invoke();
                    break;
                default:
                    Debug.LogError($"There is no scene [{(SceneKey)arg0.buildIndex}]");
                    break;
            }
        }

        public static void LoadScene(SceneKey key)
        {
            SceneManager.LoadScene((int) key);
        }
    }

    public enum SceneKey
    {
        Menu = 0,
        Game = 1
    }
}
