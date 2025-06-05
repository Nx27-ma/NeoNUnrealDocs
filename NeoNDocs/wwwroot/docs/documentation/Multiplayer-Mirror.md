# Function
Mirror Networking makes it possible to play with friends online with the exact same things happening on both of your screens, because with Mirror Networking you can synchronize every little movement and interaction etc.

# Components/Attributes
These are components and attributes that you can use with Mirror Networking.

isLocalPlayer (bool)  
[Server] (attribute)  
[ServerCallback] (attribute)  
[Client] (attribute)  
[ClientCallback] (attribute)  
[Command] (attribute)  
[ClientRpc] (attribute)  
[TargetRpc] (attribute)  
[SyncVar] (variable)

### isLocalPlayer
This returns true if this object is the one that represents the player on the local machine.

### [Server]  
Only a server can call the method, throws a warning when called on a client.  

### [ServerCallback]  
Same as Server but does not throw a warning when called on client.  

### [Client]  
Only a Client can call the method, throws a warning when called on the server.  

## [ClientCallback]  
Same as Client but does not throw a warning when called on server.  

### [Command]  
Call this from a client to run this function on the server. Make sure to validate input etc. It's not possible to call this from a server. Use this as a wrapper around another function, if you want to call it from the server too.  

### [ClientRpc]  
The server uses a Remote Procedure Call (RPC) to run that function on clients.   

### [TargetRpc]  
This is an attribute that can be put on methods of Network Behaviour classes to allow them to be invoked on clients from a server. Unlike the ClientRpc attribute, these functions are invoked on one individual target client, not all of the ready clients.  

### [SyncVar]  
[SyncVars] are used to synchronize a variable from the server to all clients automatically. Don't assign them from a client, it's pointless. Don't let them be null, you will get errors. You can use int, long, float, string, Vector3 etc. (all simple types) and Network Identity and game object if the game object has a Network Identity attached to it. You can use [SyncVar Hooks] to run code on clients when they receive updates from the server.  

![AllNetworkComponents](https://github.com/BAStudio/OperationStarfall/assets/90895322/132d89d9-1f38-4d58-b27f-af40030db7ef)  
I'm not going to explain every single one, but if you want to know what each does, you can easily find it on their [documentation website](https://mirror-networking.gitbook.io/docs/manual/components).

# Examples

## NetworkManager and NetworkTransport  

This is the NetworkManager object. It manages all the networks I'm working on that have network identities. The NetworkManager component handles tasks like loading and other functions, such as spawning the player (with identity), network addressing, send rates, and so on. The HUD is a component that you can add if you don't want to create your own HUD for people joining. The KCP Transport handles various tasks like connecting, so don't forget to include it.  

![NetworkManager](https://github.com/BAStudio/OperationStarfall/assets/90895322/1a483984-429b-4d24-bd64-52cc2f6297fc)  
![NetworkManager1](https://github.com/BAStudio/OperationStarfall/assets/90895322/65f05142-8251-4000-9863-caf9183e7524)  
![NetworkTransport](https://github.com/BAStudio/OperationStarfall/assets/90895322/1ebf511f-0e63-4953-9bfa-f43ae70369a3)  
![NMHUD](https://github.com/BAStudio/OperationStarfall/assets/90895322/7159bf1b-a45a-4d2b-9296-c6dfcd2716bb)  

## Network Identity/Transform/Animator  

These components are attached to the warrior (player) and help identify anything related to networking. The Network Transform has both reliable and unreliable modes; the former consumes more bandwidth, so I've chosen reliable because it works better for me and seems to provide better latency. The Network Animator simply synchronizes the animations, and there's not much to explain about it.

![NetworkIdentity](https://github.com/BAStudio/OperationStarfall/assets/90895322/4fd571d3-a2cf-47eb-bce2-b8bc2bddefbf)  
![NetworkTransform](https://github.com/BAStudio/OperationStarfall/assets/90895322/2dbd1dbf-5e85-41ce-b28d-b375b9c1899b)  
![NetworkAnimator](https://github.com/BAStudio/OperationStarfall/assets/90895322/b5f9c5c8-f3cd-4c54-8e7f-873b449e1e73)  

## Network Spawn  

I've placed a Network Start Position component on the player spawn point because it helps the network manager determine where to spawn the player.  

![NSP](https://github.com/BAStudio/OperationStarfall/assets/90895322/851755d9-9f2d-4e55-b963-84784e814ca8)  

## Jump/Stamina/State Sync/Move Sync  

I use isLocalPlayer so that i can easily use the code for the clients etc.  
### Jump/Stamina
```csharp
private void Start()  
{  
    if (!isLocalPlayer) return;  

    _playerInput = GetComponent<PlayerInput>();  
    _playerControlsActions = _playerInput.actions;  

    _staminaLookup = GetComponent<StaminaLookup>();  

    levelReloader = FindObjectOfType<LevelReloader>();  

    _playerControlsActions["Jump"].performed += Jump;  
    _playerControlsActions["Grab"].performed += Grab;  

    _playerControlsActions["ReleaseGrab"].started += ReleaseGrab;  
    _playerControlsActions["ClimbUp"].started += ClimbUp;  
    _playerControlsActions["ResetLevel"].started += ResetLevel;  

    InstantiatePlayerAbility();  
    if (targetSelector != null) TargetingStart();  

    _playerControlsActions.Enable();  
}
```
### State

```csharp
private void FixedUpdate()
{
    if (!isLocalPlayer) return;
    
    if (targetSelector != null) TargetingStart(false);
    
    var isBlockingMovement = CannotMove || playerSpecialAbility != null && playerSpecialAbility.IsBlockingMovement;
    if (isBlockingMovement)
    {
        if(CannotMove)playerMovement.currentMovementState = MovementStates.Walking; // todo: dit moet wat netter gemaakt worden.
        return;
    }

    Vector2 moveInput = _playerControlsActions["Move"].ReadValue<Vector2>();
    var isSprinting = _playerControlsActions["SprintActivator"].ReadValue<float>() == 1 && moveInput.magnitude != 0;

    var canSprint = isSprinting && _staminaLookup.UseStamina("Sprinting");
    var canGrab = grabSkill.IsGrabbing && _staminaLookup.UseStamina("Grabbing");
    MovementStates currentMovementState;

    if (canSprint && _maySprint) currentMovementState = MovementStates.Sprinting;
    else if (!_maySprint) currentMovementState = MovementStates.Exhausted;
    else currentMovementState = MovementStates.Walking;

    playerMovement.currentMovementState = currentMovementState;
    if (comboSystem == null || !comboSystem.InCombo || !CannotMove) playerMovement.Move(moveInput);
}
```
### Move Sync

```csharp
private void FixedUpdate()
{
    if (!isLocalPlayer) return;
    if (_isMovementDisabled) return;

    CheckGroundState();

    if (_shouldJump)
    {
        _jumpDelayCounter++;
        if (_jumpDelayCounter == _jumpDelay)
        {
            _jumpDelayCounter = 0;
            _shouldJump = false;
            Jump();
        }
    }

    if (MayJump()) StartJump();
    else _jumpPrimed = false;

    if (_isMoving) currentMoveDuration += Time.deltaTime;

    CalculateVelocity();
    UpdateAnimation(Mathf.Abs(_velocity.x));

    if (_isGrounded && _velocity.magnitude == 0 && _lastVelocity.magnitude > 0) AnimationStop0();

    if (_isGrounded && _velocity.magnitude > 0 && _lastVelocity.magnitude == 0) onStartMoving?.Invoke();

    if (_isGrounded && _velocity.magnitude > 0) AnimationSync0();


    if (_isGrounded)
    {
        IsJumping = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    _lastVelocity = _velocity;
    if (_velocity.x == 0)
    {
        ResetMoveDuration();
        return;
    }
    UpdateMovement(_velocity);
}
```
## Pull Ability Sync  
I'm using the Command function here to ensure it's always synchronized with the server. This way, you can only see the server triggering the pull animation on both the client and server, but not yet on the client's side.  

That's why I'm creating a new function to synchronize it with the server for the client using ClientRPC. So now, if I integrate that function into the old regular DoSpecial function with proper connections, it should make the pull animation work on both screens for every player.  

```csharp
[Command(requiresAuthority = false)]
public void DoSpecial(int layerIndex)
{
    SyncSpecial(layerIndex);
    _animator.SetLayerWeight(layerIndex, 1f);
    _animator.SetBool(IsSpecialActive, true);
    _animator.SetTrigger(Special);
    StartCoroutine(WaitForTime());
    StartResetCoroutine();
}
[ClientRpc]
void SyncSpecial(int layerIndex)
{
    _animator.SetLayerWeight(layerIndex, 1f);
    _animator.SetBool(IsSpecialActive, true);
    _animator.SetTrigger(Special);
}
```

## Particles Sync  
In this case, I've made use of the Update function and isLocalPlayer to synchronize the elements that I modify within it. I've synchronized the ongroundwalk and onstopmoving by using [Command] and [ClientRpc] and moving them within the relevant if statements to ensure synchronization. onstopmoving is responsible for stopping the particles when you're not moving, while ongroundwalk starts them when you walk.  

Below that, I've synchronized the dust sprites, but they have a straightforward code structure. Therefore, I've employed an if statement to reuse the same function for two different purposes.  

```csharp
private void FixedUpdate()
{
    if (!isLocalPlayer)return;
    if (_isGrounded && _velocity.magnitude == 0 && _lastVelocity.magnitude > 0) AnimationStop();

    if (_isGrounded && _velocity.magnitude > 0 && _lastVelocity.magnitude == 0) onStartMoving?.Invoke();

    if (_isGrounded && _velocity.magnitude > 0) AnimationSync();
}
[Command, ClientRpc] void AnimationSync() => onGroundWalk?.Invoke();
[Command, ClientRpc] void AnimationStop() => onStopMoving?.Invoke();

private void CheckMoveDirection(Vector2 newDirection)
{
    if (newDirection.x == 0) return;
    if (newDirection.x < 0 && _lastVelocity.x >= 0)
    {
        onTurnLeft?.Invoke();
        if (!_isGrounded) return;
        AnimationSyncParticles0(0);
    }
    else if (newDirection.x > 0 && _lastVelocity.x <= 0)
    {
        onTurnRight?.Invoke();
        if (!_isGrounded) return;
        AnimationSyncParticles0(1);
}
[Command] void AnimationSyncParticles0(int n) => AnimationSyncParticles(n);
[ClientRpc] void AnimationSyncParticles(int n) { if (n == 0) onTurnLeftGrounded?.Invoke(); else onTurnRightGrounded?.Invoke(); }
```

# Editing Extension

If you want to be able to test your multiplayer code with a server and host, you can open a second editor with [parrel sync](https://forum.unity.com/threads/editor-extension-parrelsync-test-multiplayer-without-building-uecho-replacement.964388/)  