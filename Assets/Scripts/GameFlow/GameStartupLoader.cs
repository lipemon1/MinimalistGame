using MinimalGame.Data;
using UnityEngine;

namespace MinimalGame.GameStartup
{
    public static class GameStartupLoader
    {
        static Level currentLevel;

        static GameStartupLoader()
        {
            ScenesController.ScenesController.onGameLoaded += onGameSceneLoaded;
        }

        static void onGameSceneLoaded()
        {
            Debug.Log($"Load Level [{currentLevel.Id}] here");
        }

        public static void SetNewCurrentLevel(Level newLevel)
        {
            currentLevel = newLevel;
        }
    }
}