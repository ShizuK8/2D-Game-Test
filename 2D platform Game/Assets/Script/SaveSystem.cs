using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/save.json";

    public static void SaveBestChrono(float chrono)
    {
        SaveData data = new SaveData();
        data.bestChrono = chrono;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static float LoadBestChrono()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data.bestChrono;
        }
        return 0f; // Si pas de fichier, le record est 0
    }
}