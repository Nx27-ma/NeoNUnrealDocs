## PersistentDataBehaviour base class
The PersistentDataBehaviour class is the base class for all classes that need persistent properties.<br>
![The PersistentDataBehaviour class in the unity editor](https://www.daanduits.net/Image/EngineSnippets/Unity/PersistentDataBehaviour.png) <br>

| Field                |                         Function                         |
|----------------------|:--------------------------------------------------------:|
|encryptionType        |The type of encryption that is used.                      |
|propertyBindingFlags  |The binding flags used to find the persistent properties. |
|fileName              |The name of the file that is written/read from.           |
|filePath              |The path where the file will be stored using [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html)    |

| Method   |                         Function                         |
|----------|:--------------------------------------------------------:|
|Save()    |Sends the data to the [FileDataHandler](https://github.com/BAStudio/OperationStarfall/wiki/Save-and-load-system/#filedatahandler), which encrypts it if needed and writes it to a file.                      |
|Load()    |Gets the data from the [FileDataHandler](https://github.com/BAStudio/OperationStarfall/wiki/Save-and-load-system/#filedatahandler), which decrypts it if needed.    |

## PersistentPropertyAttribute
The PersistentProperty attribute has a constructor which needs a string name to use when the property is saved or loaded. The name has to be the same
as the property's name else it will not fined the property when saving/loading.

## FileDataHandler
The FileDataHandler is a class that is used to read from and write to it's given file path. It uses FileStreams to read from a file and write to a file.
The PersistentDataBehaviour has an instance of this class to use to save and load.

## How to create your own persistent class
When you have created a new class or when you want to change an existing class instead of it inheriting from MonoBehaviour it should inherit from PersistentDataBehaviour like so: <br>

```cs
public class Player : PersistentDataBehaviour
```

Then when you have a property that should be persistent make it use the PersistentProperty attribute.

```cs
public class Player : PersistentDataBehaviour
{
    [PersistentProperty] public int HP { get; set; }
    [PersistentProperty] private string name { get; }
}
```

Then you can call the Save and Load functions anytime you want in the script or from an instance reference in another script.

```cs
public class Player : PersistentDataBehaviour
{
    [PersistentProperty] public int HP { get; set; }
    [PersistentProperty] private string name { get; }

    private void Awake()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}

public class UISettings : MonoBehaviour
{
    public Player player;

    // Save Player's data when button is pressed
    public void OnSave()
    {
        player.Save();
    }
}
```
