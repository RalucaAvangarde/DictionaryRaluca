using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dictionar
{
    public Dictionary<string, string> MyDictionary { get; set; }
    private JsonUtils utils;

    public Dictionar()
    {
        utils = new JsonUtils();
        MyDictionary = new Dictionary<string, string>();

        ToDictionary(utils.ReadData());
        //MyDictionary.Add("someting", "fromDictionay");

    }

    public void Save()
    {
        //MyDictionary.Add("someting2", "fromDictionay");
        utils.DefaultWords = ToList();
        utils.SaveData();
    }

    public void AddElement(string word, string descr)
    {
        MyDictionary.Add(word, descr);
    }

    public void DeleteElement(string word)
    {
        MyDictionary.Remove(word);
    }

    public void UpdateElement(string word, string newDescription)
    {
        MyDictionary[word] = newDescription;
    }

   
    public ElementsList ToList()
    {
        var list = new List<DictionaryElement>();

        foreach (var item in MyDictionary)
        {
            var temp = new DictionaryElement();
            temp.Word = item.Key;
            temp.Definition = item.Value;
            list.Add(temp);
        }

        var elementsList = new ElementsList();
        elementsList.Words = list;
        return elementsList;
    }

    public void ToDictionary(ElementsList el)
    {
        foreach (var item in el.Words)
        {
            MyDictionary.Add(item.Word, item.Definition);
        }
    }
}
