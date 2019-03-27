using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordElement : MonoBehaviour
{
    public string name;
    public  string description;
    [HideInInspector]
    public ManagerScript manager;

    public void ShowDefinition()
    {
        manager.ShowDefinition(description);
    }
}
