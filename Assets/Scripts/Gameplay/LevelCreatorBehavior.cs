using System.Collections;
using System.Collections.Generic;
using MinimalGame.Data;
using UnityEngine;

namespace MinimalGame.Gameplay
{
    public class LevelCreatorBehavior : MonoBehaviour
    {
        [SerializeField] Transform levelHolder;
        [SerializeField] GameObject curLevelCreated;
        
        public void LoadLevel(Level currentLevel)
        {
            DeleteCurrentLevel();
            
            GameObject levelPrefab = Resources.Load<GameObject>(currentLevel.GetLevelPrefabPath());
            curLevelCreated = Instantiate(levelPrefab, levelHolder);
        }

        void DeleteCurrentLevel()
        {
            Destroy(curLevelCreated);
        }
    }   
}
