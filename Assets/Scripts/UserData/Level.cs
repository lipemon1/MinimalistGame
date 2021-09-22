using UnityEngine;

namespace MinimalGame.Data
{
    [System.Serializable]
    public class Level
    {
        public int Id;
        public bool IsDone;
        public string ResourcesLevelPrefabPath;

        public Level(int id, bool isDone, string resourcesLevelPrefabPath)
        {
            this.Id = id;
            this.IsDone = isDone;
            this.ResourcesLevelPrefabPath = resourcesLevelPrefabPath;
        }

        public string GetLevelPrefabPath()
        {
            if (string.IsNullOrEmpty(ResourcesLevelPrefabPath))
                ResourcesLevelPrefabPath = $"LevelsPrefabs/Level[{Id}]";

            return ResourcesLevelPrefabPath;
        }
    }   
}