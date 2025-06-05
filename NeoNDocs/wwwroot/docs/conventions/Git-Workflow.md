## Branches
### Branch Flow: Feature Branch Strategy
Binnen onze Game Studio hanteren wij een feature branch strategy voor ons versiebeheer. Dit houdt in dat we werken met de volgende branches:

* `master` branch
* `develop` branch
* `feature/` branches
* `hotfix/` branches

### Branches Aanmaken
Nieuwe branches worden **altijd** aangemaakt met develop als basis.

Branch namen worden volledig met kleine letters geschreven zonder spaties, gebruik dashes(-) tussen woorden. Begin branch namen altijd met de desbetreffende prefix, zoals beschreven hieronder.

Prefix Voorbeeld | Uitleg 
:-----------|:------------
master                  | Op de master branch staat de huidige release versie van de game.
develop                 | Hier zit altijd de laatste, gemergde versie van ons project in.
feature/branch-name     | Feature branches worden aangemaakt voor User Stories. De branch naam vertegenwoordigd wat de feature toevoegd. Voorbeeld: `feature/level-reloader`
hotfix/branch-name      | Hotfix branches zijn voor kleine aanpassingen, voornamelijk gebruikt voor het fixen van bugs. Levensduur van hotfix branches is minder dan één dag. Voorbeeld: `hotfix/grab-after-reload`

<br>

## Werken op een Branch

### Commits
Commits beschrijven kort wat je gedaan hebt, een goede werkwijze is om regelmatig commits te maken terwijl je werkt, dit houdt je werk up-to-date en dit helpt enorm met Version Control. Commits worden altijd in het **Engels** geschreven!

###### Tip: Als je niet weet wat je moet schrijven in je commit, hier is een goed format: [ACTIE], dan [LOCATIE], en als volgt [VERANDERING].

##### Voorbeeld Commit: `Increased player speed`

<br>

## Draft Pull Requests
Maak zo snel mogelijk een Draft Pull Request aan voor je branch, dit staat andere toe om de voortgang van je werk te volgen en eventueel na te kijken. 

<details>
  <summary>Draft Pull Requests geven duidelijk aan dat het werk op de branch nog niet af is.</summary>
  <img src="https://user-images.githubusercontent.com/71002222/203767217-55b02b68-9460-4a25-abc9-e71deb79cc73.png" alt="image" width="400"/>
</details>

<details>
  <summary>Wanneer je feature af is, kun je de pull request markeren als "ready for review".</summary>
  <img src="https://user-images.githubusercontent.com/71002222/203766685-16f1c9d7-61c4-44bb-bd94-98e99b86c7ed.png" alt="image" width="800"/>
</details>

### Labels & Assignees
Nadat je een (draft) pull request hebt aangemaakt kun je jezelf hieraan "assignen" waardoor overzichtelijk wordt dat jij bezig bent met de desbetreffende feature of hotfix die bij de pull request hoort.

Verder kun je zelf maar ook andere labels toevoegen of wijzigen op pull requests. Dit maakt ook heel overzichtelijk welke pull requests bijvoorbeeld klaar zijn om reviewed te worden of welke nog aan gewerkt moet worden.

Labels en assignees toevoegen of wijzigen kan gedaan worden aan de rechterkant op de conversation pagina van een pull request.

<br>

<img src="https://user-images.githubusercontent.com/71002222/218338975-b50f38ea-396c-4c3b-8d04-a907073a2c4c.png" alt="image" width="300"/>

<br>

## Code Reviews
Iedereen in het team mag `comment` code reviews achterlaten, maar alleen Git Masters en de Technical Director mogen Pull Requests `goedkeuren` of `veranderingen aanvragen`.
* Features - Alleen de Technical Director mag hier de go voor de merge naar develop of bijbehorende epic branch toe geven.
* Hotfixes - Beide Git Masters en de Technical Director mogen hier een go geven voor een merge naar develop of de bijbehorende epic branch.

Nadat je je review opmerkingen klaar hebt staan, kun je je `comment` review zo afmaken zodat de pull request eigenaren dit te zien krijgen:

<br>

<img src="https://user-images.githubusercontent.com/71002222/218338644-e6e7ad81-5177-4608-ae1d-a0598d72ec68.png" alt="image" width="400"/>

### Reviews Aanvragen
Zodra jouw feature klaar is voor een code review kun je dat aangeven aan het team en de Technical Director. Daarnaast is het ook protocol om via Pull Requests een aanvraag te doen bij de Technical Director om de Pull Request na te kijken. Dit kun je doen via de Pull Request pagina aan de rechter kant, voorbeeld afbeelding hieroner:
![image](https://user-images.githubusercontent.com/71002222/203795396-ffe82330-3dd7-4696-83c1-152ff1efc19c.png)

### Feedback Verwerken
Nadat je de feedback op jouw Pull Request hebt verwerkt kun je weer opnieuw een code review aanvragen. Je zorgt er dan ook voor dat elke keer voordat je weer een code review aanvraagt jouw werk up-to-date is met develop en/of de bijbehorende Epic branch.


### Making of a prefab
als je een prefab maakt (die niet automatisch word geinstantiate) dan moet je die in de prefab short list zetten zo dat we hem makkelijker in een scene kunnnen zetten

<br>

## Merge Flow

### Merge Queue
Wanneer er meerdere Pull Requests open staan voor een merge naar develop, wordt er een **Merge Queue** opgesteld door de Git Masters, die stemmen met elkaar en de branch eigenaren af welke goedgekeurde Pull Requests als eerste worden gemerged.

### Pre-Merge Fase
Voordat je branch mag worden gemerged met develop en/of de bijbehorende epic branch, moet je branch eerst up-to-date worden gemaakt met beide develop en/of de epic branch.

### Merge Conflicts
In dit project hanteren wij twee soorten Merge Conflicts:
Type Conflict | Uitleg 
:-----------|:------------
Code Conflicts   | Conflicts in scripts. Kunnen handmatig worden opgelost aangezien de inhoud leesbaar is.
Asset Conflicts  | Conflicts in bestanden zoals prefabs. Omdat de inhoud van dit soort bestanden vrijwel onmogelijk is om handmatig goed te mergen, kiezen wij bij conflicts in dit soort bestanden **ALTIJD** voor de versie van develop. **Ongeacht van hoe klein de aanpassing op develop of hoe groot de aanpassing op je branch ook is**. Dit voorkomt dat er eventuele veranderingen gemaakt door een andere branch verloren gaan, wat er voor kan zorgen dat er onnodig dingen fout kunnen gaan op develop.

###### Tip: Git Masters kunnen assisteren met Code Conflicts en bij het detecteren van verloren veranderingen bij Asset Conflicts.

#### Herimplementatie & Testing
Nadat je de merge conflicts resolved hebt, ga je kijken wat er bij eventuele overrides van bijvoorbeeld Asset Conflicts verloren is gegaan van jouw feature, deze verloren veranderingen moeten handmatig worden hersteld door de branch eigenaren.

#### Merge naar develop
Wanneer alles rond is en de Pull Request klaar staat om te mergen, updaten de branch eigenaren eerst nog de main scene in het project met de veranderingen van hun werk waar nodig.

## Workflow Uitbreidingen
Hier worden een aantal uitbreidingen op de standaard Feature Branch Strategy workflow omschreven. Deze worden alleen gebruikt in uitzonderingen!

#### Naming Convention
* `epic/` branches

#### Branches Aanmaken
Als het een sub-branch is van een epic/ branch, dan moet het de desbetreffende epic/ branch gebruiken als basis.

Prefix Voorbeeld | Uitleg 
:-----------|:------------
epic/branch-name        | Op de epic branches staan de laatst gemergde features die onderdeel zijn van een Epic User Story. Deze wordt pas naar develop toe gemerged wanneer de Epic helemaal af is. Voorbeeld: `epic/spaceship`

Features die je maakt voor een Epic hanteren gewoon de feature naming convention met als uitzondering dat je ook de epic naam erin verwerkt.

Voorbeeld:
Je werkt aan de feature 'spaceship waypoints laten volgen' voor de epic 'spaceship'. Dan wordt de branch naam:
`feature/spaceship-waypoints-follower`

## Code Reviews
* Epics - Alleen de Technical Director mag hier de go voor de merge naar develop toe geven.

#### Epic Updates
Aan het eind van elke sprint, is het de taak van de Git Masters om alle Epic Branches die nog open staan te updaten met de nieuwste versie van develop.

The End.