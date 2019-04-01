using System.Collections.Generic;
using System.Linq;

public class DictionaryManager
{
    public Dictionary<string, string> MyDictionary { get; set; }
    private JsonUtils utils;

    public DictionaryManager()
    {
        utils = new JsonUtils();
        MyDictionary = new Dictionary<string, string>();

        ToDictionary(utils.ReadData());
    }

    public void Save()
    {
        //MyDictionary.Add("someting2", "fromDictionay");
        utils.DefaultWords = ToList();
        utils.SaveData();
    }

    //add word and definition to dictionary
    public void AddElement(string word, string descr)
    {
        MyDictionary.Add(word, descr);
    }

    //delete word from dictionary
    public void DeleteElement(string word)
    {
        MyDictionary.Remove(word);
    }

    // update description from a given word
    public void UpdateElement(string word, string newDescription)
    {
        MyDictionary[word] = newDescription;
    }

    //convert the dictionary to a list of type "ElementsList"
    public ElementsList ToList()
    {
        var list = new List<DictionaryElement>();

        foreach (var item in MyDictionary)
        {
            var temp = new DictionaryElement();
            temp.Word = item.Key;
            temp.Definition = item.Value;
            list.Add(temp);
        }

        var elementsList = new ElementsList();
        elementsList.Words = list;
        return elementsList;
    }

    //Convert the list to a dictionary
    public void ToDictionary(ElementsList el)
    {
        foreach (var item in el.Words)
        {
            MyDictionary.Add(item.Word, item.Definition);
        }
    }
}
