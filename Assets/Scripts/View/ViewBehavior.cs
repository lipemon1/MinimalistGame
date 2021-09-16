using UnityEngine;

namespace MinimalGame.View
{
    public abstract class ViewBehavior : MonoBehaviour, IView
    {
        [SerializeField] GameObject ViewObject;
        
        public void OpenView()
        {
            ViewObject.SetActive(true);
        }

        public void CloseView()
        {
            ViewObject.SetActive(false);
        }
    }
}