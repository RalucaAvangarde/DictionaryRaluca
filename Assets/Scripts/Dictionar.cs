using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionar : MonoBehaviour
{
    public Dictionary<string,string> MyDictionary { get; set; }

    public Dictionar()
    {
        MyDictionary = new Dictionary<string, string>();
    }

    public void AddElements(string word, string descr)
    {
        MyDictionary.Add(word, descr);
    }

    public void DeleteElements(string word)
    {
        MyDictionary.Remove(word);
    }

    public void UpdateElements(string word,string newDescription)
    {
        MyDictionary[word] = newDescription;
    }
}
