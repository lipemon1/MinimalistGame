using MinimalGame.Data;
using MinimalGame.View;
using UnityEngine;

namespace MinimalGame.MenuStartup
{
    public class MenuStartupLoader : MonoBehaviour
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