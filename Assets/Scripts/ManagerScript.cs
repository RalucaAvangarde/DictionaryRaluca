using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    [SerializeField]
    private InputField field;
    [SerializeField]
    private Button word;
   // [SerializeField]
    private Text wordText;
    [SerializeField]
    private Transform parentWords;
    public InputField key;
    public InputField value;
    private Dictionar myDictionary = new Dictionar();
    void Start()
    {
        field = field.GetComponent<InputField>();
        myDictionary = new Dictionar();
    }
    private void Awake()
    {
        word = word.GetComponent<Button>();
        wordText = word.GetComponentInChildren<Text>();
    }
    public void ShowText()
    {
        if (field.text != null )
        {
           // wordText.text = field.text;
         
           // Debug.Log(field.text);
        }
    }
    public void SaveButton()
    {
        Debug.Log(key.text + " -- " + value.text);
        myDictionary.Save();
    }

    public void AddWord()
    {
        Debug.Log(key.text + " -- " + value.text);
        myDictionary.AddElement(key.text, value.text);
        Debug.Log(key.text + " -- " + value.text);
    }
    public void ShowWords()
    {
        foreach (var item in myDictionary.MyDictionary)
        {
           
            Debug.Log(item);

        }
    }
}
