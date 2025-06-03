
##  Starten met leren van mlagents

Om te starten met het leren van mlagents, moet je eerst een venv opzetten met mlagents, dat doe je door:
python te installeren als je geen python hebt.

De venv opzetten door:

```py -m venv venv```

Om de venv te activeren moet je in de cmd ```venv\scripts\activate``` intypen elke keer als je begint met mlagents leren. daarna de volgende commands voor het installeren van de benodigdheden:

Om de rest te installeren in de venv, kun je het volgende in typen:
```
pip install --upgrade pip

pip install protobuf==3.20.3

pip3 install torch torchvision torchaudio --index-url https://download.pytorch.org/whl/cu117

pip install mlagents
```
Om te testen of het werkt kun je mlagents-learn intypen, als er een groot unity logo in de cmd komt betekent dat het goed is geinstalleert.
die command gebruik je later ook voor het trainen van de agent

## Learning van mlagents

Voor het goed leren van mlagents heb je een configuration file nodig, meestal zitten er al een paar in het project.
Maar als je een eigen wilt maken kan dat door een file te maken en het naam.yaml te noemen. yaml is het bestand soort van configuration files.

Op deze site staan alle hyperparameters die je in je configuration kan gebruiken: https://unity-technologies.github.io/ml-agents/Training-Configuration-File/

Je kunt deze file downloaden en de file naam van .txt naar .yaml te veranderen en zou het moeten werken:
[Agent.txt](https://github.com/BAStudio/OperationStarfall/files/12748898/Agent.txt)

Om de eerste training te starten type je mlagents-learn dan enter en druk je op de play knop in unity. De agent begint met trainen en dat kan je ook meteen zien.

Het is ook mogelijk om via een build te trainen.

Om via een build te trainen moet je eerst een build maken, en dan bij het start command van het trainen van de mlagents, ```mlagents-learn``` de command env= C:path\example.exe, dan kan je nog de command --num-env number of runs voor meer runs van de build.

Om het te verbergen en een headless run te doen kun je de command --no-graphics erbij gooien. Dan heb je ook een command --resume wat de gestopte run hervat, en de command force die een nieuwe training run forceert dus weer van nul leert. 

Dus de commands zijn:
```
mlagents-learn
Start command van het trainen

--env C:path\example.exe
Envirement kiezen

--num-env aantal
Aantal envirements bij trainen

--no-graphics
Headless run (zonder visuals)

--force
Nieuwe training beginnen

--resume
Hervatten van training
```
Dan gaat de command er ongeveer zo uitzien: ```mlagents-learn --env configfiles/Ai.yaml build/run.exe --num-env 5 --resume```

Er zijn nog heel wat andere commands die je kunt gebruiken bijvoorbeel --time-scale 10, om alle commands te zien typ de command mlagents-learn --help
### commands stoppen

Als je sommige commands gebruikt, dan kan het zijn dat het het niet gebruiken ervan dat het nog steeds in werking gaat.
Om dat te stoppen kun je in de configuration file de parameters weg halen.
bijvoorbeeld:
Na het gebruik van de command --env C:path\example.exe, krijg je deze parameters in de configuration file die je gebruikt:
```
  env_settings:
    env_path: null
    env_args: null
    base_port: 5005
    num_envs: 1
    num_areas: 1
    seed: -1
    max_lifetime_restarts: 10
    restarts_rate_limit_n: 1
    restarts_rate_limit_period_s: 60
```

Om verder te gaan zonder het gerbuik van een envirement, kun je deze parameters gewoon weg halen.

### De demonstration recorder component

Om te beginen met gail en behavioral cloning, heb je eerst een .demo file nodig. dat kun je maken door de demonstation recorder component aan je agent toe te voegen.
En behavior type op hueristic zetten, voordat je kan recorden moet je nog twee dingen doen. de record bool in de component checken en de heuristic override gevuld hebben.

In de component heb je nog de demonstration name, wat de naam wordt van de .demo file. en de demonstration folder. wat de naam is die je mee wilt geven dat de folder wordt.

Dan druk je op play en speel je een paar minuten, bij num steps to record in de component oftewel hoeveel updates tot de record stopt. Stopt de update, behalve als je het op nul hebt gezet gaat het oneindig door tot je het zelf stopt

#### gail
Je hebt gail en behavioral cloning. waarbij behavioral cloning het excact nadoen van je demo, en gail het varieren van de demo om mogelijk beter te worden dan de demo.
Om dat te starten moet je eerst de config file openen om onder extrinctics de gail parameter te zetten. bijvoorbeeld:
```
      extrinsic:
        gamma: 0.99
        strength: 0.99
      gail:
        strenght:0.5
        demo_path: C:path\example.exe
```
#### behavioral cloning

De behavioral cloning parameter kan gebruikt worden voor het excact clonen van je demo file.
In de parameter kan je de strenght veranderen, dus hoeveel hij van jouw cloned.
en net als bij gail ook de demo file path.
```
    reward_signals:
      extrinsic:
        gamma: 0.99
        strength: 0.99
      gail:
        strenght:0.5
        demo_path: C:path\example.exe
    behavioral_cloning:
      strenght:0.5
      demo_path: C:path\example.exe
```

## scripten van mlagents

Om  te beginnen met een mlagents ai te maken moet het object dat een agent wordt, de component decisionrequester hebben.

Als je een nieuwe agent wil maken kun je een nieuwe script aanmaken en verander je de monobehaviour naar Agent.

Dan heeft die script ook de using Unity.MLAgents;, using Unity.MLAgents.Actuators; en using Unity.MLAgents.Sensors; nodig. De sensors is alleen nodig als je zelf observations toevoegt zoals waar een target is.

Bijvoorbeeld 
```
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(Enemy.transform.localPosition);
    }
```
De using Unity.MLAgents.Sensors; is nodig om een Vector observatie toe te voegen

De CollectObservations method wordt hieronder uitgelegt bij verschillende functies en override methods

### verschillende functies en override methods

je hebt verschillende methods waar je gebruik van kan maken om je ai te scripten, met override override je de methods die je inherit van de base class Agent.
Je maakt gebruik van die methods door public override void method naam.
 
Bijvoorbeeld:
```
public override void OnEpisodeBegin()
{

}
```
De OnEpisodeBegin method kan gezien worden als een start functie die elke EndEpisode wordt aangeroepen

Alles in de OnEpisodeBegin method wordt elke keer aangeroept als de episode opnieuw begint, bijvoorbeeld, agent raakt enemy aan episode eindigt nieuwe begint, en dan begint deze method.

#### de OnActionReceived method

De OnActionReceived method, is een method die elke keer dat de agent een beslissing wordt aangeroepen

Deze method wordt gebruikt voor het levend maken van de agent, oftewel. dat de agent wat doet bij elke beslissing.

bijvoorbeeld:
```
    public override void OnActionReceived(ActionBuffers actions)
    {
        this.transform.Translate(Vector3.right * (actions.DiscreteActions[0] -1) * moveSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.forward * (actions.DiscreteActions[1] -1) * moveSpeed * Time.deltaTime);
    }
```
Een discreteAction is iets wat de ai kan gebruiken in dit geval kan de discrete action de value 0 to en met 2 hebben. 

Door er 1 af te trekken wordt het -1 tot 1 wat resulteert in dat de agent links rechts vooruit en achteruit kan lopen

Om de agent rondt te bewegen, wordt de output DiscreteActions gebruikt om de agent te bewegen, zo kan de agent zichzelf bewegen en ervand leren

#### de Initialize method

De Initialize method is gewoon de start functie van de agent, bijvoorbeeld:
```
    public override void Initialize()
    {
        resetPosition = transform.position;
    }
```

#### de Heuristic method

De heuristic method is voor als je de agent zelf wil testen of een demonstation wilt recorden.
In de heuristic method kijk je naar welke inputs jij geeft en pas je dat aan op wat de agent doet bijvoorbeeld:
```
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                discreteActions[0] = 2;
            }
            if (Input.GetKey(KeyCode.D))
            {
                discreteActions[0] = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {
                discreteActions[0] = 2;
            }
            if (Input.GetKey(KeyCode.S))
            {
                discreteActions[0] = 0;
            }
        }
    }
```
Hier is  ActionSegment<int> discreteActions = actionsOut.DiscreteActions die je aanpast, wat later de agent bestuurd.
Oftewel de discrete actions wat de ai gaat gebruiken, in dit geval om rond te lopen. 
Maar het kan ook gebruikt worden voor anderen dingen zoals een functie aanroepen om te springen.
Verder wordt er gekeken wat wordt ingeput en op basis daarvan worden de outputs gegeven.

#### de EndEpisode() functie

De EndEpisode() function eindigt deze episode en start de nieuwe. dit gebruik je bijvoorbeeld wanneer hij zijn doel heeft behaalt of dood is gegaan

#### de AddReward() functie

Deze functie zegt de agent of hij de goede of verkeerde dingen doet bijvoorbeeld als de agent ergens heen moet lopen maar loopt helemaal verkeerd krijgt hij een penalty via ```AddReward(-1f)``` of hij loopt de goede kant op en krijgt hij een reward via ```AddReward(1f)```


 