# Priority Factors
The automatic targeting system prioritizes different entities based on priority factors and their weights. Each priority factor is individually calculated for an entity. The total weight of that entity is all the activated factors combined.

There are currently 3 priority factors:
* Visibility, the direction the player is looking.
* Distance, the proximity of detected entities.
* Health, the health the entity has left.

You can add more factors by creating a factor calculator script that inherits the PriorityFactorCalculator. You then add an override for `CalculateWeight()` and return a calculated value multiplied by a factor weight variable.

Here is a template:
```
public class [PRIORITY NAME]FactorCalculator : PriorityFactorCalculator
{
    [SerializeField] private AutomaticTargetingSystem automaticTargetingSystem; // Link the automatic targeting system
    
    public override float CalculateWeight(Selectable selectable, float factorWeight)
    {
        var weight = /* Calculate a value to use as weight */;
        
        return weight * factorWeight;
    }
}
```

# Factor Calculators
### Visibility
The visibility weight is calculated by getting the normalized dot product, with the lhs being the direction of the entity and the rhs being the look direction of the player.

### Distance
The distance weight is the normalized distance of all detected entities. It uses the `OrderBy()` function to get the largest distance of all detected entities, which is needed to normalize everything. Then `InverseLerp()` is used to get the normalized distance of the currently calculated entity.

### Health
The health weight is the normalized difference of the player health and entity health. If the entity has more health than the player, it will give a negative weight. This is to prioritize entities that are easier to beat.

# Priority Settings
In the automatic targeting system there is a section for adding different priority factors. The factors are grouped so you can use different groups in some areas (read [Modifier Areas](#modifier-areas)). `Default Group` is the default group that it starts with, but you can change the name to anything.

In a group you can add priority factors by dragging in factor calculators and setting a weight for that factor. Note that the factor calculators have to be added to the GameObject that you are working on. So you drag them from the GameObject to the automatic targeting system which is also on the GameObject.

The factor weights are the multipliers for that factor. A weight of zero means that the factor won't be used. Negative values invert the properties of the factor.

You can also add a name to make it easier to see what factors are used.

![Priority Settings](https://github.com/BAStudio/OperationStarfall/assets/90683368/98fcd90c-8862-48eb-bbbc-d862dd732971)

# Modifier Areas
The Modifier Area prefab can be used to trigger specific areas where the priority settings have to change. You can drag the prefab into the scene and cover an entire area with it where you want the priority settings to be different from the default priority group.

![Modifier Area Prefab](https://github.com/BAStudio/OperationStarfall/assets/90683368/a38cfdbd-7c7f-4d09-b920-52c5e86b3437)

In the Modifier Area are different events that can trigger the new priority settings. You can drag the Modifier Area script in an event and call `SetPriorityGroup()` with the index of the priority group you want to change to. These groups are defined in the automatic targeting system.

In this example we change to the second group (index 1) when we enter the area, and we switch back to the default one when we exit the area.

![Modifier Area](https://github.com/BAStudio/OperationStarfall/assets/90683368/3afe6bed-ec5a-46c6-ae79-4ef8aa28089c)