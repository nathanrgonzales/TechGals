using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static Cypher savedGame = new Cypher();

    public static void Save(Cypher cypher)
    {
        savedGame = cypher;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, JsonUtility.ToJson(SaveLoad.savedGame));
        file.Close();
    }
    public static Cypher Load()
    {
        if (ContinueFile())
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            var element = bf.Deserialize(file).ToString();
            JsonUtility.FromJsonOverwrite(element, SaveLoad.savedGame);
            file.Close();
        }

        return SaveLoad.savedGame;
    }

    public static void EraseFile()
    {
        File.Delete(Application.persistentDataPath + "/savedGames.gd");
    }

    public static bool ContinueFile()
    {
        return File.Exists(Application.persistentDataPath + "/savedGames.gd");
    }
}