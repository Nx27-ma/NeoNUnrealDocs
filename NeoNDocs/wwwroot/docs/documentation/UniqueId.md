# Systeem voor Unieke ID's voor Prefabs

In OperationStarfall hebben we een systeem ontwikkeld dat unieke ID's toekent aan prefabs. Dit stelt ons in staat om instellingen op te slaan in een database die gekoppeld kunnen worden aan een prefab op basis van dit ID. Dit document beschrijft hoe dit systeem werkt.

## Overzicht

Het systeem maakt gebruik van twee belangrijke componenten: `UniqueIdLibrary` en `UniqueID`.

- `UniqueIdLibrary` fungeert als een centrale opslagplaats waar alle unieke ID's en hun bijbehorende GameObjects worden bijgehouden.
- `UniqueID` is een component die aan een GameObject wordt toegevoegd om het een uniek ID te geven.

## Werking

### UniqueIdLibrary Klasse

De `UniqueIdLibrary` klasse is een singleton die een serialiseerbare dictionary bevat, `uniqueIDLibrary`, waarin unieke ID's worden gekoppeld aan GameObjects.

#### Belangrijke Methoden:

- **AddIdToLibrary(string targetId, GameObject targetGameObject):** Voegt een nieuw ID en GameObject toe aan de library. Als het ID al bestaat, wordt het niet toegevoegd.
- **RemoveIdFromLibrary(string targetId):** Verwijdert een ID uit de library.
- **CompareId(string targetId):** Controleert of een bepaald ID al in de library bestaat.
- **GetGameObject(GameObject parentGameObject, string targetId):** Vindt een GameObject met het opgegeven ID onder de kinderen van een opgegeven parent GameObject.
- **GetGameObjectById(string targetId):** Geeft het GameObject terug dat overeenkomt met het opgegeven ID.
- **GetIDByGameObject(GameObject gameObject):** Geeft het ID terug dat overeenkomt met het opgegeven GameObject.

### UniqueID Klasse

De `UniqueID` component wordt toegevoegd aan GameObjects die een uniek ID moeten hebben. Het bevat een `uniqueId` string die het unieke ID van het GameObject opslaat.

#### Belangrijke Eigenschappen en Methoden:

- **UniqueId:** Een eigenschap die het unieke ID van het GameObject teruggeeft.
- **GenerateId():** Genereert een nieuw uniek ID met behulp van `System.Guid.NewGuid().ToString()` en slaat dit op in `uniqueId`.
- **OnEnable(), OnDestroy(), OnValidate(), Start():** Lifecycle-methoden die zorgen voor het correct registreren en deregistreren van het GameObject's ID in de `UniqueIdLibrary`.

## Gebruik

Wanneer een GameObject met de `UniqueID` component wordt geïnitialiseerd, genereert het automatisch een uniek ID dat niet verandert. Dit ID wordt geregistreerd in de `UniqueIdLibrary` wanneer de game start, waardoor het mogelijk wordt om instellingen of andere data te koppelen aan specifieke prefabs, zelfs tussen sessies.

## Conclusie

Dit systeem voor unieke ID's biedt een robuuste oplossing voor het identificeren en beheren van prefabs binnen OperationStarfall. Het maakt geavanceerde functionaliteiten mogelijk, zoals het opslaan en ophalen van prefab-specifieke instellingen uit een database, wat essentieel is voor het creëren van een dynamische en aanpasbare game-ervaring.
