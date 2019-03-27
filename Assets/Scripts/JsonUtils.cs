using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonUtils : MonoBehaviour
{
    public ElementsList DefaultWords { get; set; }
    private string fileName = @"C:\Users\Intern 1\AppData\LocalLow\DefaultCompany\DictionaryProject\dictionary.json"; // 
    private string jsonFilePath;
    //private static ElementsList dictionaryWords;

    void Awake()
    {
        //jsonFilePath = Application.persistentDataPath + "/" + fileName;
        DefaultWords = new ElementsList();
       // Debug.Log(jsonFilePath);
        ReadData();
    }

    public void SaveData()
    {
        string contents = JsonUtility.ToJson(DefaultWords, true);
        File.WriteAllText(fileName, contents);
    }

    void OnApplicationQuit()
    {
        //Debug.Log("Application ending after " + Time.time + " seconds");
        //SaveData();
    }

    public ElementsList ReadData()
    {
        if (File.Exists(fileName))
        {
            string contents = File.ReadAllText(fileName);
            DefaultWords = JsonUtility.FromJson<ElementsList>(contents);

        }
        else
        {
            DefaultWords = new ElementsList();
        }
        return DefaultWords;
    }
}
