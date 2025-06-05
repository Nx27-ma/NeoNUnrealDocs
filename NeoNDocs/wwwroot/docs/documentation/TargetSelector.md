**TargetSelector**

De target selector heeft 2 input methodes. Een voor de muis en een voor de joystick. Dit zodat hij voor pc en controller gebruikt kan worden.

ControllerMove // InputAction met de direction van de controller.
MouseMove // InputAction met de muis positie

**Inspector Settings**

Blocking layers, The layers that block your selecting raycast
Max Collision offset, If the raycast hit something, if it&#39;s within this range you can still select it.
Angle tolerance, How close should your direction be to the selectable direction
Max selectable distance, how close should the selectable be before you can select it.
Joystick deadzone, when will the joystick input be processed

**Selectable**

Om een object selectable te maken moet je hem de Selectable class geven. Dit zorgt dat hij geselecteerd kan worden en dat de warrior er bijvoorbeeld kan naartoe pushen. Als je ook de select effect wil moet je de selectable prefab als child toevoegen.
