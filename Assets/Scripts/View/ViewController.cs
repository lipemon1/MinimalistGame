using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinimalGame.View
{
    public enum ViewKeys
    {
        Unset,
        Menu,
        Preloading,
        LevelSelection,
        Pause,
        Endgame
    }
    
    public static class ViewController
    {
        static readonly Dictionary<ViewKeys, IView> CurrentViewsDic = new Dictionary<ViewKeys, IView>();
        static List<IView> _currentViewsAsList = new List<IView>();
        
        public static void RegisterView(ViewKeys viewKey, IView view)
        {
            if (viewKey == ViewKeys.Unset)
            {
                Debug.LogError("Trying to register a Unset view");
                return;
            }
            
            if(CurrentViewsDic.ContainsKey(viewKey))
                Debug.LogError("There is another view with this Key");
            else
            {
                CurrentViewsDic.Add(viewKey, view);
                _currentViewsAsList = CurrentViewsDic.Values.ToList();
            }
        }

        public static void OpenView(ViewKeys viewKey, bool closeOthers = true)
        {
            if (closeOthers)
                foreach (IView viewToClose in _currentViewsAsList)
                    viewToClose.CloseView();
            
            if (CurrentViewsDic.TryGetValue(viewKey, out IView view))
                view.OpenView();
            else
                Debug.LogError($"No view found [{viewKey}]");
        }

        public static void CloseView(ViewKeys keyToClose)
        {
            if (CurrentViewsDic.TryGetValue(keyToClose, out IView view))
                view.OpenView();
            else
                Debug.LogError($"No view found [{keyToClose}]");
        }
    }   
}