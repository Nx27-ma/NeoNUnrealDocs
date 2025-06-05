# AI Pathfinding.

Voor het uitrekenen van het pad gebruiken we het A\* algoritme. Dit staat in een script genaamd &quot;Enemy AI&quot; (het is niet specifiek alleen voor enemies, je zou het overal op kunnen zetten zolang je een target instelt).

## Welke scripts heeft mijn object nodig?

Er staat een &quot;Enemy&quot; prefab in de folder: Assets/Prefabs/Enemies het is aangeraden om die te gebruiken.

- Seeker
- Rigidbody
- Enemy AI
- State Machine
- Resterende pathfinding states

## Hoe maak ik een State behaviour aan voor de pathfinding?

Uiteraard wil je dat het enemy object bepaalde behaviour heeft, hiervoor kan je &quot;PathfindingStates&quot; maken. Die werkt met de &quot;StateMachine&quot; hou er dus rekening mee dat de statemachine script op het enemy object zit met de EnemyState data.

Om een pathfinding state te maken maak je een nieuw script die extend van &quot;PathfindingState&quot;, zo zou dat eruit moeten zien:
<img width="600px" src="images/pathfinding/screenshot-1.png"/>

&quot;GetCurrentTarget&quot; schrijf je de code in om aan te duiden waar het enemy object naar toe moet gaan.

Hier zie je een voorbeeld hoe de CurrentTarget word bepaald in de &quot;PatrolState&quot;

<img width="600px" src="images/pathfinding/screenshot-2.png"/>

In de PathfindingState class heb je een functie genaamd &quot;OnPathComplete&quot; die je kan overerven en zou je op verschillende manieren kunnen gebruiken, deze functie word uitgevoerd als de &quot;EnemyAI&quot; klaar is met zijn path, in het onderstaande voorbeeld in de PatrolState word de OnPathComplete gebruikt om een nieuwe target aan te geven.

<img width="600px" src="images/pathfinding/screenshot-3.png"/>

Verder is het handig om van de &quot;OnEnter&quot; functie gebruik te maken, dit is een functie die je overerft van de &quot;StateBehaviour&quot; class, deze functie word uitgevoerd wanneer de state word ingeschakeld. Je zou dit kunnen zien als de Start() functie van Unity zelf.

<img width="600px" src="images/pathfinding/screenshot-4.png"/>

## Hoe stel ik de scene in zodat de pathfinding werkt?

In de folder Assets/Prefabs/AStar zie je een prefab genaamd &quot;AStar&quot;

<img width="600px" src="images/pathfinding/screenshot-5.png"/>

Dit object sleep je in de scene, vervolgens moet je de &quot;Obstacle&quot; objecten instellen zodat AStar ze kan detecteren ( **LET OP:** Ieder obstacle object heeft een collider nodig om gedetecteerd te worden.)

## Hoe stel ik objecten in?

In dit voorbeeld gebruik ik dit object:

<img width="600px" src="images/pathfinding/screenshot-6.png"/>

Klik op het object en je ziet rechtsboven in de inspector &quot;Layer&quot;

<img width="600px" src="images/pathfinding/screenshot-7.png"/>

Je moet de layer aanpassen naar &quot;Obstacle&quot;

<img width="600px" src="images/pathfinding/screenshot-8.png"/>

Zo zou het er vervolgens uit moeten zien.

**LET OP:** Omdat dit een &quot;Ferr2D&quot; object is moet je een extra stap nemen om te zorgen dat het werkt, je moet de collider prebuilden. Dit doe je door een klein beetje naar onder te scrollen totdat je de &quot;Path Terrain&quot; component ziet, in die component zie je helemaal onderaan een sectie met &quot;COLLIDER&quot; en vervolgens in die sectie zie je staan &quot;Prebuild collider&quot;, klik daar op.

<img width="600px" src="images/pathfinding/screenshot-9.png"/>

Vervolgens klik je op het AStar object in de hierarchy en scroll je helemaal naar onder totdat je &quot;Scan&quot; ziet staan

<img width="600px" src="images/pathfinding/screenshot-10.png"/>

Hier moet je op klikken en als het goed is zie je dan rode vierkantjes om het object verschijnen.

<img width="600px" src="images/pathfinding/screenshot-11.png"/>

Zo zou dat er vervolgens uit moeten zien. Als het goed is gegaan verschijnen de rode vierkantjes aan de zijkanten van het object (dat indiceert dat dat de zijkanten zijn ofterwijl, waar je niet tegen aan mag lopen)

Bij een non-Ferr2D object doe je dezelfde stappen, enkel voeg je dan nog aan het object een collider naar keuze toe (bijvoorbeeld een box collider).
