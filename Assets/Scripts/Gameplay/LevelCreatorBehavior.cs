using System.Collections;
using System.Collections.Generic;
using MinimalGame.Data;
using UnityEngine;

namespace MinimalGame.Gameplay
{
    public class LevelCreatorBehavior : MonoBehaviour
    {
        [SerializeField] Transform levelHolder;
        public void LoadLevel(Level currentLevel)
        {
            GameObject levelPrefab = Resources.Load<GameObject>(currentLevel.GetLevelPrefabPath());
            Instantiate(levelPrefab, levelHolder);
        }
    }   
}
