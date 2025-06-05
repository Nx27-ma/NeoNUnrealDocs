# Speler Prefab Varianten in OperationStarfall

In OperationStarfall gebruiken we een flexibel systeem van prefab varianten om verschillende typen spelerspersonages te ondersteunen, zoals de Gunner, Warrior, en toekomstige typen zoals de Mystic. Dit systeem stelt ons in staat om een reeks unieke eigenschappen en vaardigheden toe te kennen aan elk spelertype, terwijl we de gemeenschappelijke functionaliteiten behouden die door alle spelers worden gedeeld. Dit document legt uit hoe onze prefab varianten werken en hoe je ze kunt aanpassen of uitbreiden.

## Basis van Prefab Varianten

Het hart van ons systeem is de `BasePlayer` prefab. Deze algemene prefab dient als de basis voor alle spelertypen, en omvat gedeelde componenten en functionaliteiten zoals bewegingscontroles, basale gezondheidssystemen, en gemeenschappelijke animaties. De `BasePlayer` prefab zorgt voor consistentie en maakt onze spelerspersonages meer DRY.

## Een Nieuw Spelertype Creëren

Om een nieuw spelertype te creëren, beginnen we met de `BasePlayer` prefab en maken vervolgens een variant ervan. Elke variant kan dan worden aangepast met extra componenten, scripts, en assets om de unieke aspecten van dat spelertype te definiëren. Bijvoorbeeld:

- **Gunner Variant:** Voegt een afstandswapensysteem toe, speciale animaties voor het schieten, en scripts voor munitiebeheer. Ook kan de gunner 'pushen'.
- **Warrior Variant:** Bevat componenten voor gevechten van dichtbij, unieke animaties voor aanvallen. Ook kan de warrior 'pullen'.

### Stappen om een Spelervariant te Creëren:

1. **Dupliceer de BasePlayer Prefab:** Begin met het dupliceren van de `BasePlayer` prefab in de Unity Editor.
2. **Voeg Unieke Componenten Toe:** Voeg eventuele componenten of scripts toe die specifiek zijn voor het nieuwe spelertype. Dit kan wapens, vaardigheden of aangepaste controllers omvatten.
3. **Pas Eigenschappen Aan:** Stel de eigenschappen en instellingen van de nieuwe componenten bij om te passen bij de rol en speelstijl van het spelertype.
4. **Wijs Assets Toe:** Koppel alle benodigde assets, zoals modellen, animaties of effecten, aan de variant prefab.

