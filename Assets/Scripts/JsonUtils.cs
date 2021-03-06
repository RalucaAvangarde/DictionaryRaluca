﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonUtils : MonoBehaviour
{
    public ElementsList DefaultWords { get; set; }
    private string fileName = "dictionary1.json"; 
    private string jsonFilePath;

    void Awake()
    {
        DefaultWords = new ElementsList();
        ReadData();
    }

    //save read data into file
    public void SaveData()
    {
        string contents = JsonUtility.ToJson(DefaultWords, true);
        File.WriteAllText(fileName, contents);
    }

  // read data from file, if file exists, else create it
    public ElementsList ReadData()
    {
        try
        {
            if (File.Exists(fileName))
            {
                string contents = File.ReadAllText(fileName);
                DefaultWords = JsonUtility.FromJson<ElementsList>(contents);

            }
            else
            {
                DefaultWords = new ElementsList();
                DefaultWords.Words = new List<DictionaryElement>();
                DefaultWords.Words.Add(new DictionaryElement() { Word = "table", Definition = "table definition" });
                DefaultWords.Words.Add(new DictionaryElement() { Word = "chair", Definition = "chair definition" });
                DefaultWords.Words.Add(new DictionaryElement() { Word = "problem", Definition = "A thing that is difficult to achieve" });
                DefaultWords.Words.Add(new DictionaryElement() { Word = "abstract", Definition = "abstract definition" });
                DefaultWords.Words.Add(new DictionaryElement() { Word = "book", Definition = " A literary composition" });
                SaveData();
            }
        }
        catch (System.Exception)
        {

            DefaultWords = new ElementsList();
        }


        return DefaultWords;
    }
}
