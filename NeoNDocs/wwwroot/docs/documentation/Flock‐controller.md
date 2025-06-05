De Flock-controller is een systeem om individuele drones als groep extern aan te kunnen sturen.

# Inhoud
 - [hierarchy](#Hierarchy)
 - [soorten](#Soorten)
 - [benodigdheden](#Benodigdheden)

# Hierarchy
De extra classes die deze aanpassing met zich meebrengt zijn als volgt:
 - `FlockController`
 - `DynamicFlockController`
 - `StaticFlockController`
 - `FlockControllerState`
 - `GroupIdleState`
 - `GroupSwarmState`
 - `EnterSwarmState`
 - `InFlockState`
 - `FlockCaller`
 - `EnterCallingState`
 - `CallerState`
 - `ICaller`

`FlockController` en `FlockControllerState` zijn abstracte base-classes.
De `FlockControllerState` is een base-class welke wordt gebruikt om states aan te geven in de state-machine van de `DynamicFlockController`, `StaticFlockController` en mogelijke toekomstige Classes die overerven van `FlockController`.
Neem als voorbeeld: `GroupIdleState` en `GroupSwarmState`.  
De `FlockCaller` is een implementatie van de `ICaller` interface en is een nodig voor een drone om tot een flock te
kunnen behoren.

# Soorten
Er zijn op dit moment twee soorten van flock-controllers: `StaticFlockController` en `DynamicFlockController`. Dit zijn
implementaties van de base-class `FlockController`. Het verschill zit hem al in de namen: `StaticFlockController` kan niet groeien of krimpen in grootte en de `DynamicFlockController` is dynamisch in grootte.

# Benodigdheden
Er zijn ook aanpassingen op de state-machine geweest op Bobert om dit werkend te krijgen. Zo heeft hij nu de extra components nodig: `FlockCaller`, `EnterCallingState`, `InFlockState` en `CallerState`. In het geval je wilt dat een bobert niet tot een flock kan behoren, dan verwijder je zijn `FlockCaller` component en kan hij niet meer worden gezien door andere boberts.