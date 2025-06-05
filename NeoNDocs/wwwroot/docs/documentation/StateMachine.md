# **StateMachine**

**Hoe maak ik een nieuwe state machine**

Right click in de assets folder, in de context menu volg je de stappen:
create -\&gt; scriptableObjects -\&gt; StateMachine

Aan een van de objecten die de state moet bijhouden geef je de StateMachine script. Hier drag je dan de aangemaakte StateMachine scriptableObject in. 1 statemachine scriptable object kan op meerdere objecten gebruikt worden.

**StateMachine behaviour**
Als je een statemaakt moet deze extenden van de StateBehaviour class. Deze heeft een onEnter en onExit methode. En alle standaard monobehaviour methodes.

**Connections**
Een connectie bestaat uit meerdere transities, elke transitie heeft zijn eigen conditions.
in de inspector zijn alle conditions en transitions tezien.

**Conditions**

bestaande transitions

- int
- float
- bool
- trigger
- vector2
- vector3

Planned transitions

- blockage, deze blijft voor 1 frame op true, daarna gaat hij terug naar false. Werkt zoals een boolean.

**Nodes**

De linker kant van de node is de entree, hier zijn de connecties die naar deze state kunnen gaan. De rechterkant is de uitgang, alle connecties daar gaan uit de state naar nieuwe states.

**StateMachine methodes**

Net zoals de animator heb je methodes zoals setBool(key, value), dus voor alle soorten parameters heb je een aparte methodes om data te zetten.

**Most important classes**

StateMachineData, Deze class heeft alle data van de state machine, conditions, transitions, nodes, parameters.

StateMachine, Deze class regelt houdt de huidige state van een Object bij.

StateMachineController, deze class regelt de editor menu. En hier wordt de editor menu ook geopened
