# Component Stack Feature in Onze Game

De Component Stack is een krachtige functionaliteit binnen onze game-engine die het mogelijk maakt om op een flexibele manier verschillende componenten te beheren en toe te voegen aan objecten in de game. Deze feature maakt gebruik van een generieke klasse met een lijst, waardoor het mogelijk is om elk type data toe te voegen.

## Hoe werkt het?

1. **Generieke Klasse**: De Component Stack is geïmplementeerd als een generieke klasse, wat betekent dat het kan werken met verschillende datatypes. Het bevat een lijst waarin deze datatypes kunnen worden opgeslagen.

2. **Toevoegen van Componenten**: In ons geval gebruiken we de Component Stack bij de Spawner om verschillende spawnvoorwaarden gemakkelijk toe te voegen. We definiëren klassen die deze verschillende voorwaarden vertegenwoordigen, zoals tijdgebaseerde spawns, afstandsgebaseerde spawns, of spawns die afhankelijk zijn van spelersstatussen.

3. **Gebruik in Unity Inspector**: Dankzij de integratie met de Unity Inspector kunnen deze specifieke spawnvoorwaarden eenvoudig worden toegevoegd aan de Component Stack van de Spawner. Dit gebeurt door simpelweg op het plusje te klikken naast de lijst in de Inspector en de gewenste voorwaarde te selecteren uit de beschikbare opties.

![Component Stack in Unity Inspector](https://github.com/BAStudio/OperationStarfall/assets/26221135/96bfbae6-1cd3-4c43-9c28-e3da8474aa87)

## Toepassing bij de Spawner

De Spawner is een essentieel onderdeel van onze game, verantwoordelijk voor het genereren van objecten in de spelwereld. Door gebruik te maken van de Component Stack kan de Spawner flexibel worden geconfigureerd om verschillende spawnvoorwaarden te ondersteunen. Dit stelt ons in staat om complexe en diverse spawnmechanismen te implementeren zonder dat we telkens nieuwe code hoeven te schrijven.

## Voordelen

- **Flexibiliteit**: De Component Stack biedt een hoge mate van flexibiliteit doordat het verschillende soorten spawnvoorwaarden kan beheren.
- **Herbruikbaarheid**: Doordat het werkt met generieke klassen en overerving, kunnen spawnvoorwaarden gemakkelijk worden hergebruikt en uitgebreid voor verschillende spelsituaties.
- **Eenvoudig in gebruik**: De integratie met de Unity Inspector maakt het toevoegen en beheren van spawnvoorwaarden intuïtief en gemakkelijk voor ontwikkelaars.

Met de Component Stack-feature kunnen we op een efficiënte en flexibele manier complexe spawnmechanismen toevoegen aan onze game, waardoor we de diversiteit en uitdaging van de gameplay kunnen vergroten en snel kunnen itereren op nieuwe ideeën en concepten.
