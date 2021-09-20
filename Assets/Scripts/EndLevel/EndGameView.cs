using MinimalGame.View;
using UnityEngine;
using UnityEngine.UI;

namespace MinimalGame.EndLevel
{
    public class EndGameView : ViewBehavior
    {
        [SerializeField] Button NextLevelButton;

        void Start()
        {
            NextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
        }

        protected override void OnOpenView()
        {
            base.OnOpenView();
            Debug.Log("Get next level info here");
        }

        void OnNextLevelButtonClicked()
        {
            Debug.Log("Load Next Level Here");
        }
    }
}