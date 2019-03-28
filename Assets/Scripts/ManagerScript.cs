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
        if (sortDd.value == 0 && sortDd.gameObject.activeInHierarchy == true)
        {
            ClearList();
            foreach (var item in myDictionary.MyDictionary.OrderBy(x => x.Key))
            {
                wordText.text = item.Key;
                var words = Instantiate(word, parentWords);
                SetListener(words, wordText.text);
            }
        }
        else if (sortDd.value == 1)
        {
            ClearList();
            foreach (var item in myDictionary.MyDictionary.OrderByDescending(x => x.Key))
            {
                wordText.text = item.Key;
                var words = Instantiate(word, parentWords);
                SetListener(words, wordText.text);
            }
        }
        else 
        {
            ClearList();
            foreach (var item in myDictionary.MyDictionary)
            {
                if (item.Key.Contains(search.text))
                {
                    wordText.text = item.Key;
                    var words = Instantiate(word, parentWords);
                    SetListener(words, wordText.text);
                    // word.GetComponent<WordElement>().nameWord = item.Key;
                    // word.GetComponent<WordElement>().description = item.Value;
                    // word.GetComponent<WordElement>().manager = this;
                }
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
    }
    /*  public void ShowDefinition(string def)
      {
          valueDef.text = def;
      }*/

    public void UpdateDefinition()
    {
        if (valueDef.text!= null)
        {
           // myDictionary.UpdateElement(key.text, valueDef.text);
            //myDictionary.Save();
        }
    }
    private void ClearList()
    {
        foreach (Transform item in parentWords)
        {
            Destroy(item.gameObject);
        }
    }

}
