# Combo System
## Combo Filtering

In the Combo System script, the `StartComboStep()` checks if there is currently an animation playing. It then filters the possible combos by input and player conditions (InAir, OnGround). The `FilterCombosByInput()` loops through a list of possible combos and compares the input types of the combo actions at the current step index. If there is no match, the combo is removed. The player conditions are also compared in `FilterCombosByConditions()`, because if you want a player to do a specific combo in the air only for example, that needs to be checked.

If there are no more possible combos or the last step of a combo is done, `ExitCombo()` will be called and it will reset everything after a cooldown. The cooldown is the exit time of a combo action.

You can drag all the combos that you want to be able to do into the Combos list. When you start playing, the Possible Combos list will give a live view of what combos are possible when you use any input. The Player Conditions list will give a view of the current conditions the player is in.

![Combo System](https://github.com/BAStudio/OperationStarfall/assets/90683368/27f329cd-7c9f-49c4-80f0-f607b78f18c7)

### Unity Events

In order to trigger the combo filtering, you need to use Unity events. In for example the `OnJump()` event, we first trigger `StartComboStep()` with the proper input name. After that we need to trigger `InitializeStep()`. The player conditions are also changed in this case, because we're moving the player into the air.

![On Jump](https://github.com/BAStudio/OperationStarfall/assets/90683368/818362d4-23d7-48d4-8feb-006e8facecea)

## Combo State Checker

Within the animator we have two notes for the attacks (`Combo1` and `Combo2`). On those notes there is a script called combo state checker. This script will set up a couple settings when the attack animation starts playing, while playing and when the animation has finished. 

In the `OnStateUpdate()` the script will look if you are stil preforming a attack. In the case the animation is done it will call the `TriggerTransition()`. In this funtion it will let the combo system know that the attack is finished. 

| Funtions               | Description                                                                                        |
| ---------------------- | -------------------------------------------------------------------------------------------------- |
| OnStateEnter           | This function will be called when the state is activated in the animator                           |   
| OnStateUpdate          | This function will be called every frame the state is active in the animator                       | 
| OnStateExit            | This function will be called when you exit this state to go to another state in the animator       | 

## Combo, base combo action and combo attack action

You have three differend choose when you try to create a combo system scriptableobject. The combo, a base combo action and a combo attack action.

### Combo 

Within the combo you can select a set of combo action. The actions can be an attack action or a base action.     

![ComboScriptableObject](https://github.com/BAStudio/OperationStarfall/assets/90682539/1ea61674-e744-4190-85b6-08f287f037ce)

### Base combo action

The base combo action is the base class for every combo action. Inside the base action you can select what for combo input type this action has, what the exit time will be and if this action has any combo condition states.

![BaseComboAction](https://github.com/BAStudio/OperationStarfall/assets/90682539/82c3a949-75bb-4448-b7d2-41366692d614)

| Settings               | Description                                                                                        |
| ---------------------- | -------------------------------------------------------------------------------------------------- |
| Combo input type       | The input that you need to do for the combo action                                                 |
| Exit time              | This is the time you have to make a new combo action. When the time has past the combo will be reset|                                                    
| Combo condistion states| You can give certain condistion to a combo action. For example the air attacks have the condistion `InAir`, so you can now only use the air attack when you are in the air.|    
                                                                         
### Combo attack action

The attack action inherit the base combo action. So it has all the setting from above, but also adds some axtra settings to have more control over the attacks. For example you can selct which animation you want to have with this attack, or what the damage is for the attack.
 
![AirAttackScriptableObject](https://github.com/BAStudio/OperationStarfall/assets/90682539/cd8fc392-d4de-436c-a6af-222b48cef09f)

| Settings               | Description                                                                                        |
| ---------------------- | -------------------------------------------------------------------------------------------------- |
| Damage                 | The amount of damage that this attack does                                                         |
| Force Intensity        | The intensity multiplier of the attack force                                                       |
| Force Direction        | An optional and custom directionin which the target of the attack will recieve force               |
| Animation              | What animation will be used for the attack                                                         |
| Animation speed        | The speed of which the animation plays.                                                            |
| In Air                 | Signifies if the attack is being used in the air or not                                            |
| Gravity Scale          | The amount of gravity the attack has. Used for air attacks                                         |
| Current Hitbox Number  | This number signifies which hitbox is being enabled and registers attacks                          |
| Start Active Hitbox    | This signifies when the hitbox will become active during the animation. This is in normalized time |
| End Active Hitbox      | This signifies when the hitbox will deactivate during the animation. This is in normalized time    |
| Frame ID               | This specifies where the freeze frame happens                                                      |
| Particle ID            | This specifies which particle is played with the attack                                            |