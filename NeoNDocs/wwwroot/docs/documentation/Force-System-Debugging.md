# Description
In dit project hebben we in de `Systems` prefab een aantal benodigdheden om een scene te laten werken.
Deze prefab bestaat uit een aantal objecten als bijvoorbeeld de [Force System](https://github.com/BAStudio/OperationStarfall/wiki/Force-System).
En dus ook de `ForceSystemDebugger`.

# Tools
Deze pagina beschrijft de tools die horen bij het debuggen van het `Force System`.
## Setting classes
 - [DebuggerSettings](#DebuggerSettings)
 - [ForceBodyServiceSettings](#ForceBodyServiceSettings)

## Managed classes  
Managed classes zijn classes die overerven van de [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-7.0) interface.
 - [ForceBodyDebugInfo](#ForceBodyDebugInfo)
 - [ForceDebugInfo](#ForceDebugInfo)
 - [ForceBodyPredictionService](#ForceBodyPredictionService)

## Injectables
De Injectables zijn abstracte classes die worden geïnject door de `ForceSystemDebugger` op ForceBodies en op Forces zelf.
Deze zijn bedoeld om van over te erven om de doorgegeven informatie van een ForceBody of een Force te kunnen benutten.
 - [ForceDebugItem](#ForceDebugItem)
 - [ForceBodyDebugItem](#ForceBodyDebugItem)

## Services
Services zijn geschreven classes met het doel logica netjes gescheiden te houden zodat deze modulair gebruikt kan worden zonder dat het wiel opnieuw uitgevonden hoeft te worden.
 - [ForceBodyPredictionService](#ForceBodyPredictionService)

## Overkoepelende classes
De overkoepelende classes zijn de classes die van de hierboven genoemde classes gebruik maken
 - [ForceSystemDebugger](#ForceSystemDebugger)

## Editor windows
 - [ForceBody Editor](#ForceBody-Editor)

# DebuggerSettings
`./Assets/Scripts/Framework/Forces/Debugging/DebuggerSetting.cs`  
Deze class bezit de gegevens die de `ForceSystemDebugger` doorpaast `ForceBodyDebugInfo` en `ForceDebugInfo`.
## Properties
 - _`forceDebugItemPrefabs`_: is een array met prefabs die door `ForceDebugInfo` op runtime wordt geïnject op de verschillende forces.
 - _`forceBodyDebugItemPrefabs`_: is een array met prefabs die door `ForceBodyDebugInfo` op runtime wordt geïnject op de verschillende ForceBodies.
 - _`prefabParent`_: is de container-transform waar de geïnjecteerde objecten leven.
 - _`disposeTimeout`_: de timeout voordat een managed class zijn unmanaged resources opruimt nadat `.Dispose()` aangeroepen is.
 - _`globalScaleModifier`_: de gewenste scale-modifier die wordt gebruikt voor het weergeven van een force.
 - _`forceIdMap`_: een display-settings lookup-table.
 - _`arrowOffset`_: een property specifiek voor de arrow-display van een force.

# ForceBodyServiceSettings
`./Assets/Scripts/Framework/Utils/ForceBodyServiceSettings.cs`  
Deze class bezit de instellingen voor de `ForcebodyPredictionService`
## Static properties
 - `Default`: de standaard instellingen voor deze class
## Properties
 - `remembersMovement`: een boolean die aangeeft of een force met het id van `Movement` opnieuw moet worden toegevoegd mee in de berekingen voor het voorspellen.

# ForceBodyDebugInfo
`./Assets/Scripts/Framework/Forces/Debugging/ForceBodyDebugInfo.cs`  
Dit is een class die het IDisposable pattern volgt. Ik heb deze designreden genomen wegens het feit dat deze een unmanaged objects managed: de debugItems; wat de geïnjecteerde objecten zijn.

## Constructors
### _ForceBodyDebugInfo_(`ForceBody`, `DebuggerSettings`)

## Public Methods
### void _Dispose_()  
Deze method hoort bij het IDisposable pattern en ruimt de unmanaged objects op.  
  
### `ForceDebugInfo` _GetForceInfo_(`IForceable`)  
Kan `null` returnen! Dit gebeurt wanneer er een `IForceable` wordt meegegeven dat niet bij deze ForceBody hoort.  
Dit is een getter method om debug-info op te halen van een force die bij de corresponderen ForceBody hoort.

## Public Properties
### `ForceBody` _ForceBody_
Een getter voor de reference voor het weten van de toepasselijke `ForceBody`.

# ForceDebugInfo
`./Assets/Scripts/Framework/Forces/Debugging/ForceDebugInfo.cs`  
Dit is een class die het IDisposable pattern volgt. Deze class is verantwoordelijk voor het managen van unmanaged objects welke in dit geval een array aan GameObjects is.

## Constructors
### _ForceDebugInfo_(`ForcBodyDebugInfo`, `IForceable`, `DebuggerSettings`)

## Public Methods
Deze class heeft geen public methods.

## Public Properties
### `IForceable` _AssociatedForce_
Een reference naar de toepasselijke force.

### `ForceBodyDebugInfo` _ParentDebugInfo_
De debug gegevens van de ForceBody waartoe deze debug-info behoort.  

# ForceDebugItem
`./Assets/Scripts/Framework/Forces/Debugging/ForceDebugItem.cs`  
Dit is een abstracte basis-class die wordt geïnjecteerd door de `ForceDebugInfo`. Door over te erven van deze class, kan je gebruik maken van de doorgegeven gegevens vanuit de `ForceDebugInfo`.  
Voorbeelden waar deze class wordt geïmplementeerd zijn de `MeshedForceDebugArrow` en de `GizmoForceDebugArrow`
## Properties
 - _`Color`_: De gegeven kleur van de force, dit geeft de mogelijkheid om bij het weergeven van de force kleurencodes te gebruiken.
 - _`Direction`_: Is bedoeld om de direction van de toepasselijke force op te halen.
 - _`DebugInfo`_: De bijbehorende debug-info van de force.
 - _`BodyDebugInfo`_: De debug-info van de bijbehorende force-body van de force.
 - _`Force`_: De bijbehorende force.
 - _`ScaleModifier`_: De gegeven scale-modifier van deze force, dit kan gebruikt worden wanneer je info wilt weergeven in bijvoorbeeld de editor.
 - _`Offset`_: De positional-offset welke gebruikt kan worden wanneer je info wilt weergeven in bijvoorbeeld de editor.

# ForceBodyDebugItem
`./Assets/Scripts/Framework/Forces/Debugging/ForceBodyDebugItem.cs`  
Dit is een abstracte basis-class die wordt geïnjecteerd door de `ForceBodyDebugInfo`. Door over te erven van deze class, kan je gebruik maken van de doorgegeven gegevens vanuit de `ForceBodyDebugInfo`.  
Een voorbeeld waar deze class wordt geïmplementeerd is de `ParabolaDrawer`.
## Properties
 - _`DebugInfo`_: De debug-gegevens van de force-body.
 - _`ForceBody`_: Een reference naar de bijbehorende force-body.

# ForceBodyPredictionService
`./Assets/Scripts/Framework/Utils/ForcebodyPredictionService.cs`  
Deze class dient als enige functie het voorspellen waar we verwachten dat een force-body heen gaat.

## Constructors
### _ForceBodyPredictionService_(`ForceBody`, `ForceBodyServiceSettings`)
### _ForceBodyPredictionService_(`ForceBody`)

## Public Methods
### `Vector3[]` _PredictPath_(`int` stepCount, `bool` resetAfter = false)
Voorspeld het pad wat de force-body is verwacht af te gaan leggen.  
Parameters:  
 - _`stepCount`_: De hoeveelheid stappen in de toekomst die we willen voorspellen.
 - _`resetAfter`_: boolean die aangeeft of de clone van de force-body na het berekenen direct gereset wordt.
  
Returns:  
Een vector3-array met een lengte gelijk aan `stepCount` welke de coördinaten bezit waar de force-body is verwacht langs te gaan.

### void _ResetClone_()
Stelt de clone van de force-body weer gelijk aan de force-body.

### void _Dispose_()
Deze method hoort bij het IDisposable pattern en ruimt de unmanaged objects op.  

## Public Properties
### `bool` IsDisposed
Geeft aan of dit object al gedisposed is.

### `ForceBody` ReferenceBody
De Forcebody wiens verloop wordt voorspeld door de service.

### `ForceBody` Clone
De clone waarmee het verloop wordt voorspeld.

# ForceSystemDebugger
`Assets/Scripts/Framework/Forces/Debugging/ForceSystemDebugger.cs`  
De ForceSystemDebugger is een Singleton class die luistert naar het force-system om te weten welke force-bodies aanwezig zijn.
Op deze force-bodies inject hij debug-info welke bijhouden welke forces worden toegevoegd per functie. Het overkoepelt `ForceBodyDebugInfo` en `ForceDebugInfo` en handled de upper-level injection + instellingen van deze classes.

# ForceBody Editor
`NeoN > ForceBody Editor`  
Dit is een editor-window om te zien welke forces allemaal effect hebben op de geselecteerde force-body,
het toevoegen van forces en het bewerken van al effect hebbende forces.
Om een Force te bewerken, druk je op de "Edit" knop bij de force.
Als je een force wilt toevoegen, open je de "Add-Force" accordion, wanneer je dan op de "Add" knop drukt, opent deze gelijk de "Edit-Force" tab met deze net toegevoegde force geselecteerd.