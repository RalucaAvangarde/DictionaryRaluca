using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject word;
    
    private Text wordText;
    [SerializeField]
    private Transform parentWords;
    [SerializeField]
    private InputField key;
    public InputField valueDef;
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

    public void ShowSearchedWord()
    {
        if (key.text != null)
        {
            //  Debug.Log(key.text);

        }
    }
    public void SaveButton()
    {
        Debug.Log(key.text + " -- " + valueDef.text);
        myDictionary.Save();
    }

    public void AddWord()
    {
        Debug.Log(key.text + " -- " + valueDef.text);
        myDictionary.AddElement(key.text, valueDef.text);
        ShowWords();
        myDictionary.Save();
        Debug.Log(key.text + " -- " + valueDef.text);
    }
    public void DeleteWord()
    {
        myDictionary.DeleteElement(key.text);
        ShowWords();
        myDictionary.Save();

    }

    public void ShowWords()
    {
        ClearList();
        foreach (var item in myDictionary.MyDictionary)
        {
            wordText.text = item.Key;

            Instantiate(word, parentWords);
           
            word.GetComponent<WordElement>().name = item.Key;
            word.GetComponent<WordElement>().description = item.Value;
            word.GetComponent<WordElement>().manager = this;

        }

    }
    public void ShowDefinition(string def)
    {
        valueDef.text = def;
        //Debug.Log(def);
    }
    private void ClearList()
    {
        foreach (Transform item in parentWords)
        {
            Destroy(item.gameObject);
        }
    }

}
