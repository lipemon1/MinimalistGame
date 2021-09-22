using System;
using MinimalGame.Audio;
using MinimalGame.Data;
using MinimalGame.ScenesController;
using MinimalGame.View;
using UnityEngine;
using UnityEngine.UI;

namespace MinimalGame.Menu
{
    public class MenuView : ViewBehavior
    {
        [SerializeField] Button playButton;
        [SerializeField] Button exitButton;
        [SerializeField] Button deleteDataButton;
        [SerializeField] Text UserDataPathDebug;

        void Start()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
            deleteDataButton.onClick.AddListener(OnDeleteDataClicked);
        }

        void OnDeleteDataClicked()
        {
            EmitSfx();
            DataController.EraseData();
            ScenesController.ScenesController.LoadScene(SceneKey.Menu);
        }

        protected override void OnOpenView()
        {
            base.OnOpenView();
            UserDataPathDebug.text = DataController.UserDataPath;
        }

        void OnPlayButtonClicked()
        {
            EmitSfx();
            ViewController.OpenView(ViewKeys.LevelSelection);
        }

        static void OnExitButtonClicked()
        {
            EmitSfx();
            Application.Quit();
        }

        static void EmitSfx()
        {
            SfxEmitter.Instance.PlaySfx(SfxKey.InterfaceClick);
        }
    }   
}