# Dynamic Background music system

## Wat is het idee
![Blank_diagram_15](https://user-images.githubusercontent.com/70898423/199724111-93c9c6fa-8bb8-46d4-920c-2afc1534b1b4.png)


Elke song bestaat uit layers van audio clips, elke song heeft een base layer die altijd afspeelt en de andere layers die kunnen dynamically "toegevoegd" worden door ze te unmuten, ze spelen dan altijd af zodat ze in-sync blijven, maar je hoort ze niet.

## UML Diagram + visualisatie unity hierarchy
![image](https://user-images.githubusercontent.com/70898423/199699255-80e73311-a5c6-4232-94b8-dfb7b92ae04e.png)

We hebben de music system gebouwd met het gebruik van de Unity Audio Mixer. In de hierarchy hebben we 3 componenten gemaakt om met de sound mixer dynamisch sound te laten werken. Een Track class met alle song data. Een Music Player die de liedjes afspeelt en de layers aan en uit zet, en een Music Manager die deze liedjes bij houdt en functies van de Track Player op roept.

Er zijn twee vaste music groupen waar liedjes en layers in worden gezet. 

## Hoe werkt het script
Met SetVolume kan je direct een layer uit zetten, hij gaat dan bijvoorbeeld gelijk van 100 naar 0. Met LerpVolumeOn/LerpVolumeOff kan je een layer aan of uit lerpen en je kan ook als je wilt een custom lerp duration geven als je wilt dat hij iets sneller of iets langzamer lerpt dan de default duration.
Met TurnOnSong/TurnOffSong kan je een song aan- of uitzetten, hij lerpt dan de volume omhoog of omlaag op de parent group. Bij de TurnOffSong zet hij daarna de audiosources uit voor performance. 

![Blank_diagram_10](https://user-images.githubusercontent.com/70898423/200540332-8f0caca2-85e9-485c-b55d-028b929e882b.png)

### Track.cs
| Data    | Description |
| :---       |    :---   |  
| name(string) | Naam van de aangegeven lied   |
| isPlaying(bool) | De boolean die bijhoudt of de track aan het afspelen is of niet. 
| Layerstruct(struct) |     <table>  <tbody>  <tr>  <td>Disabled(bool)</td>  <td>een boolean die zegt of de track aan gaat in het begin of niet</td>  </tr>   <tr>  <td>Clip(audioclip)</td>  <td>De audio clip die in de gegeven Layer wordt gebruikt</td>  </tr>  </tbody>  </table>              |
| LayersStruct[] layers   | De array van layers die de track heeft     |


### TrackPlayer.cs
| Function / Data    | Description |
| :---       |    :---   |  
| currentTrack(Track)  | Een Track variable waar de afspelende track in zit om te kunnen manipulaten     |
| SongExposedString(string) | De naam van de exposed string in de Mixer Group vaar deze track bij hoort    |
| mixer(AudioMixer)   | De static audio mixer      |
| ExposedLayerString[] | Een array die gelijk staat aan een audio group. Dit laat ons de volume on de fly veranderen       |
| AssignedMixerGroup[] | De mixer group die de track gebruikt       |
| minVolume(float)   | De opgezet minimum volume die de track aan neemt zodra het niet meer te horen moet zijn      |
| maxVolume(float)   | De ogezet maximum volume die de track aan neemt zodra het wel weer te horen moet zijn        |
| Fadeduration(float)   | De hoeveelheid tijd een fade duurt        |
| MusicMixerStruct(struct)    | <table>  <tbody>  <tr>  <td>Group(AudioMixerGroup)</td>  <td>De aangegeven mixer group die de struct kan aangeven</td>  </tr>  <tr>  <td>ExposedParam(string)</td>  <td>De exposed paramater die de struct aangegeven heeft</td>  </tr>  </tbody>  </table>       |
| CurrentGroupPools(MusicMixerStruct[])    | De werkende variable die de Struct bijhoudt        |
| SetMixer(AudioMixer)     | zets een static variable neer die zorgt ervoor dat alle bestaande TrackPlayer scripts refereren naar de music group        |
| MuteLayers()    | Een foreach loop die door elke layer gaat, en bij elke die de Disabled bool aan hebben de volume of minVolume zetten        |
| AssignMixerGroups()    | Checked eerst hoeveel layers er zijn, en zet daarna de layers op die goeie plekken in order         |
| CreateSources()    | Maakt een nieuwe audio source aan de aangegeven gameobject        | 
| InitializeSources()     | Zet de clip tracks op in de gemaakte sources, en assigned ze ook aan de goeie mixer group        |
| ClearSources()    | clears and deletes de audio sources die niet meer gebruikt worden        |
| SetVolume(int, float)    | Zet de Volume van de aangegeven mixer group meteen in een aanroep        |
| ToggleFadeLayer(params (int[], bool)[] ) | Fade de aangegeven layer aan of uit , heeft params keyword dus je kan meerdere in 1 function call faden        |
| StartFadeIn()    | Start de Enumerator die de Lerp initiate om her op mute te zetten        | 
| StartFadeOut()    | Start de Enumerator die de Lerp initiate om her op mute te zetten        | 
| FadeIn() : Enumerator    | De Enumerator die de volume fade off beheert        |
| FadeOut() : Enumerator    | De Enumerator die de volume fade in beheert        |
| Fade(params (string, bool)[] ) : Enumerator    | De Enumerator die meerdere layers kan aanemen en met de FadeLayer functie dan uit of aan fade |
| FadeLayer(string, float ,bool) : Enumerator | De Enumerator die de aangegeven layer uit of aan fade       |

### MusicManager.cs
| Function / Data   | Description |
| :---       |    :---   |  
| Mixer(AudioMixer)  | Gebruikt voor referencie naar de mixer     |
| volume(float)   | Een float value om een volume bij te houden      |
| TransitionDelay(float)   | De tijd dat het duurt om van een lied naar een andere te transitionen      |
| Tracks[]   | Een array van alle Tracks        |
| TrackPlayer[]   | Array van alle track players        |
| currentTrackPlayer    | De Track Player die nu actief is        |
| ChangeGlobalBGVolume()    | Functie die de master volume van alles verandert        |
| Play()    | Start de huidige lied        |
| Stop()    | Stopt de huidige lied        |
| FadeOffLayer(params int[])    | Fade de aangegeven layer(s) volume naar aan       |
| FadeOnLayer(params int[])    | Fade de aangegeven layer(s) volume naar uit        |
| PlayTrack()    | Speelt een track af, en start ook de transitie ertussen        |
| Transition(int) : Enumerator    | De transitie tussen twee tracks         |
| SetCurrentTrack(TrackPlayer, Track)    | Zets de nieuwe actieve track in de track player        |
| UpdateCurrentTrack()    | Wisseled tussen de twee TrackPlayers        |

## Hoe werkt het in Unity inspector
### Music Manager
In de Music Manager heb je eerst referentie naar de mixer die de muziek zal gebruiken. 
Volume is voor als je het globaal wil muten. Transition Delay is de tijd dat het duurt tot de volgende track begint na een transition.
Track instellingen. Dit zijn de tracks die je zal afspelen. Je kunt hier een toevoegen en daarna instellen. Beginnend met de naam. Dit is de naam van de track zelf.
Track Layers. Dit is waar je de layers in zet als clip tracks. De Bool Disabled is voor het aan en uit zetten ervan. Als je wilt dat iets niet meteen afspeeld dan zet je het aan. Als je wilt dat het op startup begint dan zet je het uit. 
Track sources is waar de track vandaan komt. Dit zal in meeste gevallen gewoon leeg blijven omdat het globaal afspeelt. Maar als er bijvoorbeeld een Radio zal zijn die iets hoort af te spelen dan kan dit gebruikt worden. 

### Track Player
De Track Player's inspector is om het op te zetten van de mixer groups die het zal gebruiken. 
min/max volume. Dit dicteerd wat de volume is als het uit is en aan is. 
De Fade Duration is voor hoe lang de fade duurt om af te zijn. Dit is voor het fine tunen van de feel muziek. 
De Group Pools is waar de muziek wordt gezet als het actief is en niet.
De Elementen zelf zijn de groups. Dit is een hierarchy van de hoeveelhijd mixer groepen in volgorde van waneer het gebruikt hoort te zijn. Dus bovenaan heb je de parent mixer, daarna child 1, 2, 3 enz. Dit wordt neergezet met referentie naar de aangegeven mixer zelf, en daarna de exposed string parameter. 


![MusicManager](https://user-images.githubusercontent.com/70898423/199721403-8e855506-12db-40dc-95a5-79974255d615.png) ![TrackPlayer](https://user-images.githubusercontent.com/70898423/199721878-2d796177-4ac2-463d-bf19-8489b110fd36.png)


