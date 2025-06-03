# Wat is het idee?

Het idee is dat je in de level pickups hebt die een bepaalde "power level" hebben en dus dat je ze in een bepaalde orde moet oppakken, qua art moet het ook zo zijn dat de orbs die je nog niet kan oppakken die dan minder opacity hebben of beetje anders eruit zien om zo visually te laten zien welke pickup de player eerst moet oppakken 

# Structuur van systeem

je hebt 1 PickupSystem class die chains en losse pickups managed. chains zijn een collectie aan pickups en kunnen ordered of unordered zijn. als ze ordered zijn kun je de pickups aleen oppakken in de volgorde hoe je de pickups in de chain hebt gezet. bij bijna elke stuk van het systeem zijn er events die dingen in de scene kunnen triggeren: Waneer je een individuele pickup oppakt, waneer je een hele chain complete en waneer je alle pickups in de hele scene hebt opgepakt.

<div align="center">
<img src="https://user-images.githubusercontent.com/70896820/214047895-42cb4385-1bfa-4c6a-afa3-4a94703ade73.png">
</div>

# Alle scripts

## PickupSystem.cs

Hier zie een screenshot van hoe het in de inspector eruit ziet, zoals je ziet zijn er meerdere events waar je events erin kan zetten. de list: "All interactive Items" zijn ALLE pickups in de scene die hij kan vinden. de "Seperate Interactive Items" zijn alle losse pickups in de scene die GEEN chain hebben. de orbs die wel een chain hebben zijn dan ingesteld in een chain, zie het stukje hieronder.

<div align="center">
<img src="https://user-images.githubusercontent.com/70896820/214053862-b5eec015-3052-4345-a3d7-bbfb459aa3de.PNG" width="400px">
</div>

## PickupChain.cs

Hier zie je hoe een chain in de inspector eruit ziet, je kan selecteren of hij ordered of unordered is, en de lijst met pickups. en ook een event als de chain compleet is

<div align="center">
<img src="https://user-images.githubusercontent.com/70896820/214059496-ac356001-b5a9-496b-9f16-ef89c93715bf.png" width="400px">
</div>

## Pickup.cs

<p display="inline-block">
En dan hier een screenshot van de pickup zelf. Hij heeft een visual die dan uit gaat als je hem oppakt, je kan ook ervoor kiezen om hem te destroyen nadat je hem oppakt
</p>
<div align="center">
<img src="https://user-images.githubusercontent.com/70896820/214059968-cdf94164-95d3-4fa1-85e0-295a6c9e4fee.PNG" width="400px">
</div>



# UML diagram & uitleg code

![UML diagram](https://user-images.githubusercontent.com/70896820/214846998-2c6ec3a0-1681-4365-b540-d0839959269b.png)