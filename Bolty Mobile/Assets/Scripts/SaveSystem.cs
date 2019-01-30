using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void  SaveLevelUnlocked (LevelManager levelManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(levelManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadLevelUnlocked()
    {
        string path = Application.persistentDataPath + "/level";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

             LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not foun in" + path);
            return null;
        }
    }
}

