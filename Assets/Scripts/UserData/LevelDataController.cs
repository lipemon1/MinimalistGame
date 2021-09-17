using System.Collections.Generic;
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
    }
}