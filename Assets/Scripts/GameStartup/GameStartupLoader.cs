using MinimalGame.Data;
using MinimalGame.View;
using UnityEngine;

namespace MinimalGame.GameStartup
{
    public class GameStartupLoader : MonoBehaviour
    {
        [SerializeField] ViewBehavior preLoadingView;
        [SerializeField] ViewBehavior mainMenuView;
        
        void Awake()
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
            preLoadingView.CloseView();
        }

        void ShowMainMenu()
        {
            mainMenuView.OpenView();
        }
    }   
}