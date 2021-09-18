using MinimalGame.Data;
using MinimalGame.Gameplay;
using UnityEngine;

namespace MinimalGame.GameStartup
{
    public static class GameStartupLoader
    {
        static Level _currentLevel;
        static LevelCreatorBehavior _levelCreator;

        static GameStartupLoader()
        {
            ScenesController.ScenesController.onGameLoaded += OnGameSceneLoaded;
        }

        static void OnGameSceneLoaded()
        {
            CreateLevel();
        }

        public static void SetNewCurrentLevel(Level newLevel)
        {
            _currentLevel = newLevel;
        }

        static void CreateLevel()
        {
            GameObject levelCreator = GameObject.FindWithTag("LevelCreator");
            levelCreator.GetComponent<LevelCreatorBehavior>().LoadLevel(_currentLevel);
        }
    }
}