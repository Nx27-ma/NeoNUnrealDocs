# Prefab Library

In ons project hebben we een Custom Editor Window ontwikkeld dat het proces van prefabs instantiëren in levels vereenvoudigt. Dit systeem maakt het niet alleen makkelijker om prefabs te plaatsen, maar zorgt er ook voor dat ze correct zijn ingesteld zodra ze in het level worden geplaatst. De prefabs zijn ingedeeld in (sub)categorieën, wat navigatie in het menu vergemakkelijkt.

## Overzicht van het Systeem

Het systeem maakt gebruik van twee belangrijke componenten: `PrefabLibrary` en `PrefabLibraryData`.

- `PrefabLibrary` is een Custom Editor Window dat een interface biedt voor het selecteren en plaatsen van prefabs.
- `PrefabLibraryData` is een ScriptableObject dat de data van alle beschikbare prefab categorieën en de prefabs zelf bevat.

## Gebruik

Om een prefab te plaatsen, opent de gebruiker het Prefab Library venster en navigeert door de categorieën. Bij het selecteren van een prefab, wordt deze automatisch geïnstantieerd in de scene. Dit proces vereenvoudigt de workflow aanzienlijk en zorgt ervoor dat alle prefabs correct zijn geconfigureerd voor gebruik.

## Werking

### PrefabLibrary Klasse

De `PrefabLibrary` klasse creëert een nieuw menu-item in de Unity Editor onder "NeoN/Prefab Library". Wanneer geopend, toont dit venster een lijst van beschikbare prefab categorieën, die elk kunnen worden uitgeklapt om de prefabs weer te geven die ze bevatten.

### PrefabLibraryData Klasse

`PrefabLibraryData` slaat de structuur op van prefab categorieën, inclusief hun namen, kleuren, en de prefabs die ze bevatten. Dit maakt het eenvoudig om nieuwe prefabs en categorieën toe te voegen zonder directe wijzigingen in de code.

#### Structuur:

- **PrefabCategory:** Een struct die informatie over een enkele categorie bevat, zoals de kleur, naam, de lijst van prefabs, en eventuele subcategorieën.
