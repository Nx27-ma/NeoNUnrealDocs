# Render Feature Generator
Als je ooit games hebt gemaakt of gespeeld, dan heb je vast weleens van Post Processing gehoord. Post Processing is een krachtig hulpmiddel in Unity dat je helpt om visuele effecten toe te voegen aan je game, waardoor de grafische kwaliteit aanzienlijk verbeterd kan worden. Een veel gebruikt voorbeeld hiervan is Bloom, een effect dat zorgt voor een gloeiend licht rondom heldere objecten, waardoor deze objecten er realistischer en dynamischer uitzien.

Tussen de standaard Post Processing effecten van Unity zitten mogelijk niet alle effecten die je zou willen hebben. Als je extra effecten zou willen gebruiken, dan kan je je eigen shaders hiervoor maken. 

Normaal gesproken moet je hiervoor een aantal verschillende dingen doen om dit voor elkaar te krijgen, maar deze tool helpt jou om dit proces te versimpelen. Als je al een shader hebt aangemaakt, dan zijn er nog maar een paar kleine handelingen die je hoeft te doen om die shader te laten werken met Post Processing.

## Shader Aanmaken
Ten eerste moet je natuurlijk een shader aanmaken, waarin je je eigen Post Process effect in verwerkt. Hier zijn dan wel een paar voorwaarden aan verbonden. Aangezien je te maken hebt met een Post Process effect, moet je shader niet de standaard Lit/Unlit shader zijn, maar een Fullscreen Shader zijn. Dit is een setting binnen in je Shader Graph - Graph Inspector.

<img width="306px" src="images/RFGFullScreen.png"/>

Nadat je de shader Fullscreen hebt gemaakt, is er nog 1 andere belangrijke node die je moet gebruiken in je shader, de “URP Sample Buffer” node. Deze node zorgt ervoor dat je screen color pakt die door Unity’s eigen render pipeline heen gaat, vervolgens door jouw shader aangepast wordt, en dan weer teruggestopt wordt in de render pipeline. Normaal gesproken zou je hiervoor de “Scene Color” node gebruiken, maar dit zorgt ervoor dat er veel objecten niet gerenderd worden.

<img width="602px" src="images/RFGURPSampleBuffer.png"/>

## De Tool
Nu je shader op de juiste manier aangemaakt is, is het tijd om de tool te gebruiken om je shader te verwerken in de Post Processing. Bovenin het project, onder het kopje “Neon” vind je de tool met de naam “Render Feature Generator”.

<img width="235px" src="images/RFGRenderFeatureGenerator.png"/>

## Shader Assignen
Wanneer je deze opent zie je gelijk 2 dingen die je moet assignen, de naam en de shader. Als het goed is zou je met de naamgeving niet veel fout kunnen doen, maar houd je vooral vast aan PascalCasing. Daarnaast selecteer je ook je shader en kan je klikken op “Load Shader Properties”.

<img width="412px" src="images/RFGAssignVariables.png"/>
<img width="410px" src="images/RFGLoadVariables.png"/>

## Properties Laden
Je ziet nu een aantal properties verschijnen. Dit zijn alle properties die te vinden zijn binnen de shader die je hebt gekozen. Als er properties gevonden zijn die je niet gebruikt in je shader, dan kan je deze verwijderen. Daarnaast als er properties ontbreken, kan je deze ook zelf toevoegen.

<img width="364px" src="images/RFGSetVariables.png"/>
<img width="226px" src="images/RFGCheckVariables.png"/>

## Properties Types Assignen
Zorg er ook voor dat je de juiste variabele types kiest voor elke variabele die je hebt aangemaakt. Wanneer je shader geladen wordt, staan al deze variabelen op type ‘float’, maar als je bijvoorbeeld een ‘Color’ of ‘Vector2’ gebruikt, dan moet je deze zelf nog selecteren.

<img width="419px" src="images/RFGVariableTypes.png"/>

## Scripts Genereren
Als je alle juiste properties hebt gekozen, dan kan je nu klikken op “Create Render Feature”. Na een tijdje laden zijn er een aantal scripts aangemaakt en is de shader toegevoegd aan de Forward Renderer en de Post Process Volume.

<img width="295px" src="images/RFGGeneratedFiles.png"/>
<img width="292px" src="images/RFGVolumeComponent.png"/>
<img width="271px" src="images/RFGForwardRenderer.png"/>

## Effect in Werking
In de Post Process Volume zie je dan ook de variabelen die je hebt gekozen, waarbij je deze aan kan passen. Als je deze waarden naar behoren aanpast, dan kan je al direct in de scene view en de game view je eigen gemaakte effect toegepast zien worden. 

<img width="600px" src="images/RFGEffect.png"/>

## Variabelen in scripts
Momenteel kan je met de waarden van je Post Process volume alle kanten op. Misschien wil je dat je ‘strength’ maar tussen 0 en 1 kan zijn. Misschien wil je dat ‘speed’ niet lager kan zijn dan 0. Hiervoor kan je de aangemaakte scripts openen om dit meer naar behoren te maken. Het script dat je daarvoor nodig hebt is “Naam” + “VolumeComponent”, waarin “Naam” je eigen ingevulde naam is. Hierin zie je dan alle properties die je hebt gekozen weergegeven als, FloatParameter, ColorParameter, Vector2Parameter, etc. 

<img width="600px" src="images/RFGScriptVariables.png"/>

## Parameters Aanpassen
Er zijn dus een aantal opties mogelijk waarbij je kunt aangeven dat je een minimumwaarde wilt hebben, een maximumwaarde wilt hebben, of een waarde tussen 2 waarden wilt hebben. Hieronder zijn dan een aantal voorbeelden. 

<img width="600px" src="images/RFGParameterExamples.png"/>

## IsActive()
In dit geval zie je 'value' 5 ingevuld. Dit is de standaardwaarde die aangehouden wordt, voor wanneer je het effect toevoegt aan een Post Process Volume of wanneer je effect uitstaat. Het kan voorkomen dat wanneer je je effect verwijdert van de Post Process Volume, dat het effect nog steeds actief is. Dit komt door het stukje code “IsActive()”. Hierin wil je meegeven wanneer je shader active moet zijn en wanneer niet. Momenteel staat het op ‘true’, wat betekent dat altijd aanstaat met minimaal je standaardwaarden die erboven zijn aangemaakt. 

<img width="346px" src="images/RFGIsActive.png"/>

Als je bijvoorbeeld wilt hebben dat je shader alleen aan staat wanneer je ‘strength’ groter is dan 0, dan kan je dat achter de ‘IsActive()’ zetten. Daarbij is het wel handig om je standaardwaarde voor ‘strength’ ook op een value te zetten die ervoor zorgt dat ‘IsActive()’ false teruggeeft. In dit geval staat de standaardwaarde van ‘strength’ op 0, waardoor dit effect niet aanstaat wanneer je effect niet is toegevoegd aan een Post Process Volume.

<img width="395px" src="images/RFGIsActiveExamples.png"/>

## Eindresultaat
Uiteindelijk kan je dan zelf verschillende effecten maken en combineren, totdat je een resultaat bereikt waar je blij mee bent. Hieronder is dan een voorbeeld van 3 verschillende effecten die zelfgemaakt zijn en samenwerken tot een geheel.

<img width="600px" src="images/RFGResults.png"/>