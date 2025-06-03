## Transform Utilities
Transform Utilities zijn Method Extensions met als doel om zowel herhalende code te voorkomen en om bepaalde handelingen in code toegankelijker te maken. Hieronder ga ik dieper in op de huidige Transform Utilities:


Methods | Uitleg 
:-----------|:------------
LookAt(Vector2)     | Roteert het object in de directie van de Vector2 parameter.
SetPositionX(float) | Een shortcut om direct de X waarde aan te passen van de positie van een object. 
SetPositionY(float) | Een shortcut om direct de Y waarde aan te passen van de positie van een object. 
SetPositionZ(float) | Een shortcut om direct de Z waarde aan te passen van de positie van een object.
Hide(bool)          | De Hide() Method staat je toe om een object te maskeren zonder de SetActive(bool) method te gebruiken.

<br>

### LookAt()
Om de **LookAt()** MethodExtension te gebruiken moet je het simpelweg aanroepen zoals je dat normaal ook doet met Component Methods. In dit geval pak je eerst het object waarbij je de **Lookat()** method wilt gebruiken, zoals een `_currentTarget`. Mocht dit niet al van het type `GameObject` zijn, moet je daarna eerst het gameObject opvragen van `_currentTarget` en vervolgens kun je de Method **LookAt()** opvragen en invullent.

#### Voorbeeld
```cs
_currentTarget.gameObject.LookAt(_forceDirection);
```
###### Note: Om de Method van ons te gebruiken vraag je LookAt() op uit een gameObject, niet uit een transform. Hier staat namelijk ook een LookAt() Method van Monobehaviour die anders werkt!

<br>

### SetPositionX() | SetPositionY() | SetPositionZ()
Standaard kun je helaas niet direct een .x/.y/.z positie waarde aanpassen van een object. Wanneer je direct een x/y/z van een positie wilt aanpassen, moet je eerst een variable aanmaken, deze opvullen met de positie van het object, vervolgens de x/y/z positie aanpassen van je nieuwe variable en dan de positie van je object opvullen met je nieuwe variabel. Deze Method Extensions versnellen dat process naar één line van code:

#### Voorbeeld
##### Zonder Method Extension:
```cs
var myPosition = gameObject.transform.position;
myPosition.x = 30f;
transform.position = myPosition;
```

##### Met Method Extension:
```cs
transform.SetPositionX(30f);
```

###### Note: De SetPositionXYZ() methods worden op dezelfde manier aangeroepen als [LookAt()](https://github.com/BAStudio/OperationStarfall/wiki/Transform-Utilities#lookat), maar dan in de transform van een object en niet het gameObject.

<br>

### Hide()
De Hide() method kan objecten maskeren zonder gebruik te hoeven maken van methods zoals SetActive(). Dit doet het door de scale van het object te zetten naar Vector3.zero (0,0,0). Het voordeel hiervan is dat wanneer je een method zoals SetActive() gebruikt, je ook geen scripts en/of coroutines meer kan laten uitvoeren in het object. Omdat Hide() alleen de scale naar nul zet, kan dat hiermee dus nog wel.

#### Voorbeeld
##### Hide Object:
```cs
_currentTarget.gameObject.Hide();
```
###### Note: de bool in Hide() is standaard true, dus deze *hoeft* niet meegegeven te worden.
##### Reveal Object:
```cs
_currentTarget.gameObject.Hide(false);
```
###### Note: Op het moment zet de Hide(false) het object z'n scale terug naar Vector3.one (1,1,1). Dus in sommige gevallen is het handig om in het script waar je deze functie aanroept ook een "Old Scale" variable bij te houden zodat je de scale daarnaar terug kan zetten voor het geval je custom scale values gebruikt voor het object. Deze Method wordt later nog verbeterd.