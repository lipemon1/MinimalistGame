using MinimalGame.Data;
using MinimalGame.View;
using UnityEngine;

namespace MinimalGame.GameStartup
{
    public class GameStartupLoader : MonoBehaviour
    {
        void Start()
        {
            LoadUserData();
            HidePreLoading();
            ShowMainMenu();
        }

        static void LoadUserData()
        {
            DataController.InitializeUserData();
        }

        void HidePreLoading()
        {
            ViewController.CloseView(ViewKeys.Preloading);
        }

        void ShowMainMenu()
        {
            ViewController.OpenView(ViewKeys.Menu);
        }
    }   
}