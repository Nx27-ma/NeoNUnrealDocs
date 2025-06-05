## Force System

De Unity rigidbody heeft functies zoals addForce(). Helaas zijn deze forces voor onze game onvoldoende in te stellen. Het Unity Physics systeem is zo te algemeen voor ons.
Bij deze game willen we juist veel grip hebben op de forces. 

Hoe 'pull' jij je met een onzichtbare kracht ergens naar toe bijvoorbeeld? Dit willen tot in detail in kunnen stellen.
Ook willen we grip hebben op welke forces er actief zijn en misschien nog wel belangrijker: welke niet.
Zo wil je soms alle forces freezen, zodat een karakter even stilhangt omdat hij wordt geraakt door iets. Of een object krijgt zo'n klap dat even alle forces niet werken behalve deze klap.

Om deze reden zijn we gestart met ons eigen:

<img width="1000px" src="images/ForceSystem.jpg"/>

#### Wat gebruiken we wel van Unity:

- Colliders
- Raycasts

#### Wat gebruiken we niet van Unity:

- Rigidbody

Inplaats van de RigidBody gebruiken we onze ForceBody.

### Force

Het start in ons systeem allemaal met een 'Force'.
- Een speler die wil springen - jump force
- Een speler die zich ergens naar toe pulled - pull force
- Een speler die objecten wegbeukt - push force
- Een speler die enemies een klap geeft - hit force
- Een entity die met zwaartekracht naar beneden wil vallen - gravity force
- enz.

Het zijn allemaal 'forces'.
Het grote verschil met de Rigidbody forces, is dat deze forces meer instellingen hebben. Zo kun je bijvoorbeeld instellen hoelang een force werkt en hoe de 'curve' is van de force.
Laten we hier eens wat gedetailleerder naar kijken.

<img width="682px" src="images/ForceVoorbeeld.png"/>

Hierboven zie je een screenshot van zo'n force. Een Force is 'serializable' waardoor we hem in de editor kunnen instellen. Wat kun je hier allemaal instellen:

Instelling | Uitleg
:-----------|:------------
Id | Een unieke id om forces van elkaar te kunnen onderscheiden. Hierdoor kun je bijvoorbeeld specifieke forces weer verwijderen, pauzeren, etc.
Direction | De richting EN impact van de force. Je kan dit instellen op de x, y en z as. Over het algemeen staat in deze game de z as op 0 aangezien we een 2.5d game maken. De direction kunnen we ook dynamisch aanpassen vanuit code. Dit is bijvoorbeeld handig als je ergens tegenaan slaat en je wilt dat het object die richting op vliegt.
Duration | Hiermee stel je in hoelang de force over de direction doet. Een force kan ook 'altijd' werken. Zie hiervoor de instelling 'type'.
Delay | Hoelang duur het voordat deze force actief wordt (default 0)
Curve | Hiermee kan je precies plotten hoe de force 'eased'. <br><img width="504px" src="images/SurfaceCurve.jpg"/><br />. De direction bepaald wat de impact is van de force. Deze impact wordt verdeeld over de oppervlakte van de curve. Hoe je de curve ook tekent, de direction/impact blijft hetzelfde. Als je je curve precies op de value 0 laat eindigen dan heeft de force geen residual force. <br /><img width="504px" src="images/NoResidualForce.jpg"/><br />. Als de value niet op 0 eindigt dan hou je een residual force over. <br /><img width="504px" src="images/ResidualForce.jpg"/> 
Blend Type | Hiermee stel je in hoe deze force blend met de andere forces voor dit object. Opties zijn: Blend, Mute others, Pause others, Remove others.
Type | Hiermee geef je aan wat voor een type force dit is. Opties zijn: Default, Collision (deze bestaan tot het object ergens tegenaan collide), Single Addition, Continuous, Gravity.
Is Unique Id | Hiermee stel je in of deze force uniek is. Als er al een force is met hetzelfde ID dan overschrijft deze force de oudere.
Disables Gravity | Hiermee stel je in of deze force de zwaartekracht uitschakelt (zolang deze force actief is).
Priority | wordt nu nog niet gebruikt

### Hoe gebruik je het force systeem bij een game object?

Voeg het ForceBody component toe aan elk object dat met het force systeem moet kunnen werken.
Dit geldt ook voor objecten die alleen maar zwaartekracht hoeven te hebben. Het forcebody component heeft een boolean waarmee je instelt of je wel of niet zwaartekracht wilt toepassen.

Het ForceBody component heeft vervolgens verschillende Methods om de forces te beinvloeden.

Method | Uitleg
:-----------|:------------
Add | Voeg een nieuwe force toe aan het gameobject
SetPosition(targetPosition, desiredDirection?) | Zet de positie van de forcebody op de gewilde positie, als de forcebody in het terrain komt. Er kan een voorkeur geven worden naar welke kant de forcebody op moet
Remove(ForceType) | Verwijder een force van een bepaald type
Remove(ForceId) | Verwijder een force met een bepaalde ID
ClearForces() | Verwijder alle forces

Properties van een ForceBody:

Property | Uitleg
:-----------|:------------
IsEnabled | Boolean om mee in te stellen of de forces enabled zijn of niet
GravityScale | Multiplier voor de zwaartekracht (default 1)
Velocity | Getter voor de huidige velocity. Dit is een samenvoeging van alle forces.
