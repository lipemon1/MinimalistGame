using UnityEngine;

namespace MinimalGame.Data
{
    [System.Serializable]
    public class Level
    {
        public int Id;
        public bool IsDone;
        string resourcesLevelPrefabPath;

        public Level(int id, bool isDone, string resourcesLevelPrefabPath)
        {
            this.Id = id;
            this.IsDone = isDone;
            this.resourcesLevelPrefabPath = resourcesLevelPrefabPath;
        }

        public string GetLevelPrefabPath()
        {
            if (string.IsNullOrEmpty(resourcesLevelPrefabPath))
                resourcesLevelPrefabPath = $"LevelsPrefabs/Level[{Id}]";

            return resourcesLevelPrefabPath;
        }
    }   
}