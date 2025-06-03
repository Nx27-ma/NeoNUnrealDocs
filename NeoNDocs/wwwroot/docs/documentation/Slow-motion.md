## How to set up a slow motion trigger
* Go to the systems prefab and then to the slowmotion manager.
* Under Slow Motion Settings, add a new slowmotion setting. Here you can adjust the settings of your new slow motion.
  * Name: keep it simple and descriptive.
  * Slow motion speed: This is how fast the game will play. 0.5 means the game will play at half speed. 2 means the game will play at double speed. Extreme low or high values will break the game.
  * Duration: the duration is how long the full slow motion stays active (This does not include the enter and exit transition duration).
  * Enter transition duration: This is how long it will take to sooth the game into slow motion.
  * Exit transition duration: This is how long it will take to soothe the game out of slow motion.

![slowmotionSettings](https://github.com/BAStudio/OperationStarfall/assets/90691070/7d3cff99-5e7d-4bed-ab16-a92d68b5396b)
* On the object you want to trigger slow motion, give it the SlowMotionMediator script.
* Then drag the SlowMotionMediator from the object to a Unity Event on the same object. The slow motion will activate whenever the Unity Event gets triggerd.
* Then select SlowMotionMediator -> ActivateSlowMotion.
* Then set the name of your slow motion setting as the argument.

![SlowMotionActivate](https://github.com/BAStudio/OperationStarfall/assets/90691070/6d2f1aec-a101-4237-8360-0ace5357fe7c)

