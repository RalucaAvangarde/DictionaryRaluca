using System;
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
    private Text consoleText;
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
        consoleText.text = "";
    }
    private void Awake()
    {
        wordText = word.GetComponentInChildren<Text>();
        ShowWords();

    }
    // don`t allow to user to add a word if that word exists already
    // verify if inputs contains words and definition and after add the element in dictionary and save it, when Add button is pressed
    // after adding word, cleared input field
    public void AddWord()
    {

        var space = "";
        if (!myDictionary.MyDictionary.Keys.Contains(key.text))
        {
            consoleText.text = "";
            if ((!string.IsNullOrEmpty(key.text) || !key.text.Contains(space)) && (!string.IsNullOrEmpty(valueDef.text) || !valueDef.text.Contains(space)))
            {
                myDictionary.AddElement(key.text, valueDef.text);
                ShowWords();
                myDictionary.Save();
                Debug.Log(key.text + " -- " + valueDef.text);
                ClearFields();
                consoleText.text = "Word successfully added";

            }
            else 
            {
                consoleText.text = "Insert a word or definition!";
                Debug.Log("Insert a word or definition!");
                
            }

        }
        else
        {
            consoleText.text = "Element already exist!";
              Debug.Log("Element  already exist!");
        }


    }
    //delete word from dictionary when press on Delete button
    public void DeleteWord()
    {
        if (myDictionary.MyDictionary.Keys.Contains(key.text))
        {
            myDictionary.DeleteElement(key.text);
            ShowWords();
            myDictionary.Save();
            ClearFields();
            consoleText.text = "Word successfully deleted ^_^";
        }
        else
        {
               consoleText.text = "The word doensn`t exists in dictionary";
               Debug.Log("The word doensn`t exists in dictionary");
        }

    }
    // display words in specified order, A-Z, Z-A or unordered
    public void ShowWords()
    {
        ClearList();
        if (sortDd.value == 1)
        {
            ClearList();
            DisplayWordsFromDictionary(myDictionary.MyDictionary.OrderBy(x => x.Key).ToDictionary(element => element.Key, element => element.Value));
            consoleText.text = "";
        }
        else if (sortDd.value == 2)
        {
            ClearList();
            DisplayWordsFromDictionary(myDictionary.MyDictionary.OrderByDescending(x => x.Key).ToDictionary(element => element.Key, element => element.Value));
            consoleText.text = "";
        }
        else
        {
            ClearList();
            DisplayWordsFromDictionary(myDictionary.MyDictionary);
            consoleText.text = "";
        }

    }
    // this method is called in showWords and display the words when addWord button is clicked
    private void DisplayWordsFromDictionary(Dictionary<string, string> dictionary)
    {
        foreach (var item in dictionary)
        {
            if (item.Key.ToLower().StartsWith(search.text.ToLower()))
            {
                wordText.text = item.Key;
                var words = Instantiate(word, parentWords);
                SetListener(words, wordText.text);
                ClearFields();
                
            }
        }
    }
    private void SetListener(Button b, string action)
    {
        b.onClick.AddListener(() => { DisplayDescription(action); });

    }

    //display description for a word from dictionary
    private void DisplayDescription(string Word)
    {
        valueDef.text = myDictionary.MyDictionary[Word];
        key.text = Word;
    }

    // this method is called when press on SaveDefinition Button, and update the word definition 
    public void UpdateDefinition()
    {
        if (valueDef.text != null && key.text != null)
        {
            myDictionary.UpdateElement(key.text, valueDef.text);
            myDictionary.Save();
            ShowWords();
            Debug.Log(valueDef.text);
            ClearFields();
            consoleText.text = "";
        }
    }
    //clear the scroll view 
    private void ClearList()
    {
        foreach (Transform item in parentWords)
        {
            Destroy(item.gameObject);
        }
    }
    // clear key field and valueDef field
    private void ClearFields()
    {
        key.text = "";
        valueDef.text = "";
    }

}