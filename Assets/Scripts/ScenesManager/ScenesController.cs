using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinimalGame.ScenesController
{
    public static class ScenesController
    {
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
