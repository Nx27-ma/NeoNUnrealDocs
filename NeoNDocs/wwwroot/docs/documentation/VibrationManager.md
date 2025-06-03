# Vibrate Manager

Met de vibrate manager kan je relatief makkelijk vibraties triggeren (alsin vibraties voor je game controller). Dit systeem maakt gebruik van &quot;VibrationConfigs&quot;.

## Hoe maak ik een EventTypes aan?

Om een vibration config aan te maken moet je eerst een &quot;EventTypes&quot; aanmaken ( **LET OP:** Unity zelf heeft &quot;EventType&quot; dus je moet opletten dat je wel de &quot;s&quot; erachter zet als je bijvoorbeeld de EventTypes enum moet importeren.)

De EventTypes kan je vinden in Assets/Scripts/Events/EventTypes

<img width="600px" src="images/vibrationmanager/screenshot-1.png"/>

Zo ziet de EventTypes er nu uit, wij willen dus een nieuwe Type aanmaken. Wat je doet is een komma zetten achter de laatste Type en vervolgens vul je de naam in van je Type, zo ziet dat eruit:

<img width="600px" src="images/vibrationmanager/screenshot-2.png"/>

&quot;Example&quot; is op dit moment grijs omdat het nog nergens gebruikt wordt.

## Hoe maak ik een vibration config aan?

Dit zou je op verschillende manieren kunnen doen, de makkelijkste manier is door een &quot;FlatVibrationConfig&quot; te gebruiken. Deze config gebruik je als je standaard values wilt hebben voor je vibratie (met andere vibration configs kan je de left/right motor frequency beinvloeden door middel van &quot;EventData&quot;).

Vervolgens open je de class &quot;VibrateInitializer&quot; (zit in de map: Assets/Scripts/Vibration)

<img width="600px" src="images/vibrationmanager/screenshot-3.png"/>

Zoals je kan zien gebruikt de &quot;PULL&quot; EventTypes al een FlatVibrationConfig, om dus een nieuwe FlatVibrationConfig aan te maken type je dit: vibrateManager.AddVibrationConfig(EventTypes. **Example** , new FlatVibrationConfig(0.8f, 0.4f, 1f));

**LET OP:** De leftMotorFrequency/rightMotorFrequency kan nooit hoger zijn dan 1f, als je dat wel doet zet die hem simpelweg terug naar 1f.

De eerste parameter van FlatVibrationConfig staat voor de &quot;leftMotorFrequency&quot; (ofterwijl de linker kant van de controller) in dit geval is het 0.8f.

De tweede parameter staat voor de &quot;rightMotorFrequency&quot; (ofterwijl de rechter kant van de controller) in dit geval is het 0.4f.

De derde en laatste parameter staat voor de &quot;vibrationTime&quot; dit is de vibratie tijd in secondes (ofterwijl hoelang de vibratie aan moet staan) in dit geval is het 1f.

Zo zou het er vervolgens uit moeten zien:

<img width="600px" src="images/vibrationmanager/screenshot-4.png"/>

## Hoe maak ik een &quot;EventData&quot; vibration config?

Een config als dit gebruik je als je de leftMotorFrequency/rightMotorFrequency/vibrationTime wilt beinvloeden door middel van interacties in de game, in het geval van de PushVibrationConfig is de &quot;modifier&quot; het aantal objecten wat je heb gepushed. Als je dus 3 objecten pushed is de leftMotorFrequency/rightMotorFrequency 3x zo groot.

Voorbeeld:

<img width="600px" src="images/vibrationmanager/screenshot-5.png"/>

Wat je hier ziet is dat de float modifier word aangepast naar &quot;pushData.GetPushCount();&quot;

Om een config zoals dit te maken ga je naar Assets/Scripts/Events/EventDataObjects

en maak je een nieuwe class aan die extend van &quot;EventData&quot;.

**LET OP:** Je moet de constructor zelf aanmaken en vervolgens de &quot;SetEventType(EventTypes.Example)&quot; aanroepen, zoals je in dit voorbeeld ziet.

<img width="600px" src="images/vibrationmanager/screenshot-6.png"/>

Vervolgens heb je uiteraard nog een variabel nodig wat de modifier zou moeten zijn, in dit geval ga ik een random getal aanmaken.

<img width="600px" src="images/vibrationmanager/screenshot-7.png"/>

Nu moet je nog een VibrationConfig aanmaken, dat doe je door weer naar Assets/Scripts/Vibration/Configs/ConfigObjects te gaan. Hier maak je een nieuwe class aan die extend van VibrationConfig, zo zou dit eruit moeten zien:

<img width="600px" src="images/vibrationmanager/screenshot-8.png"/>

In de &quot;Initialize()&quot; functie moet jij je EventData/leftMotorFrequency/rightMotorFrequency initializeren. Begin door een float aan te maken die staat voor de modifier (aangeraden is het om hem eerst op 1f te zetten) en vervolgens een float voor de leftMotorFrequency/rightMotorFrequency/vibrationTime. Zo zou het er ongeveer uit moeten zien:

<img width="600px" src="images/vibrationmanager/screenshot-9.png"/>

Al deze values kan je uiteraard ook buiten de functie zetten, dat maakt niet zo heel veel uit; enkel doe ik het in dit voorbeeld in de functie zelf.

Vervolgens wil je de EventData aanroepen, hier zie je een voorbeeld hoe dat moet:

<img width="600px" src="images/vibrationmanager/screenshot-10.png"/>

Nu zie je dat ik met succes exampleData.RandomNumber; kan doen en aan de modifier kan geven, enkel moeten we nog wel de left/right motor frequency en vibrationTime instellen. Dat doe je op de volgende manier:

<img width="600px" src="images/vibrationmanager/screenshot-11.png"/>

Nu heb je met succes je vibration config aangemaakt. Uiteraard moet je hem nog initializeren. Dat doe je door naar Assets/Scripts/Vibration te gaan en de &quot;VibrationInitializer&quot; class te openen. ![](RackMultipart20220201-4-lmwhzc_html_3b8bfb382fd81af2.png)

Zo ziet dit eruit, voeg nu de volgende line toe:

vibrateManager.AddVibrationConfig(EventTypes. **Example** , new ExampleEventDataConfig());

Nu ziet de class er zo uit:

<img width="600px" src="images/vibrationmanager/screenshot-12.png"/>

Dit was de laatste stap om een config aan te maken.

## Hoe stel ik mijn scene in?

Hiervoor heb je een scene nodig, in de scene maak je een empty gameobject aan genaamd &quot;VibrateManager&quot; en voeg je de volgende 2 scripts toe:

- Vibrate Initializer
- Vibrate Manager

Zo zou dit eruit moeten zien:

**LET OP:** Er mag **NOOIT** meer dan 1 VibrateManager zijn, kijk dus goed of er al een VibrateManager in de scene zit!

<img width="600px" src="images/vibrationmanager/screenshot-13.png"/>

**LET OP:** Grote kans dat de Vibrate Bridge script al op de player prefabs zit, het is in dat geval niet nodig om nog een keer een vibrate bridge script op de player te zetten. De scripts staan als child game object onder de naam &quot;Vibrations&quot;.

Nu moet je nog een &quot;Vibrate Bridge&quot; aanmaken, in dit geval maak ik een empty gameobject genaamd &quot;Vibrations&quot; en zet ik het als child op de player vervolgens voeg ik het Vibrate Bridge script toe. Zo ziet dat eruit:

<img width="600px" src="images/vibrationmanager/screenshot-14.png"/>

## Hoe trigger ik een vibration?

Het is aangeraden om dit te doen doormiddel van events in de inspector, in dit voorbeeld gebruik ik het &quot;Push Effect&quot; &quot;On Push Event&quot; event om een vibratie te triggeren.

Voeg in het event een nieuwe functie toe, en zet als object het &quot;Vibrations&quot; gameobject erin.

Daarna kan je een functie uitvoeren, kies vervolgens het &quot;Vibrate Bridge&quot; script en klik op de &quot;TriggerVibration&quot; functie (als je een EventData parameter heb in je event moet je de TriggerVibration functie helemaal bovenaan kiezen) Zo zou dit eruit moeten zien:

<img width="600px" src="images/vibrationmanager/screenshot-15.png"/>

Omdat het On Push Event een EventData parameter bevat hoef je niet zelf nog een parameter mee te geven (PushData in dit geval), bij een FlatVibrationConfig moet dit wel.

Nu als dit event word uitgevoerd word er dus ook een vibratie getriggered.

Als je een vibratie wilt triggeren zonder event data doe je dezelfde stappen, enkel gebruik je nu de TriggerVibration functie helemaal onderaan, zo ziet dat eruit:

<img width="600px" src="images/vibrationmanager/screenshot-16.png"/>

Je ziet dat je nu wat kan invullen rechtsonderin, hier vul je de naam van je EventTypes in. Bij deze documentatie gebruikte we de naam &quot;Example&quot; die vullen we hier nu in. (het is niet hoofdletter gevoelig)

<img width="600px" src="images/vibrationmanager/screenshot-17.png"/>

Nu als dit event word uitgevoerd word er dus ook een vibratie getriggered.

## Hoe maak ik een event met EventData?

Dit is relatief simpel als je eerder een event heb aangemaakt met een parameter.

Begin met een UnityEvent aan te maken met als Parameter je event data, in ons geval ziet het er zo uit:

<img width="600px" src="images/vibrationmanager/screenshot-18.png"/>

Vervolgens moet je het event ergens callen met als parameter ExampleEventData, in dit geval doe ik het in een lege functie. Zo ziet dat eruit:

<img width="600px" src="images/vibrationmanager/screenshot-19.png"/>

En dit was het, je bent nu een expert in het aanmaken en triggeren van vibraties!
