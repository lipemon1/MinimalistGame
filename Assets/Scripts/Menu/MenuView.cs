using System;
using MinimalGame.Data;
using MinimalGame.View;
using UnityEngine;
using UnityEngine.UI;

namespace MinimalGame.Menu
{
    public class MenuView : ViewBehavior
    {
        [SerializeField] Button playButton;
        [SerializeField] Button exitButton;
        [SerializeField] Text UserDataPathDebug;

        void Start()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        protected override void OnOpenView()
        {
            base.OnOpenView();
            UserDataPathDebug.text = DataController.UserDataPath;
        }

        void OnPlayButtonClicked()
        {
            ViewController.OpenView(ViewKeys.LevelSelection);
        }

        static void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }   
}