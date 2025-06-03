![waypoint_system](https://github.com/BAStudio/OperationStarfall/assets/145978195/e5b93a90-3e15-4951-b378-445679bd9833)

De Waypoint System is een kleine bundel aan scripts die ervoor zorgen dat je gemakkelijk lijnen of punten kan maken en deze te gebruiken in andere scripts. Dit kan in de inspector en de gizmos gebruikt worden.


***


## Hoe kan ik een Waypoint maken?
Bij de menu items (links boven in de window), ga naar NeoN > Waypoint System en kies dan één van de twee opties, Line Waypoint, of Dots Waypoint. Er wordt dan automatisch een GameObject gemaakt in de huidige scene met het Waypoint script erop en de gewenste settings.

Of je kan op een GameObject een component toevoegen, deze heet 'Waypoint'

Als je een Waypoint hebt in de hierarchy, dan kan je de volgende properties aanpassen of gebruiken:

Property | Uitleg
:-----------|:------------
Waypoint Name | De naam van de Waypoint, deze is ook te zien in de gizmos
Visualisation Color | De kleur van de waypoint die wordt weergegeven in de gizmos
Should Draw Lines | Of er in de gizmos lijnen tussen de punten worden weergegeven
Should Move With Parent | Als deze of true staat, dan als de parent GameObject wordt verplaatst, gaan alle punten in de Waypoint mee, als een child object met zijn parent mee zou gaan
Points | Dit zijn alle punten in de Waypoint, deze kunnen ook in de gizmos aangepast worden

Na de properties zijn er nog 7 knoppen in de inspector:

Knop | Uitleg
:-----------|:------------
Add | Voegt één punt aan het einde van de Waypoint toe, zet edit mode automatisch aan
Edit | Toggled de edit mode, deze kan gebruikt worden in de gizmos om punten toe te voegen en te verplaatsen
Delete | Toggled de delete mode, deze kan gebruikt worden in de gizmos om punten te verwijderen
Insert | Toggled de insert mode, deze kan gebruikt worden om punten in te voegen, in de gizmos staan de knoppen waar tussen de lijn het punt wordt toegevoegd
Smooth | Gebruikt Catmull-Rom om de lijn te smoothen, hierdoor krijgt de lijn wel meer punten, dus niet te vaak gebruiken
Simplify | Gebruikt Ramer-Douglas-Peucker om de lijn simpeler te maken, hierdoor worden er punten verwijderd
Reset All Waypoints | Verwijderd alle punten in de lijn, alhoewel alle andere settings in de Waypoint wel blijven

Alle knoppen in de inspector / gizmos worden opgeslagen in de Undo History, dus als je perongeluk iets doet, kan je altijd op CTRL+Z drukken

## Gebruik in andere classes
Een Waypoint gebruiken in een andere class is heel makkelijk, maak een Waypoint variable aan, en vanaf daar kan je alle properties van de Waypoint gebruiken
```cs
public class OtherClass : MonoBehaviour
{
    [SerializeField] private Waypoint theCoolestWaypoint;

    public Vector3 GetPointOfIndex(int index)
    {
        if (theCoolestWaypoint.Points.Count - 1 < index)
        {
            return default;
        }

        return theCoolestWaypoint[index];
    }
}
```

## Extra
- Één GameObject kan meerdere Waypoints hebben
- Het eerste punt in de Waypoint is gelocked op de parent position
