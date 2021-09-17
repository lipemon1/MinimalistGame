using System;
using System.Collections;
using System.Collections.Generic;
using MinimalGame.Data;
using UnityEngine;
using UnityEngine.UI;

namespace MinimalGame.Menu
{
    public class LevelItemBehavior : MonoBehaviour
    {
        public Button ItemButton;
        public Text ItemLabel;

        public void InitializeLevelItem(Level level, Action onButtonClicked)
        {
            ItemLabel.text = "Level " + level.Id;
            
            ItemButton.onClick.RemoveAllListeners();
            ItemButton.onClick.AddListener(() => onButtonClicked());
        }
    }   
}
