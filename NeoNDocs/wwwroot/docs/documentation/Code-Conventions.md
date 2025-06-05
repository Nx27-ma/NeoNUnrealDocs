## Operation Starfall code conventions


#### Waarom Code conventions
In deze repository vind je code voorbeelden voor de Code Conventions: hoe codeer je je code.

Waarom Code conventions:

Code conventions (codeer afspraken) zijn voor programmeurs belangrijk voor verschillende redenen:

*   Het maakt je code leesbaar
*   Vaak werken er meerdere developers aan hetzelfde project. Code Conventions zorgen ervoor dat de code voor iedereen leesbaar is
*   Je hebt veel meer overzicht over je code

<img width="200px" src="images/rider.jpg"/>

Onze code editor (Rider) helpt ons bij de code conventions. Als je code niet voldoet aan de conventies dan zal Rider tips geven (lampje) hoe je je code kunt aanpassen. Ook kan je gebruik maken van de auto format option van Rider.

* [Een quick fix toepassen op je code](https://www.jetbrains.com/help/rider/Code_Analysis__Quick-Fixes.html)
* [Je code automatisch formatten](https://www.jetbrains.com/help/rider/Enforcing_Code_Formatting_Rules.html)

# Codeconventions

##### Hoe bepaal je de naam?

###### Bij Classes:

Code | Conventie
:-----------|:------------
public class Enemy | De naam van je Class is altijd in het engels en begint met een hoofdletter
public class EnemyShip | Als je Class naam uit meerdere woorden bestaat: gebruik PascalCasing
public class EnemyShip | Een Class is altijd een 'object'. Bijvoorbeeld een Wapen, Tafel, TargetFollower

###### Variables

Code | Conventie
:-----------|:------------
private int _speed | De naam van je variabele is altijd in het engels en begint met een underscore, gevolgd door een kleine letter
private int _scrollSpeed | Als de naam van je variabele uit meerdere woorden bestaat: gebruik camelCasing
[SerializeField] private int scrollSpeed | Private serialized fields hebben geen underscore
public const string HowToPlay = "howToPlay"; | Een constant schrijf je d.mv. PascalCasing en begint met een hoofdletter
public int Speed { get; } = 5; | Properties (getters/setters) starten met een hoofdletter.

###### Functions / methods

Code | Conventie
:-----------|:------------
Run(); | De naam van je method is altijd in het engels en begint (in C#) met een hoofdletter
RunFast(); | Als de naam van je method uit meerdere woorden bestaat: gebruik PascalCasing
Shoot(); | De naam van je method is een werkwoord: Shoot, Drive, Walk, Run, FollowTarget, etc.

###### Enums

Code | Conventie
:-----------|:------------
public enum BlendTypes | De naam van je Enum is altijd in het engels en begint met een hoofdletter
public enum BlendTypes | Als de naam van je Enum uit meerdere woorden bestaat: gebruik PascalCasing
ForceIds | De naam van je Enum laat altijd goed zien dat het een verzameling 'types' is (EnemyTypes, WeaponIds, etc.).

###### Namespaces

Code | Conventie
:-----------|:------------
namespace StateMachine | De naam van je namespace is altijd in het engels en begint met een hoofdletter
namespace StateMachine | Als de naam van je namespace uit meerdere woorden bestaat: gebruik PascalCasing

###### BaseClasses

Code | Conventie
:-----------|:------------
public class Weapon | Een baseclass heeft altijd de naam van het basisobject (wapen, bullet, state, menu, etc.)

## Organisatie van de Class

Hieronder zie je de volgorde hoe wij onze code structureren. Dit helpt bij de leesbaarheid van onze classes. Deze punten geven van boven naar beneden aan waar je variables, methods en properties (getter/setters) zouden moeten staan.

### 1. Class variables (Velden)
- **Public variables**: 
  - Begin met publieke velden. Het liefste zien we geen publieke variabelen voor goede encapsulation
- **Serialized private variables**: 
  - Geserializeerde private velden, aanpasbaar in de Unity Editor.
- **Private variables**: 
  - Interne statusvariabelen van de class.

### 2. Properties (Getters/Setters)
- **Public properties**: 
  - Publieke getters en setters voor gecontroleerde toegang tot de class variables.

### 3. Unity lifecycle methods
- Plaats Unity-specifieke levenscyclusmethoden in de volgorde waarin Unity ze aanroept:
  - `Awake()`
  - `Start()`
  - `Update()`
  - Anderen (`FixedUpdate`, `LateUpdate`, enz.)

### 4. Public methods
- Methoden die kunnen worden aangeroepen door andere klassen.

### 5. Interface Implementaties
- Implementaties van methoden die gedefinieerd zijn in interfaces waar de klasse zich aan houdt.

### 6. Protected methods
- Methoden toegankelijk binnen de Class en zijn subclasses.

### 7. Private methods
- Methoden voor intern gebruik in de klasse.

### 8. Statische methods en Variabelen
- Statische methoden en variabelen, gegroepeerd naar hun toegankelijkheid (public, protected, private).

### 9. Coroutines
- Groepeer coroutines (`IEnumerator` methoden voor gebruik met `StartCoroutine`) (public, protected, private).

## Aanvullende Richtlijnen
- **Consistentie**: Behoud consistentie in het gehele project.
- **Leesbaarheid**: Prioriteer de leesbaarheid en onderhoudbaarheid van de code.
- **Refactoring**: Refactor grote klassen naar kleinere, meer gefocuste componenten.

### Declarations (het aanmaken van je variabelen)
#### Plaatsing
Declareer je variabelen alleen aan het begin van een block. Wacht niet met het declareren van je variabelen totdat je ze gaat gebruiken. Dit maakt je code verwarrend en niet overzichtelijk.

```c#
public void myMethod(){
	int int1;     	// beginning of method block
	if (condition){
    		int int2; 	// beginning of "if" block
    		...
	}
}
```

#### Gebruik van var
Gebruik 'var' inplaats van een Type als de rechterkant van je code duidelijk laat zien wat de type is.

```c#
var name = "OperationStarfall";
var strength = 255;
```

#### Aantal declaraties per regel
Zet 1 declaratie per lijn regel.

###### Goed voorbeeld: 
```c#
var level = 5;
var size = 3;
```

#### Gebruik referenties
Gebruik lokale variabelen om referenties aan te maken naar complexe object benamingen. Dit verbetert de leesbaarheid van je code + je maakt minder fouten in je code.

###### Slecht voorbeeld:
```c#
int l = gameTower[i].bullet.Count;
for (int i = 0; i < l; i++){
	if(gameTower[i].bullet[j].position.x > stageWidth || gameTower[i].bullet[j].position.y > stageHeight ){
		Destroy(gameTower[i].bullet[j].gameObject);
	}
}
```
###### Goed voorbeeld:
```c#
Bullet currentBullet;
int l = gameTower[i].bullet.Count;
for (int i = 0; i < l; i++){
	currentBullet = gameTower[i].bullet[j];
	if(currentBullet.position.x > stageWidth || currentBullet.position.y > stageHeight )
		Destroy(currentBullet.gameObject);
	}
}
```

#### Gebruik van ternary operator
Gebruik een ternary operator om een `if` `else` statement op 1 regel te schrijven.

###### Slecht voorbeeld:
```c#
Color targetColor;
if (isSelected)
{
    targetColor = Color.red;
}
else
{
    targetColor = Color.white;
}
```

###### Goed voorbeeld:
```c#
var targetColor = isSelected ? Color.red : Color.white;
```
 
### Wat is de vorm van een statement
#### if, if-else, if-else-if-else statement
De if-else heeft de volgende vorm:
```c#
if(condition)
{
  	statements;
}
 
if(condition)
{
  	statements;
}
else
{
  	statements;
}
 
if(condition)
{
  	statements;
}
else if (condition)
{
  	statements;
}
else if (condition)
{
  	statements;
}
```
###### Extra:
Gebruik altijd brackets {} in je if-else statements. Dit maakt je if-else statement een stuk leesbaarder dan bijvoorbeeld onderstaand voorbeeld. Hier zijn de brackets weggelaten. Dit kan als de statement maar uit 1 regel bestaat. Maar het is niet goed leesbaar voor andere developers.
```c#
if (condition)
statement;
```

#### for Statements
 
De for statement heeft de volgende vorm:
```c#
for (initialization;condition;update)
{
  	statements;
}
```

Tip: Probeer altijd een lokale variable aan te maken waarin je het aantal loops zet (vooral als je bijvoorbeeld met array.length/list.Count werkt). Anders moet je applicatie steeds opnieuw in het geheugen berekenen hoeveel de lengte is. Hierdoor wordt je performance een stuk beter.

###### Goed voorbeeld:
```c#
int l = bullets.Count;
for (int i = 0;i < l;i++)
{
  	statements;
}
```
###### Slecht voorbeeld:
```c#
for (int i = 0;i < bullets.Count;i++)
{
  	statements;
}
```
Tip: Voeg altijd een ‘break;’ toe aan je loop op het moment dat je hebt gevonden wat je zoekt. Voorbeeld:
```c#
int l = names.Count;
for (int i = 0;i < l;i++){
if(names[i] == searchValue){
	…..
	break;
}
}
```

# Algemene best practices

Maak gebruik van 'prefixes' in je variabele namen zoals 'currentSpeed' 'targetEnemy', 'newBullet' etc.
Dit maakt je code leesbaarder. Current speed zegt duidelijk, we hebben het hier over de current speed.
```c#
Enemy newEnemy = Instantiate(enemyPrefab);
```

```c#
public void DeleteItem(Item targetItem){
    // delete targetItem from list
    // the prefix 'target' helps with understanding the code
}
```

#### DRY - Don’t Repeat Yourself

Voorkom dubbele code. Je wilt niet steeds op meerdere plekken dezelfde dingen moeten aanpassen als je je code wilt uitbreiden. Stel je wilt de functie Shoot() uitbreiden door een snelheid mee te geven Shoot(15). In het slechte voorbeeld moet je dit op meerdere plekken aanpassen.

###### Slecht voorbeeld:
```c#
int randomNumber = Random.Range(0, towers.Count); // bepaal random een tower

if(randomNumber == 0)
{
	tower0.Aim(mouseX, mouseY);
	tower0.Shoot();
}
else if(randomNumber == 1)
{
	tower1.Aim(mouseX, mouseY);
	tower1.Shoot();
}
else if(randomNumber == 3)
{
	tower2.Aim(mouseX, mouseY);
	tower2.Shoot();
}
```
###### Goed voorbeeld:
```C#
int randomNumber = Random.Range(0, towers.Count); // bepaal random een tower
Tower shootingTower = towers[randomNumber];

shootingTower.Aim(mouseX, mouseY);
shootingTower.Shoot();
```

#### Alles is standaard private

Variabelen zijn ALTIJD private. Als je andere Classes toegang wilt geven tot de variabelen dan maak je gebruik van getters&setters (zie onderaan deze pagina voor een voorbeeld).
Functies zijn standaard private. Sommige maak je public op het moment dat je zeker weet dat andere Classes erbij moeten mogen.
Hierdoor krijgen Classes een nette API. Ook voorkom je zo dat niet elke Class elkaars gegevens mag aanpassen.

#### Single Responsibility Principle

Elke Class heeft maar 1 verantwoordelijkheid.
###### Slecht voorbeeld: meerdere verantwoordelijkheden in 1 Class
Classname | Verantwoordelijkheid
:-----------|:------------
Player.cs | Een Class die alles bevat wat de player moet doen (springen, schieten, naar de pijltjes toetsen kijken).
###### goed voorbeeld: verantwoordelijkheden netjes opgedeeld
Classname | Verantwoordelijkheid
:-----------|:------------
PlayerMovement.cs | Een Class die de beweging van de Player als verantwoordelijkheid heeft
KeyboardInput.cs | Class met als verantwoordelijkheid naar keyboard input te luisteren en vervolgens functies aan te roepen op de player.

###### Slecht voorbeeld:
Classname | Verantwoordelijkheid
:-----------|:------------
Tiles.cs | Een Class die alle tiles beheerd en rendert
###### goed voorbeeld:
Classname | Verantwoordelijkheid
:-----------|:------------
Tiles.cs | Een Class die alle tiles beheerd  
TilesRenderer.cs | Een Class die alle tiles rendert

Als je Class maar 1 verantwoordelijkheid heeft zorgt ervoor dat je code minder strict gekoppeld is. Als je bijvoorbeeld voor de tiles hierboven wilt switchen tussen een WebGL renderer, Div renderer of een Canvas renderer (JavaScript in je browser) dan hoef je alleen maar TilesRenderer.cs te vervangen. Tiles.cs blijft onaangepast.
Of als je bij de Player wilt switchen naar een TouchInput.cs (touch devices) dan hoef je niets aan te passen aan PlayerMovement.cs.

###### CRC - Class-responsibility-collaboration cards
Om SRP (Single Responsibility Principle) goed toe te passen, kun je gebruik maken van CRC cards. Hiervoor gebruik je A6-jes.
Schrijf op een A6-je de naam van de Class + de responsiblity + de Classes waar deze Class mee samenwerkt.

![alt text](https://github.com/macollegegamedevelopment/codeconventions/blob/master/images/crc.jpg)

###### Intentie van je code

De 'intentie van je code' moet zo snel mogelijk duidelijk zijn als je je code leest. Dit betekent dat je gelijk begrijpt wat de code gaat doen als je begint met lezen.

###### Slecht voorbeeld

```c#
public void Update(){
	if (enemies.Count > 0)
	{
    	for(int i = 0; i < enemies.Count;i++)
    	{
    	    Enemy targetEnemy = enemies[i];
    	    targetEnemy.Update();
    	    if(targetEnemy.transform.position.x > transform.position.x - margin && targetEnemy.transform.position.x < transform.position.x + margin)
    	    {
    	        Destroy(targetEnemy);
    	    }
    	}
	}
}
```
Dit is een slecht voorbeeld omdat je eerst de hele update moet lezen voordat je snapt wat je nu precies wilt doen. En je doet eigenlijk best wel wat. Je intentie is hier niet gelijk duidelijk.

###### Goed voorbeeld

```c#
public void Update(){
	if (EnemiesLeft())
	{
    	UpdateEnemies();
	}
}

public void UpdateEnemies(){
    foreach (Enemy targetEnemy in enemies)
    {
        targetEnemy.Update();
        if(IsColliding(targetEnemy))
    	{
    	    Destroy(targetEnemy);
    	}
    }
}

public bool IsColliding(GameObject targetGameObject){
    return targetGameObject.transform.position.x > transform.position.x - margin && targetGameObject.transform.position.x < transform.position.x + margin;
}
```
Hierboven heb ik de code opgeschoont. Deze 'leest' een stuk lekkerder. Je weet steeds gelijk wat de developer wil doen en wat de intentie is.
In de update zie je gelijk "ooh, je wil weten of er nog enemies zijn", gevolgd door "als er nog enemies zijn, dan wil je die updaten". Duidelijke intentie.
In de UpdateEnemies zie je zelfs dat ik de colliding check weg heb gestopt in een IsColliding() functie. Dit maakt deze check weer een stuk taliger en daarmee leesbaarder. Functies maken je code vele malen leesbaarder.

###### best practise: instelbaarheid

Maak gebruik van de unity editor om je classes instelbaar te maken. Elk getalletje (snelheid, kracht, etc.) of bijvoorbeeld een string (tag, name, etc.) wil je kunnen instellen. Dit maakt je code meer flexibel en herbruikbaar.

###### open closed principe

Probeer je code 'open' voor extensies te maken, maar gesloten voor aanpassingen.
Wat bedoelen we hiermee?

Stel we maken verschillende wapens voor onze game. Dan wil je graag dat je makkelijk nieuwe wapen classes kunt maken die overerven van het 'basiswapen'.
Dus bijvoorbeeld:

```c#
public class LaserCanon : Weapon {
}
```

Je wil niet dat je 'hard' iets moet aanpassen in de code.
Een goede 'code smell' zijn if()jes en switch cases. Eigenlijk moet je een if() alleen gebruiken om een true false te checken. Niet om gedrag af te wisselen.

Slecht voorbeeld:

```c#
if(newItem == "weapon")
{
    // do something specific
}
else if(newItem == "map")
{
    // do something else
}
```

De code hierboven is fout omdat je niet voldoet aan de 'open/closed' principe. Als je een nieuw item wil toevoegen dan moet je deze if/then/else uitbreiden. Oftewel je moet hard code aanpassen.
Daarom noemen we een switch en if ook wel een code smell. Omdat er bijna altijd iets 'hardcoded' wordt.
Twijfel je hoe je iets laat voldoen aan het open/closed principe? Laat het weten, we helpen graag :)

Classes, interfaces en dictionaries helpen bij het voldoen aan het open/closed principe.

Zie hieronder voor handige presentaties die je wat uitleggen over dit soort onderwerpen.

# Presentaties

Om presentaties te kunnen bekijken op SRC Review moet je je eerst aanmelden. Log in met je GitHub gegevens.
Vervolgens wordt er om een code gevraagd. Jullie kunnen je aanmelden als student. Gebruik daarvoor deze code: 5840246412acdbba75ea6b4c

Je kunt naar de volgende/vorige slide met de pijltjes toetsen.

Open closed principe: http://staging.srcreview.com/#!/presentations/5e7b60ee15943536df633cb3

Dictionaries (basis): http://staging.srcreview.com/#!/presentations/5e787ecf15943536df63309a

Dictionaries (how to): http://staging.srcreview.com/#!/presentations/5e81a1bb15943536df634a22

