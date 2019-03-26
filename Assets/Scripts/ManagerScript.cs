using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    [SerializeField]
    private InputField field;
    //[SerializeField]
    //private InputField word;
    [SerializeField]
    private Text scrollText;
   

    void Start()
    {
        field = field.GetComponent<InputField>(); 
    }

    public void ShowText()
    {
        if (field.text != null )
        {
            scrollText.text = field.text;
         
           // Debug.Log(field.text);
        }
    }
}
