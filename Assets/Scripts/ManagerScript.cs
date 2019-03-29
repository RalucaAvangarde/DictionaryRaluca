﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{

    [SerializeField]
    private Dropdown sortDd;
    [SerializeField]
    private Button word;
    private Text wordText;
    [SerializeField]
    private Transform parentWords;
    [SerializeField]
    private InputField key;
    [SerializeField]
    private InputField valueDef;
    [SerializeField]
    private InputField search;
    private Dictionar myDictionary = new Dictionar();


    void Start()
    {
        key = key.GetComponent<InputField>();
        myDictionary = new Dictionar();

    }
    private void Awake()
    {
        wordText = word.GetComponentInChildren<Text>();
        ShowWords();

    }
    // try catch - don`t allow to user to add a word if that word exists already
    // verify if inputs contains words and definition and after add the element in dictionary and save it, when Add button is pressed
    // after adding word, cleared input field
    public void AddWord()
    {
        try
        {
            var space = "";

            if ((!string.IsNullOrEmpty(key.text) || !key.text.Contains(space)) && (!string.IsNullOrEmpty(valueDef.text) || !valueDef.text.Contains(space)))
            {
                myDictionary.AddElement(key.text, valueDef.text);
                ShowWords();
                myDictionary.Save();
                Debug.Log(key.text + " -- " + valueDef.text);
                ClearFields();
            }
            else

            {
                Debug.Log("Insert a word");
            }
        }
        catch (Exception)
        {
            Debug.LogError("Element is already in dictionary");
        }

    }
    //delete word from dictionary when press on Delete button
    public void DeleteWord()
    {
        myDictionary.DeleteElement(key.text);
        ShowWords();
        myDictionary.Save();
        ClearFields();

    }
    // display words in specified order, A-Z, Z-A or unordered
    public void ShowWords()
    {
        ClearList();
        if (sortDd.value == 1)
        {
            ClearList();
            DisplayWordsFromDictionary(myDictionary.MyDictionary.OrderBy(x => x.Key).ToDictionary(element => element.Key, element => element.Value));
        }
        else if (sortDd.value == 2)
        {
            ClearList();
            DisplayWordsFromDictionary(myDictionary.MyDictionary.OrderByDescending(x => x.Key).ToDictionary(element => element.Key, element => element.Value));

        }
        else
        {
            ClearList();
            DisplayWordsFromDictionary(myDictionary.MyDictionary);

        }

    }
    private void DisplayWordsFromDictionary(Dictionary<string, string> dictionary)
    {
        foreach (var item in dictionary)
        {
            if (item.Key.ToLower().StartsWith(search.text.ToLower()))
            {
                wordText.text = item.Key;
                var words = Instantiate(word, parentWords);
                SetListener(words, wordText.text);
            }
        }
    }
    private void SetListener(Button b, string action)
    {
        b.onClick.AddListener(() => { DisplayDescription(action); });
    }
    private void DisplayDescription(string Word)
    {
        valueDef.text = myDictionary.MyDictionary[Word];
        key.text = Word;
    }


    public void UpdateDefinition()
    {
        if (valueDef.text != null && key.text != null)
        {
            myDictionary.UpdateElement(key.text, valueDef.text);
            myDictionary.Save();
            ShowWords();
            Debug.Log(valueDef.text);
            ClearFields();
        }
    }
    private void ClearList()
    {
        foreach (Transform item in parentWords)
        {
            Destroy(item.gameObject);
        }
    }

    private void ClearFields()
    {
        key.text = "";
        valueDef.text = "";
    }

}