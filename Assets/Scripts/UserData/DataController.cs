using System.IO;
using UnityEngine;

namespace MinimalGame.Data
{
    public static class DataController
    {
        public static UserData UserData;
        const string DataFilename = "userData.json";
        public static string UserDataPath;

        public static void InitializeUserData()
        {
            UserDataPath = Application.persistentDataPath + DataFilename;

            if (File.Exists(UserDataPath))
            {
                string jsonData = File.ReadAllText(UserDataPath);
                UserData = JsonUtility.FromJson<UserData>(jsonData);
                Debug.Log("User Data from json");
            }
            else
            {
                UserData = new UserData();
                Debug.Log("User Data fresh new");
            }
        }

        public static void FinishLevel(Level level)
        {
            UserData.FinishLevel(level);
            SaveCurrentData();
        }

        static void SaveCurrentData()
        {
            string json = JsonUtility.ToJson(UserData);
            File.WriteAllText(UserDataPath, json);
            Debug.Log("Data saved at: " + UserDataPath);
        }
    }   
}
