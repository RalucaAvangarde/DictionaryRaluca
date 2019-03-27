using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
   
    [SerializeField]
    private Button word;
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
        word = word.GetComponent<Button>();
        wordText = word.GetComponentInChildren<Text>();
        ShowWords();
       
    }
  
    public void ShowSearchedWord()
    {
        if (key.text != null )
        {
            Debug.Log(key.text);
            
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
        Debug.Log(key.text + " -- " + valueDef.text);
    }
    public void DeleteWord()
    {
        myDictionary.DeleteElement(key.text);

    }

    public void ShowWords()
    {
        
            foreach (var item in myDictionary.MyDictionary)
            {
                wordText.text = item.Key;
               var words = Instantiate(word, parentWords);
            }
        
    }
    
}
