using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.View
{
    public interface IView
    {
        void OpenView();
        void CloseView();
    }
}