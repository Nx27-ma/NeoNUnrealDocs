# Decoration Generator

De Decoration Generator zorgt er voor dat de platformen automatisch decoratie krijgen door op een knop te drukken in de inspector. 

### Benodigheden: 

#### Objects:
- Platform 
- Empty Child Object

#### Scripts:
- Decoration Generator 
- Decoration Library

### How to use:

***
#### Decoration Generator

De Decoration Generator sammen met de Decoration Library zorgt ervoor dat er decoratie ingespawn kan worden.

In de Generator staan de algemene instellingen voor de decoratie voor het platform waar het script op staat.
Naast het aangeven van de de _decoration parent_ kan de generator direct gebruikt worden op iedere platform.

![Screenshot 2022-06-28 110654 (4)](https://user-images.githubusercontent.com/70955105/176140593-b46a9fd7-dc50-4cdc-b621-545929ed124b.png)


Variable | Uitleg
:-----------|:------------
![decorationGen (2)](https://user-images.githubusercontent.com/70955105/176132976-0f25b726-5434-4ae4-940f-ac4213fed944.png) | Het gameObject **binnen** het platform waar de decoraties onder geplaatst worden als children.
![decorationGen (3)](https://user-images.githubusercontent.com/70955105/176133422-bef4e863-c917-4389-be28-ae290a72faab.png) | Voor ieder segment waar een platform in opgedeeld word komt er tussen de min en max hoeveelheid decoraties.
![decorationGen (4)](https://user-images.githubusercontent.com/70955105/176133715-2225ce58-2191-4361-a20d-7e841b560ae4.png) | De segmenten van het platform worden opgedeeld aan de hand van de aangegeven hoeveelheid (lengte / spacing).
![decorationGen (5)](https://user-images.githubusercontent.com/70955105/176135360-aac61688-5b9f-4c8b-9cf4-53809a1968b9.png) | De fore- en background layers geven aan of de decoratie voor of achter de speler rendered.
![decorationGen (6)](https://user-images.githubusercontent.com/70955105/176136165-ef53064f-5c08-4000-9c47-8a84eae7e3f3.png) | de threshold geeft aan vanaf welke lokale y-pos de decoratie op de achtergrond rendered.
![decorationGen (7)](https://user-images.githubusercontent.com/70955105/176136525-a79812f3-8b2f-42e6-b6bb-d8bc3f7fdf10.png) | De Offset geeft de toegevoegde hoeveelheid aan op de lokale z-pos bij de aangegeven decoratie soort.
![decorationGen (8)](https://user-images.githubusercontent.com/70955105/176140950-afea126e-ff60-4d4a-bc8b-e09acdc7eba4.png) | De **reset** knop respawned alle decoratie op een platform. <br /> De **delete** knop verwijderd alle decoratie op een platform.


***
#### Decoration Library

Voor de Decoration Generator is de Decoration Library nodig (Deze staat onder de system prefab). Er mag maar **een** Library in de scene zitten. Als deze nog niet in de scene zit moet deze toegevoegd worden.

In de Decoration Library zit een lijst genaamd Database. Als die word uitgeklapt kan er een element worden toevoegen door op het plusje te klikken. Als er een element is toegevoegd, staan er twee variable Direction en Decoration Settings. Direction geeft aan welke kant van het platfrom de decoratie kan spawnen en de Decoration Settings is een lijst waar de de decoratie prefabs worden ingezet .

![2022-06-02 (2)](https://user-images.githubusercontent.com/70703952/171594707-cbe896d1-3420-4e41-8d92-fd79b9e1aa4f.png)

Als de Decoration Settings wordt opengeklapt dan kan daar binnen een element toegevoegd worden. Het toegevoegde element bevat de instelling van de individuelen decoraties.    
<br />
Variable | Uitleg
:-----------|:------------
![2022-06-02 (5)](https://user-images.githubusercontent.com/70703952/171596825-5349067c-7052-4777-b82f-1c55b8e9c7ac.png) | Hiermee kan wordt aangeven hoe groot de decoratie is. Elke size heeft een eigen offset en met de offset wordt aangeven of het op de voor- of achtergrond komt.
![2022-06-02 (6)](https://user-images.githubusercontent.com/70703952/171596935-2b48ce4a-201b-4018-912e-d2f2559eb3b5.png) | Hiermee word er aan geven hoe groot de decoratie kan worden. Als er bij de min en max iets anders in word gevoerd randomised er een getal tussen de twee aangegeven getallen. 
![2022-06-02 (7)](https://user-images.githubusercontent.com/70703952/171597140-968b7d63-96a8-4660-aca5-e68d8241884b.png) | Hiermee randomised het tussen x en y en voegt dat getal bij de rotatie van het object.
![2022-06-02 (8)](https://user-images.githubusercontent.com/70703952/171597168-72ba1762-b1a8-4c90-b853-0792750b2cda.png) | Hiermee randomised het tussen min en max en zet het de hoogte(Y positie) van de decoratie naar de uitkomst van de randomiser.
![2022-06-02 (9)](https://user-images.githubusercontent.com/70703952/171597407-71f69173-123b-4994-a155-aab0556691a4.png) | Hiermee worden de rotaties van de decoratie vergrendelen.
![2022-06-02 (10)](https://user-images.githubusercontent.com/70703952/171597182-99905ee5-28a9-4fae-8162-b41ae43f0dba.png)| Hiermee word aangegeven welke sprite gebruikt word voor de aangegeven settings. 






 



