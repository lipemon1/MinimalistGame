using System.Collections.Generic;
using MinimalGame.Audio;
using MinimalGame.Data;
using MinimalGame.GameFlow;
using MinimalGame.ScenesController;
using MinimalGame.View;
using UnityEngine;
using UnityEngine.UI;

namespace MinimalGame.Menu
{
    public class LevelSelectionView : ViewBehavior
    {
        [SerializeField] Button backButton;
        [SerializeField] LevelItemBehavior levelPrefab;
        [SerializeField] List<LevelItemBehavior> spawnedLevelItem = new List<LevelItemBehavior>();
        [SerializeField] Transform levelsHolder;
        
        void Start()
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        static void OnBackButtonClicked()
        {
            SfxEmitter.Instance.PlaySfx(SfxKey.InterfaceClick);
            ViewController.OpenView(ViewKeys.Menu);
        }

        protected override void OnOpenView()
        {
            base.OnOpenView();

            if (spawnedLevelItem.Count > 0)
            {
                foreach (LevelItemBehavior levelItemBehavior in spawnedLevelItem)
                {
                    Destroy(levelItemBehavior.gameObject);
                }
                
                spawnedLevelItem.Clear();
            }

            foreach (Level level in LevelDataController.Instance.Levels)
            {
                LevelItemBehavior levelBehavior = Instantiate(levelPrefab, levelsHolder);
                levelBehavior.InitializeLevelItem(level, LevelDataController.Instance.CanPlayLevel(level), () => OnLevelClicked(level));
            }
        }

        static void OnLevelClicked(Level level)
        {
            SfxEmitter.Instance.PlaySfx(SfxKey.InterfaceClick);
            GameStartupLoader.SetNewCurrentLevel(level);
            ScenesController.ScenesController.LoadScene(SceneKey.Game);
        }
    }   
}