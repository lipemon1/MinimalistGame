using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinimalGame.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Create LevelData", order = 1)]
    public class LevelDataController : ScriptableObject
    {
        public List<Level> Levels = new List<Level>();

        static LevelDataController _instance;
        public static LevelDataController Instance
        {
            get
            {
                _instance = Resources.Load<LevelDataController>("LevelData");
                return _instance;
            }
        }

        public void ReceiveNewData(List<Level> newLevels)
        {
            foreach (Level level in Levels)
                level.IsDone = false;
            
            foreach (Level newLevel in newLevels)
            {
                foreach (Level level in Levels.Where(level => level.Id == newLevel.Id))
                {
                    level.IsDone = newLevel.IsDone;
                    break;
                }
            }
        }

        public bool HasNextLevel(Level curLevel)
        {
            int currentIndex = Levels.IndexOf(curLevel);

            return currentIndex < (Levels.Count - 1);
        }

        public Level GetNextLevel(Level curLevel)
        {
            int currentIndex = Levels.IndexOf(curLevel);
            int newIndex = currentIndex + 1;
            return Levels[newIndex];
        }

        public bool CanPlayLevel(Level level)
        {
            int levelIndex = Levels.IndexOf(level);

            //if is first level
            if (levelIndex == 0) return true;

            int levelToCheckIndex = levelIndex - 1;

            return Levels[levelToCheckIndex].IsDone;
        }
    }
}