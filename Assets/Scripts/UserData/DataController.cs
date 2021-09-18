using System.Collections;
using System.Collections.Generic;
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
    }   
}
