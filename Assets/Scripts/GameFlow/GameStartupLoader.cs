using MinimalGame.Data;
using MinimalGame.Gameplay;
using MinimalGame.Gameplay.Connections;
using MinimalGame.View;
using UnityEngine;

namespace MinimalGame.GameFlow
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
            LoadLevel();
        }

        public static void LoadLevel()
        {
            ConnectionsObservable.ResetForNewLevel();
            CreateLevel();
            LevelEnderController.PrepareForLevel();
            ViewController.CloseView(ViewKeys.Endgame);
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

        public static Level GetNextLevel()
        {
            if (LevelDataController.Instance.HasNextLevel(_currentLevel))
                return LevelDataController.Instance.GetNextLevel(_currentLevel);
            else
                return null;
        }

        public static void FinishLevel()
        {
            _currentLevel.IsDone = true;
            DataController.FinishLevel(_currentLevel);
        }
    }
}