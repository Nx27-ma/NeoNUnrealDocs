## Loot table

In the loot table you can change up the rules of how the table will drop the loot. Because the loot tables are scriptable objects, you can make different loot tables for different kind of objects. As example the drone enemy has a different loot table than the boss. 

Loot table name example | loot example
:-----------|:------------
DroneLootTable    | Drops a small amount of xp and drops only a beginner sword
BossLootTable    | Drops a big amount of xp and health orbs and it drops a legendary bow
ChestLootTable    | Drops couple crystals and has a chance to get a epic item
 
<br>

### Creating a loot table
You can create a new loot table when you right click in a project folder and use the create menu. After you create the table you can see it in your project folder

![HowToCreateLootTable](https://github.com/BAStudio/OperationStarfall/assets/91124861/75f8399a-f898-4084-990d-c2475d9f3166)

<br>

### Set up the loot table

## Guaranteed drops

Within the guaranteed drops you can setup drop variants. The drops that you setup in this list will ALWAYS drop. Every drop variant has his own customizable setting.
   
Guaranteed drop variant settings | Explanation
:-----------|:------------
Drop variant | This is the item you would like to drop
Amount option | With this you can select if you would like to drop a specific amount or you would like to get a random amount between two values
Drop amount | This is the amount of how many of this item will drop at ones based on the amount option
Delete item | this is the button that delete the item from the geuranteed drops

<br>

## Loot drops

### Loot drop section

#### Chance gradient
The first thing you can find underneath the loot drops label is the chance gradient. 
Every time you add a new loot drop secntion you can see the chance that this loot will drop in compared to other loot drop sections in the list. The bigger the color is on the gradient the bigger the chance is that you will get the loot drop section.

If you add an loot drop section the gradient will NOT be sorted right away. If you would like to sort the chance gredient you need to press the `Sort loot drop variant list` button. This button will also sort the list of loot drop sections. The list will be organized from largest chance to drop to the smallest chance to drop. 

### Example 1
2 items have a 50% chance to drop

![GradientBar](https://github.com/BAStudio/OperationStarfall/assets/90682539/2d922588-20a4-4186-b58f-5b17eef63db8)

### Example 2
The first item has a 70% drop chance the second item has 20 % chance and the last has 10% chance

![GradientBar2](https://github.com/BAStudio/OperationStarfall/assets/90682539/cabff9c4-7acc-418a-891a-697d20930ab3) 

Loot drop section Settings | Explanation
:-----------|:------------
Loot drop color | This is how you can see which loot drop you are looking at on the chance gradient
Item weight | This is the weight the item have compared to the other items. The higher the weight is the more chance you have to get this item (Behind this label you will see how much chance you have to get this item) 
Add new loot variant (Button) | This is how you add a new loot variant to the loot drop section
Delete loot section (button) | This is the button to deled the hole loot drop section

## Loot drop variants

Within loot drop sections you have a button `Add new loot variant`. If you press this button an item will be added to the loot section. 

When you add the item the button will say `Empty` if you add a item to the drop variant objectfield the name on the button will change to the item name you selected.

### Example
Empty drop variant

![EmptyButton](https://github.com/BAStudio/OperationStarfall/assets/90682539/38054894-05c1-49aa-b808-986f03366187)

### Example
This is when you selected a item in the drop variant objectfield

![ItemButton](https://github.com/BAStudio/OperationStarfall/assets/90682539/94b1f884-ca52-4541-a346-b4007cfbc0d4)

## Loot drop settings 

Loot drop variant Settings | Explanation
:-----------|:------------
Loot drop variant | This is the item you would like to drop
Amount option |  With this you can select if you would like to drop a specific amount or you would like to get a random amount between two values
Drop amount | This is the amount of how many of this item will drop at ones based on the amount option
Delete item | This is the button to delete the item from the loot drop section
 
## Loot Force

The Loot Force is a scriptable object that is used to give loot items a force when they are initiated 

Loot drop Settings | Explanation
:-----------|:------------
Min Force Direction | The minimum force that the item get on the x and y when it drops
Max Force Direction | The maximum force that the item get on the x and y when it drops
Item Drop Force | This is the custom force that the items are dropped with. If you want to read more on the [Force System](https://github.com/BAStudio/OperationStarfall/wiki/Force-System#force) click the link
Base Size | The regular x and y size of the object with this script

<br>

### Creating a loot force

You can create a new loot force when you right click in a project folder and use the create menu. After you create the table you can see it in your project folder

![HowToCreateLootForce](https://github.com/BAStudio/OperationStarfall/assets/91124861/d2f7ed62-b29a-489e-b786-1a53a3407f7a)

<br>

## Loot simulator

The loot simulator is a custom editor that simulates the loot drop script and shows you the results.

### How to use Loot Simulator

To use the simulator you need to first add the `LootDrop.cs` script to an object.
<br>
![Add LootDrop.cs](https://github.com/BAStudio/OperationStarfall/assets/91124861/ccb6042f-d458-4caf-b721-44fffe9318fa)

<br>

Then you have to add a loot table, if you want to test the loot force add that too. 
<br>
![LootDrop.cs with LootTable and LootForce](https://github.com/BAStudio/OperationStarfall/assets/91124861/39bdda06-296c-431b-925f-a946d079578a)

<br>

The loot force test is only testable if the game is playing else it wont have an effect. 

<br>

Then slide the slider to choose how many rolls to simulate and press `Roll loot drop`
<br>
![LootDrop slider and Roll loot drop button](https://github.com/BAStudio/OperationStarfall/assets/91124861/f0021109-7413-42b1-a9f4-682dca5b331c)
<br>


## Drop loot class

This is the class that that holds the lootTable and LootForce. The class calls the LootSystem with the rules of the lootTable and LootForce that its been given. 

You can call a method named  `DropLoot()`. This method allows the loot to drop. 

### Calling the DropLoot method

#### Example:

![LootDropMethodAanroepen](https://user-images.githubusercontent.com/90682539/225602143-6e3e3378-9007-43eb-a4e9-7cf3e93a99b8.png)

This example will roll one loot drop on the death of the game object with this script
<br>

### Editor settings

Loot drop Settings | Explanation
:-----------|:------------
Loot Table | This is the loot table the class that holds the obligatory items and chance items and their chance rate 
Loot Force | This is the loot force the class that holds the minimum and maximum force at which to drop the items 

<br>

### Loot System methods

Methods | Explanation
:-----------|:------------
ChooseLoot() | This is one of 2 methods you can call to start the loot drop and store the `lootTable` and `lootForce` and `Transform` (Example: you can use this in a unity event)
RollLoot() | This is one of 2 methods you can call to start the loot drop and store the `lootTable`, `lootForce` and `Transform` this method returns an array of GameObjects
DropRequiredItems() | This method first checks if the `lootTable` has required drops and if it does it calls `DropItem()` on them all to drop them
DropChanceItems() | This method checks if the `lootTable` has chance items, if it does it will check `WillChanceItemsDrop()` if it should drop an element, then it checks which element to drop with `GetElement(CalculateDropChance())`, when it does drop it will by calling `DropItem()` on all items in this element
WillChanceItemsDrop() | Get a random number between 0.0 and 1.0. After that it check if the random number is bigger than the `lootTable`.chanceItemDropRate, If it is bigger the item will drop, if its smaller it will not
CalculateDropChance() | Returns a random number between 0 and `CalculateTotalDropChance()`
CalculateTotalDropChance() | This method adds all chance elements drop chance together and returns it as a float
PickRandomItems (`targetList` , `maxItems`) | Picks a random item from the `targetList` `maxItems` amount of times
GetElement(`randomNumber`) | It will loop over all the elements in the `LootTable`.chanceDrops list and look if the `randomNumber` is smaller or equal to the dropChance of the element. If this is false the dropChance will be subtract from the `randomNumber`, after that the loop goes to the next element. Otherwise if it is true the element get returned
DropItem (`item`) | Checks if the game is playing if it is it will InstantianteItem(`item`)
InstantianteItem(`item`) | This method instantiates the `item` adds a force body to it and adds a random force between `lootForce`.minForce and `lootForce`.maxForce and multiplies that with (`Transform`.scale divided by `lootForce`.baseSize)

