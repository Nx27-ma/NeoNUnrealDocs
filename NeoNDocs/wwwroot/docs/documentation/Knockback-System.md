## Knockback system

Het knockback systeem maakt gebruik van het
[force system](https://github.com/BAStudio/OperationStarfall/wiki/Force-System). Om knockback te hebben moet er in de scene een KnockbackSystem gameobject aanwezig zijn. In dit object kan je allemaal instellingen aanpassen. De instellingen zijn:
<br><br>

Instelling | Uitleg
:-----------|:------------
KnockbackList | Dit is een lijst met presets voor verschillende knockback types. Deze presets gebruiken een knockback id (bijv. ProjectileHit, SwordSlash of GroundSlam) en een force. Hier stel je de knockback sterkte in als je bijvoorbeeld iets slaat.<br> ![Example](https://cdn.discordapp.com/attachments/784744807557890082/963348306568818698/unknown.png)
Default Knockback Force | Dit is de default knockback die gebruikt wordt als de er geen preset voor een specifieke knockback type is.
Bounce Knockback Force | Dit is de force die gebruikt wordt als iets stuitert. **Belangrijk is dat de force type moet op stack staan. En de id op bounce.** Om ervoor te zorgen dat alles correct kan stuiteren.
Ground Check Margin | Dit is de margin die ervoor zorgt dat wanneer een object aan het stuiteren is, uiteindelijk grounded wordt. Hoe groter de margin, hoe eerder het object grounded is.
Bounce Threshold | Als de desired velocity van het object kleiner is dan de bounce threshold, stopt het object met stuiteren. Dus dit zorgt ervoor hoelang een object mag blijven door stuiteren.

<br>

### Hoe werkt het knockback systeem?

Het knockback systeem kijkt eerst of een object custom knockback settings heeft, zo ja dan gebruikt het systeem die knockback settings. Anders kijkt het systeem of er een preset voor dat type knockback gemaakt is. Als dat ook niet het geval is gaat het knockback systeem een default knockback toevoegen als dat object überhaupt knockback mag ontvangen.<br><br>

### Hoe gebruik je het knockback system?

Methods | Uitleg
:-----------|:------------
AddKnockback() | Voeg een nieuwe knockback force toe aan een object.

#### Voorbeeld:
```c#
 KnockbackSystem.Instance.AddKnockback(hitObject, _direction.x, KnockbackIds.BulletHit);
```

In dit voorbeeld voegen we knockback toe aan een projectile. Hiervoor gebruiken we dus ook de  knockback id die erbij past. Je kan gewoon de instance oproepen:

<br>

### Custom knockback
Als een object een custom knockback script heeft, worden die setttings gebruikt inplaats van de presets in de knockback list en de default knockback. 
Als je bijvoorbeeld wil dat een object geen knockback kan ontvangen, kan je er een CustomKnockback script op doen en isKnockable op false zetten.<br><br>Dit is handing, want wellicht wil je dat een object altijd dezelfde knockback krijgt. In dat geval gebruik je dus een custom knockback script.

![Custom knockback](https://cdn.discordapp.com/attachments/784744807557890082/963364266562424852/unknown.png)