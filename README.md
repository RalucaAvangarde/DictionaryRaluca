# DictionaryRaluca

My dictionary application is structured  in four C# scripts. Two of them are used for saving data in an external file of type json, first is named DictionaryData, that represents a template which is used to save data in file, in a specific structure, a list of elements where every item contains a word and a definition. The second one, named "JsonUtils" represents the logical part of data load and save, in other words the read and save methods used Unity JsonUtility tool to convert DictionaryData template in a json string and write it to a file.

On the other hand, the “Dictionar” script stores a C# dictionary data type, where both key and value are of type string and also stores some methods like: AddElements, Delete or UpdateElements, that allow me to manage the words and two methods that convert the dictionary to a list, respective, a list to a dictionary.

The last script, "ManagerScript", represents the link between the UI designed in Unity and the logical part of application which is built by the three scripts mentioned above.
