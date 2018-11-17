using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static SelectStage savedGameSelectStage = new SelectStage();
    public static Cypher savedGameVillas = new Cypher();    

    public static void SaveGameVillas(Cypher cypher)
    {
        savedGameVillas = cypher;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, JsonUtility.ToJson(SaveLoad.savedGameVillas));
        file.Close();
    }
    public static Cypher LoadGameVillas()
    {
        if (ContinueFile())
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            var element = bf.Deserialize(file).ToString();
            JsonUtility.FromJsonOverwrite(element, SaveLoad.savedGameVillas);
            file.Close();
        }

        return SaveLoad.savedGameVillas;
    }

    public static void SaveGameSelectStage (SelectStage selStage)
    {
        savedGameSelectStage = selStage;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, JsonUtility.ToJson(SaveLoad.savedGameVillas));
        file.Close();
    }
    public static SelectStage LoadGameSelectStage ()
    {
        if (ContinueFile())
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            var element = bf.Deserialize(file).ToString();
            JsonUtility.FromJsonOverwrite(element, SaveLoad.savedGameSelectStage);
            file.Close();
        }

        return SaveLoad.savedGameSelectStage;
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