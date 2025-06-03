## Health System
Efficient Health System that does and has everything you'd expect from a health system.

The Health System allows entities to have HealthData. Which does a number of things, including but not limited to:
* Track the current amount of Health.
* Create "HealthEvents" that can parse data when called.
* Contains HealthExtensions, allowing the methods used in this system to be called on any gameObject.
* And more.

Methods | Explanation
:-----------|:------------
AddHealth(float)    | Adds Health to current amount.
TakeDamage(float)   | Remove Health to current amount.
Resurrect(float)    | Allows entities to be resurrected.
Kill()              | Kills entities by calling the Die() method.

<br>

### AddHealth()
This method allows entities to gain health based on the parameter parsed when calling this method.
#### Example:
```cs
gameObject.AddHealth(health);
```

<br>

### TakeDamage()
This method allows entities to take damage which removes health based on the paramater parsed when calling this method.
#### Example:
```cs
gameObject.TakeDamage(health);
```

<br>

### Resurrect()
This method allows entities to be resurrected.
#### Example:
```cs
gameObject.Resurrect(health);
```

<br>

### Die()
This method sets the variables as if the entity no longer has health.

<br>

### Kill()
This method kills the entity by calling the Die() method.
#### Example:
```cs
gameObject.Kill();
```