using System;
using UnityEngine;

namespace MinimalGame.View
{
    public abstract class ViewBehavior : MonoBehaviour, IView
    {
        [SerializeField] ViewKeys Key;
        [SerializeField] GameObject ViewObject;
        bool isOpen;

        void Awake()
        {
            ViewController.RegisterView(Key, this);
            
            if(!isOpen && ViewObject.gameObject.activeInHierarchy)
                CloseView();
        }

        public void OpenView()
        {
            ViewObject.SetActive(true);
            isOpen = true;
            OnOpenView();
        }
        
        public void CloseView()
        {
            if (!IsCorrectlyClose(ViewObject, isOpen))
            {
                ViewObject.SetActive(false);
                isOpen = false;
                OnCloseView();   
            }
        }

        protected virtual void OnOpenView()
        {
            
        }

        protected virtual void OnCloseView()
        {
            
        }

        private bool IsCorrectlyClose(GameObject ViewObject, bool isOpen)
        {
            if (ViewObject == null || ViewObject.gameObject == null)
                return true;
            
            return !isOpen && !ViewObject.gameObject.activeInHierarchy;
        }
    }
}