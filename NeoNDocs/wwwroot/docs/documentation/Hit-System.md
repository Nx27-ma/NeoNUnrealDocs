# Hit System

The hit system makes sure damage will only be done one time when hitting a target. When an attack is done, `CheckForHits()` will be called and it will loop over targets in range to add hits. The targets in range are determined by a `Physics.OverlapBox` in `GetTargetsInRange()`.

When `AddHit()` is called, the IDamageable is retrieved to be used in `OnHitTarget()`. In there, `TakeDamage()` is called to remove health.

We also want the player to freeze in place for a short moment when hitting something. To do that, we call `Freeze()` from the Freeze Force Mediator in the `OnHitATarget()` event. In the Combo Snap script we can also call `AddComboForce()` using the event.

![Hit System](https://github.com/BAStudio/OperationStarfall/assets/90683368/4b21d40e-3647-48cc-915a-0e669ea992d7)