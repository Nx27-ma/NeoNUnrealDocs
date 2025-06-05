# Wat is de Smart Camera

De Smart Camera is een geavanceerd camerasysteem dat nauwkeurig de positie en zoom van de camera berekent. Het systeem bestaat uit verschillende onderdelen:

## Onderdelen van de Smart Camera:
- **Smart Camera:** De kerncomponent van het systeem.
- **Smart Camera Target Collection:** Deze module houdt een verzameling bij van alle objecten die binnen het camerabeeld moeten vallen. Het berekent vervolgens een gemiddelde positie op het scherm voor deze objecten.
- **Smart Camera Data Setter:** Hier worden verschillende vooraf ingestelde cameragegevens opgeslagen als presets. Via dit script kunnen we eenvoudig nieuwe presets instellen door simpelweg een string op te geven, zoals 'multiplayer' of 'singleplayer'.

## Smart Camera Data

De Smart Camera biedt diverse instellingen waarmee je de camera kunt aanpassen voor elk denkbaar scenario. Hiermee kun je verschillende cameragedragingen creëren voor uiteenlopende situaties.

Bovendien is hier een overzicht van enkele instellingen die we kunnen aanpassen:

![image](https://github.com/BAStudio/OperationStarfall/assets/26221135/612bc6ec-7af9-4340-9735-1cc3df0a349c)

Deze instellingen bieden een uitgebreide mogelijkheid om het cameragedrag aan te passen en zorgen voor een optimale ervaring in elke situatie.

De Smart Camera heeft een nieuwe functionaliteit gekregen. Het `Ortho To Perspective` script is verplaatst van de Smart Camera naar de daadwerkelijke camera. Hierdoor wordt de functionaliteit nauwkeuriger en efficiënter toegepast.

Daarnaast is er nu een `Camera Manager` geïntroduceerd. Deze manager beheert de Smart Camera en houdt een actieve camera bij waarop bepaalde gebeurtenissen kunnen worden getriggerd, zoals panning of camerawisseling. Wanneer er wordt gewisseld, pan de camera met een instelbare curve naar de nieuwe camera.

Een `camera trigger` werkt samen met de `EventCollision Dispatcher`. De camera-trigger vertelt de cameramanager dat hij iets moet doen met de actieve camera.
