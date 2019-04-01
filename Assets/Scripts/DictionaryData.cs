using System.Collections.Generic;


[System.Serializable]
public class DictionaryData
{
    public ElementsList Words;
}

[System.Serializable]
public class ElementsList
{
    public List<DictionaryElement> Words;
}

[System.Serializable]
public class DictionaryElement
{
    public string Word;          //word = key from dictionary
    public string Definition;    // definition will be value in dictionary
}
