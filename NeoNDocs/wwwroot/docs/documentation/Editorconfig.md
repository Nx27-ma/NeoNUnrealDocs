## Editorconfig

Met de editorconfig worden code conventies automatisch toegepast in Rider, zodat er bijvoorbeeld suggesties worden gegeven als een variabele niet voldoet aan de code conventie.

### Setup

De eerste keer als Silent Cleanup gebruikt wordt moet `Built-in: Full Cleanup` geselecteerd worden.
<br><br>
Als er geen pop-up tevoorschijn komt is de instelling te vinden bij `Settings > Editor > Code Cleanup`

![Full Cleanup showcase](https://user-images.githubusercontent.com/70685433/203798115-c4e7c301-5dbd-4e37-bf75-c993cb59bac3.gif)

### Keybinds

Functie | Keybind | Uitleg
:-----------|:------------|:------------
Reformat code | `CTRL+ALT+ENTER` | Dit haalt witregels weg en zorgt dat de code netjes gewrapped wordt.
Silent Cleanup | `CTRL+E+F` | Dit past in sommige gevallen de code aan, zoals ongebruikte usings weghalen en een private access modifier toevoegen als er nog geen is. Ook reformat dit automatisch de code.