# This page is a work in progress
***
## Guide to adding a new MovementAction
- Go to `MovementActionIDs.cs` and add your name
- Your class must inherit from `MovementAction`
- If you need it, get a reference to the ** with `GetComponent<MovementActionHandler>();`
- Add `public override bool Execute(object parameter = null)`, with `if (!base.Execute()) return false;` as the first line
- Override the bool `IsReadyToExecute` for your execute condition[s]
***
## Description:

#### ...of BasePlayer prefab:
It has `MovementActionHandler`, `MovementActionMove`, and `MovementActionJump`. The last two inherit from `MovementAction`.  
These components have events and variables that can be configured in the inspector - `MovementActionJump` has the `OnJumpStart` and `OnGroundLand` events for example.
  
#### ...of MovementActionHandler:
This class is the container for all `MovementAction` components on this GameObject.  
It contains the fields `forceBody`, `IsGrounded`, `animationManager`, `MovementSettings`, `CurrentMoveState`.  
It has a dictionary `AvailableActions` of all available actions which you can use to access and execute them.

#### ...of MovementAction:
This is the base class for all MovementActions.  
The `ActionID` can be used as identification, `IsReadyToExecute` to check if it would immediately fail, `WasRecentlyExecuted()` can be checked for cooldown purposes, `PersistExecute()` to continue attempting to execute every frame for a certain amount of time.

#### ...of MovementActionMove
The only unique public function is `FlipPlayer()`, this lets you set the players facing direction to left or right  
Settings in the inspector are:  
- The Events `onTurnLeftGrounded`, `onTurnRightGrounded`, `onGroundWalk`, `onStopMoving`
- `movementForce`
- `settings` (`MovementSetting` list)
- `moveInputDeadZone`

#### ...of MovementActionJump
Setting `CanJump` adjusts `_canJumpInAir`  
Settings in the inspector:
- jumpForce