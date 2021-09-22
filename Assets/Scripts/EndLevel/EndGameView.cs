using MinimalGame.Audio;
using MinimalGame.Data;
using MinimalGame.GameFlow;
using MinimalGame.ScenesController;
using MinimalGame.View;
using UnityEngine;
using UnityEngine.UI;

namespace MinimalGame.EndLevel
{
    public class EndGameView : ViewBehavior
    {
        [SerializeField] Button NextLevelButton;
        [SerializeField] Button MainMenuButton;
        Level nextLevel;
        
        void Start()
        {
            NextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
            MainMenuButton.onClick.AddListener(OnMainMenuClicked);
        }

        void OnMainMenuClicked()
        {
            SfxEmitter.Instance.PlaySfx(SfxKey.InterfaceClick);
            ScenesController.ScenesController.LoadScene(SceneKey.Menu);
        }

        protected override void OnOpenView()
        {
            base.OnOpenView();
            
            SfxEmitter.Instance.PlaySfx(SfxKey.Win);
            
            GameStartupLoader.FinishLevel();

            nextLevel = GameStartupLoader.GetNextLevel();

            NextLevelButton.gameObject.SetActive(nextLevel != null);
            MainMenuButton.gameObject.SetActive(nextLevel == null);
        }

        void OnNextLevelButtonClicked()
        {
            SfxEmitter.Instance.PlaySfx(SfxKey.InterfaceClick);
            GameStartupLoader.SetNewCurrentLevel(nextLevel);
            GameStartupLoader.LoadLevel();
        }
    }
}