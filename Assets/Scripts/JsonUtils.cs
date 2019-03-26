using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonUtils : MonoBehaviour
{
    public ElementsList DefaultWords;
    private string fileName = "dictionary.json";
    private string jsonFilePath;
    private static ElementsList dictionaryWords;

    void Awake()
    {
        dictionaryWords = new ElementsList();
        jsonFilePath = Application.persistentDataPath + "/" + fileName;
        Debug.Log(jsonFilePath);
    }
    private void SaveData()
    {
        string contents = JsonUtility.ToJson(dictionaryWords, true);
        File.WriteAllText(jsonFilePath, contents);
    }

    private void ReadData()
    {
        if (File.Exists(jsonFilePath))
        {
            string contents = File.ReadAllText(jsonFilePath);
            DefaultWords = JsonUtility.FromJson<ElementsList>(contents);
        }
        else
        {
            Debug.Log("Unable to read default input file");
        }
    }
}
