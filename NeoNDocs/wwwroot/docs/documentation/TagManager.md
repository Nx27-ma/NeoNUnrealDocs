### TagManager
An "expansion" on the already existing Tag system from Unity. Currently you can only have one tag on an object, this Tag Manager allows you to add as many per object as you'd like. Also including a Remove method and a HasTag check method.

<img src="https://user-images.githubusercontent.com/71002222/166152754-28f8de43-cf95-4ee9-8a40-8103e2a965d9.png" alt="image" width="400"/>

#### TagManager Utilities
The TagManager Utilities allow programmers to access the new TagManager even more easily. For example, adding a tag to an object, whether or not it has the tagmanger, can be done straight through a game object, ```gameObject.AddTag("MyTag");```. This line of code will check if the object you want to add a tag to already has a manager, if it does not, it will add one and subsequently also add this tag, if it already has a tagmanager or the tag, it will ignore the command and return.

Other possibilities:
* ```gameObject.RemoveTag("MyTag");``` checks if an object has a tagmanager and if it has the tag. If it does, it will remove the tag, if not, it will simply ignore the command and return.
* ```gameObject.HasTag("MyTag");``` checks if an object has a tag.
* ```gameObject.HasTags("ListOfTags");``` checks if an object has the designated tags.