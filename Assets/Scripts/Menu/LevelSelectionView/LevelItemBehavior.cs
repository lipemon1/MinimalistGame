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
        public GameObject IsDoneObject;
        public GameObject BlockedObject;

        public void InitializeLevelItem(Level level, bool canPlay, Action onButtonClicked)
        {
            ItemLabel.text = "Level " + level.Id;
            IsDoneObject.gameObject.SetActive(level.IsDone);
            BlockedObject.SetActive(!canPlay);
            
            ItemButton.onClick.RemoveAllListeners();
            ItemButton.onClick.AddListener(() => onButtonClicked());
        }
    }   
}
