# Component Filter

De Component Filter staat users toe om op elke Gameobject en Prefab components te filteren op basis van labels en search text. Deze labels zijn instelbaar in de Component Collection Scriptable object, die te vinden is in de `Editor/CustomInspector` folder.

Script | Uitleg
:-----------|:------------
`ComponentFilter.cs`              | De grafische indeling van de Component Filter en tevens ook de "manager" van alle bijbehorende scripts.
`ComponentEditor.cs`              | De Editorwindow waar je Components aan Categories kan toevoegen en verwijderen.          
`ComponentCategoriser.cs`         | Dit script handelt de zelf reflectie tussen de component collection en de components die op de target object staan.
`ComponentCategories.cs`          | Enum waar alle categorieën in staan.
`ComponentCategorySettings.cs`    | Manager van de component category settings.
`ComponentCollection.asset`       | Component Collection scriptable object waar alle gedecteerde scripts in staan.
`ComponentCollectionInspector.cs` | Custom Inspector voor de `ComponentCollection.asset`.
`ComponentTools.cs`               | Hier staan verschillende "tools" in die te maken hebben met de component view in de inspector.
`StaticPopupWindow.cs`            | Window voor de IsStatic toggle button.

## Inspector Tools

### Component Filter
De inspector van GameObjects/Prefabs heeft een aantal nieuwe features, waaronder een search engine en labels waarmee je components kunt filteren in de Inspector. Deze labels zijn instelbaar in de ComponentCollection ScriptableObject.

Inspector State | Uitleg
:-----------|:------------
<img src="https://user-images.githubusercontent.com/71002222/207319025-48106aae-966a-4751-b5c5-64a4f877b79c.png" width="500"> | Dit is de standaard inspector state. Er staat altijd een All en een Other label. Met All krijg je alle components te zien en met Other alle components die niet gelabeld zijn. 
<img src="https://user-images.githubusercontent.com/71002222/207319168-3d470a6e-8aca-437a-9616-36d2953eece3.png" width="500"> | Dit is hoe het er uit ziet als er scripts op zitten die gelabeld zijn. 
<img src="https://user-images.githubusercontent.com/71002222/207319518-252fd5c1-e794-4cab-8f8c-9e9949080b98.png" width="500"> | Hier zie je de Component Filter collapsed. Om hem te collapsen en weer te expanden klik je op de kleine arrow voor de Component Search Engine text.
<img src="https://user-images.githubusercontent.com/71002222/207319695-a6442c51-dece-437f-abad-9713372bcbe5.png" width="500"> | De inspector wanneer een label geselecteerd is. Components die niet het geselecteerde label hebben worden verstopt in de inspector window.
<img src="https://user-images.githubusercontent.com/71002222/207352716-118da125-daf2-4b58-bd17-8cec01e64f32.png" width="500"> | Met search text ingevuld. De Component Filter filtert de components op basis van wat er ingetoetst is. Dat kan dus ook één letter zijn.

### Component Collection
<img align="right" src="https://user-images.githubusercontent.com/71002222/207355144-8b792744-7c77-4310-94f5-ec86288fb962.png" width="500">
De Component Collection is een Scriptable object die te vinden is in de Editor folder. Deze scriptable object is een database met alle components en hun bijbehorend ingestelde labels. Deze database is compleet automatisch in te vullen en de lijst kan volledig vanuit zichzelf aangepast worden.

#### Hoe het werkt
Ongeacht van hoe het ingevuld is, zal er altijd een Other categorie automatisch worden aangemaakt. Wanneer een gameobject wordt geselecteerd in de inspector, kijkt de database of er op het gameobject components staan die nog niet in de collection zijn opgeslagen. Als dit het geval is, worden deze toegevoegd aan de Other categorie.

Vervolgens kan je via de ComponentEditor window in de NeoN dropdown de components toevoegen aan bestaande categorieën.  

###### Note: Je kan components niet verplaatsen naar de `All` categorie. Deze wordt niet gebruikt in de collection.

###### Note: Sleep niet zelf monoscripts vanuit de project folder naar de collection! Selecteer in plaats daarvan het object waar dit script op staat.

#
#
#

### Component Categorizer
<img align="left" src="https://github.com/BAStudio/OperationStarfall/assets/90763311/6067add7-0b7a-4691-900e-90ab55bb0564">
De Component Categorizer window is een custom editor window die de categorisatie van scripts makkelijker maakt. In deze window kan je in de objectfield bovenaan een script slepen die je wil categoriseren. Ook kun je eenvoudig de settings van een component openen door op de drie puntjes te klikken bij een component (in de inspector) en kiezen voor 'Manage component categories'. 
Vervolgens kan je in deze window aan de linkerkant zien aan welke categorieën dit script al geassocieerd is in text en rechts in toggle-able categorieën. Als je je geselecteerde script wil toevoegen aan een categorie doe je dat aan de rechter kant door een box aan te vinken.

#### Nieuwe categorieën toevoegen
Je kan ook nieuwe categorieën creëren. hier word aanbevolen om de PlaceHolderCategory te selecteren en te copy-en.

###### Note: Je kan nog niet nieuwe categorieën toevoegen via deze window, die worden niet opgeslagen.
###### Note: De nieuw toegevoegde categorieën zullen niet verschijnen in de component filter, maar de scripts die zijn toegevoegd aan deze categorieën blijven wel opgeslagen