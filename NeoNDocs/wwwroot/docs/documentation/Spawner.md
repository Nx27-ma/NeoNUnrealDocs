
***
# Enemy Spawner

***
# How to setup

1.  Place the prefab in the scene or place the EnemySpawner script on a gameObject in the scene.
2.  config the settings to your liking(Don't forget to put the waypoints inside of the list).
***
# Spawn Configuration:
 
## Modes
![Screenshot 2023-09-19 112231](https://github.com/BAStudio/OperationStarfall/assets/90614327/0beffebd-7300-4650-a7e1-031d65217dfc)

Position Mode:
* Fixed Position: Spawns enemies at a specific location.
* Random Position within Radius: Spawns enemies randomly within a specified radius (SpawnRadius).

Pause Mode:
* Instent: Spawns them instantly without waiting for timer.
* Timer: Pauses for a set amount of time before respawning.
* Wait for Enemy Death: Pauses until a previously spawned enemy (drone) is defeated.

Activation Mode:
* Trigger: Requires the player to walk over a trigger to activate spawns.
* Always On: Spawns are always active and do not require an external trigger.

Range Mode:
* Cube: Radius to spawn enemies in is a cubes.
* Circle: Radius to spawn enemies in is a Circle.

## Spawner Settings Config

![Screenshot 2023-09-19 113054](https://github.com/BAStudio/OperationStarfall/assets/90614327/b05c2a07-53e0-4ecf-b41d-a39cca83d5f0)

Timer:
* This variable keeps track of the time remaining until a new enemy can spawn.

Reset Timer:
* When the Spawn Timer reaches 0 seconds or goes below it, the Reset Timer updates the Spawn Timer with a new time interval for the next enemy spawn.

WayPoints:
* WayPoints are the waypoints the enemy are to walk/follow.

## Random Spawner Settings

![Screenshot 2023-09-19 113519](https://github.com/BAStudio/OperationStarfall/assets/90614327/5966cda2-db5a-4d73-a5b1-7aaebe941312)

Enemies List (Random):
* This variable, enemiesListRandom, keeps track of the number of enemies that have been spawned and are still alive.

Enemy for Random Spawn:
* enemyForRandomSpawn represents the type or object that needs to be spawned as an enemy.

Maximum Enemy Count:
* maxEnemies defines the maximum number of enemies that can be spawned.

Bounderies:
* spawnRadius specifies the radius around the main object within which enemies can randomly spawn.


## Single Spawner Settings
![Screenshot 2023-09-19 114127](https://github.com/BAStudio/OperationStarfall/assets/90614327/52548f2f-c73b-476b-8968-c1c3d599f538)

Spawn Point:
* setSpawnPoint represents the specific position where enemies will spawn.

Single Enemy Type:
* enemyForSingle specifies the type of enemy to be spawned.

Max Single Enemies:
* maxEnemiesSingles denotes the maximum number of single enemies that can be spawned.

## trigger

Create a TriggerBox: 
* First, create a TriggerBox in your scene. Ensure that the TriggerBox GameObject has the "Ignore Raycast" layer assigned to it. Make sure this TriggerBox is placed within the main scene, not a static scene.

Configure Spawners: 
* Attach Spawner GameObjects to the TriggerBox GameObject in the Inspector. This Spawner will be responsible for spawning objects when the TriggerBox events are triggered.

Set Trigger Events: 
* In the TriggerBox's Inspector, find the "OnBoxEnter" and "OnBoxExit" events. These events are used to trigger actions when an object enters or exits the TriggerBox.

Configure Trigger Actions: 
* In the TriggerBox's Inspector, configure the Trigger Configs for both "OnBoxEnter" and "OnBoxExit" events. Specify what should happen when an object enters or exits the TriggerBox, such as spawning enemies, triggering animations, or any other desired actions.

By following these steps, you can effectively set up triggers in your game. Make sure to test your triggers in the game environment to ensure they work as intended.

