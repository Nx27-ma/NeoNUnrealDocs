## DOTS - Data-Oriented Technology Stack 

### Key components:
* Entity Component System (ECS)
* Burst Compiler
* C# Job System

### Introduction
#### Het gebruik van DOTS heeft erg veel voordelen. Enkele voorbeelden zijn:

* Performance: de Unity DOTS-tools (Data-Oriented Technology Stack), waaronder de Burst-compiler, het Job-systeem en het Entity Component-systeem, streven naar betere prestaties door middel van onder andere parallelle verwerking en multithreading.

* Scalability: het Job-systeem maakt een efficiënte verdeling van de verschillende taken over alle CPU cores, waardoor de game makkelijker kan schalen naar meer complexe systems, maar ook voor low-end platforms (Nintendo Switch)

* Memory management: het Entity Component System biedt meer controle over hoeveel geheugen je gebruikt. Door het gebruik van structs en entities, bouw je erg geheugen-vriendelijke systemen.

### Getting started:
### Voordat je bezig gaat zijn met DOTS moet je een paar zaken van te voren geregeld hebben.
* Een goed begrip hebben van onze custom [force system](https://github.com/BAStudio/OperationStarfall/wiki/Force-System)
* Zorg dat je Unity versie 2020.3.40f1 hebt ([download](https://unity.com/releases/editor/archive))
* Installeer de package Hybrid Renderer. Unity -> Window -> Package Manager -> Add package from GIT URL -> `com.unity.rendering.hybrid` Check of je de volgende packages hebt (enable preview packages):
    * Burst 1.6.6 
    * Collections 1.4.0 
    * Entities 0.51.1-preview.21 
    * Mathematics 1.2.6
    * Hybrid Renderer 0.50.0-preview.44 

### Brief introduction ([link](https://miro.com/app/board/uXjVP6TXLvw=/?share_link_id=140284327291))
![CodeDiagram](https://user-images.githubusercontent.com/70685433/215453654-975ac1f1-ab4c-49dd-a9c6-8d5d57d5b5ee.PNG)<br><br>
Het einddoel van het integreren van DOTS, is dat de oude functies / methods van de forcebodies nog steeds gebruikt kunnen worden zoals hieronder. Terwijl eigenlijk het nieuwe Force Systeem achter de schermen gebruikt wordt.
```c#
ForceBody.Add(new Force());
```

De ForceBody helper class heeft een belangrijke rol hierin. Deze class is een static helper class die ervoor zorgt dat de oude functies van de ForceBody de juiste informatie doorgeven aan het nieuwe Force System.

Taken die nog over zijn:
* Astar werkt nog met de oude colliders
* De oude colliders zouden moeten worden verwijderd tijdens het converten naar entity
* OnDestroy bug fixen in LinkEntity
* Als het bijbehorende game object gedestroyed wordt moet ook de entity worden gedestroyed
* Alle forcebodies en alles waarmee gecollide kan worden moet geconvert worden naar een entity en een linkentity script hebben
* De nieuwe DOTS Raycasts, Spherecasts, etc. Moet de collider niet raken als de cast binnen in de collider start
* De DOTSPhysics class moet worden uitgebreid met andere oude Physics functies
* Overal in de codebase waar Physics.Raycast, etc wordt gebruikt moet de DOTSPhysics class gaan gebruiken
* Het oude ForceSystem script verwijderen
* Functies onderin het ForceBody script moeten nog DOTS compatible gemaakt worden

[![DOTS VIDEO](https://user-images.githubusercontent.com/70685433/218335885-caa37e5c-d3ca-4ba6-bccc-eff29f200afc.PNG)](https://www.youtube.com/watch?v=MTMidHRzL_A)

Bronnen: 
* [Unity ECS introductie + sample project](https://www.kodeco.com/7630142-entity-component-system-for-unity-getting-started)
* [Officiële Unity DOTS learning samples](https://github.com/Unity-Technologies/EntityComponentSystemSamples)
* [Dynamic Buffers](https://docs.unity3d.com/Packages/com.unity.entities@0.3/api/Unity.Entities.DynamicBuffer-1.html)
* [SystemBase](https://docs.unity3d.com/Packages/com.unity.entities@1.0/manual/systems-systembase.html)
* [IComponentData](https://docs.unity3d.com/Packages/com.unity.entities@0.1/api/Unity.Entities.IComponentData.html)
* [Turbo Makes Games (erg goede tutorials)](https://www.youtube.com/watch?v=PMjnxcX5uqk&list=PLgYNYeZLALscDwwujFSjgXJmdZb_wwYpJ)
* [Code Monkey (erg goede tutorials)](https://www.youtube.com/watch?v=Z9-WkwdDoNY&list=PLzDRvYVwl53s40yP5RQXitbT--IRcHqba)

