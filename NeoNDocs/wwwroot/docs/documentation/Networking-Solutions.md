## Uitleg van deze pagina

In de toekomst willen we de game multiplayer maken. Er zijn een aantal prototypes gemaakt om te verkennen welke software wij het beste kunnen gebruiken. Hieronder zijn de resultaten van dit onderzoek vinden.
Vooralsnog lijkt de beste keuze 'Mirror API' te zijn.

# **Mirror API**
Mirror is free &amp; open source

Mirror supports many different low level networking Transports.

Name | Type | Built-In
:-----------|:------------|:------------
Telepathy (TCP) | TCP | Yes
LLAPI (UNET) | UDP |Yes
Ninja.Websockets (Websockets) | Websockets | Yes
Apathy (Native TCP) | TCP | No
Ignorance (ENet) | UDP | No
LiteNetLib4Mirror (LiteNetLib) | UDP | No
FizzySteamyMirror (Steam) | Steam P2P | No

**Stress test:**
[https://youtu.be/mDCNff1S9ZU](https://youtu.be/mDCNff1S9ZU)

**Public discord:**
[https://discord.gg/N9QVxbM](https://discord.gg/N9QVxbM)

**Showcase (gemaakte games):**
[https://mirror-networking.com/showcase/](https://mirror-networking.com/showcase/)

**Documentation**
[https://mirror-networking.gitbook.io/docs/](https://mirror-networking.gitbook.io/docs/)

**Asset store**

https://assetstore.unity.com/packages/tools/network/mirror-129321

# **Unity Networking MLAPI**

**Transport layer**

A foundational network layer that will balance byte delivery with performance and reliability, and is UDP-based.

Voorbeeld bossgames heeft een TransportPicker: (UTP, PhotonTransport, Relay UTP)

Dus ook andere mogelijkheden?

**Bossroom game:**

https://github.com/Unity-Technologies/com.unity.multiplayer.samples.coop/releases/tag/v1.0.0-pre

**Documentation: ( weinig documentation en of tutorials )**

https://docs-multiplayer.unity3d.com/

**Blog:**

https://docs-multiplayer.unity3d.com/blog

# **Photon**

**Assetstore:**

https://assetstore.unity.com/packages/tools/network/pun-2-free-119922

**Photon Cloud - The Power Behind**

All applications you develop with our suite of Photon products will run in our Photon Cloud. Here we take care of service hosting, operations and scaling. You can fully concentrate on building your game or app!

**Free server for development?**
[https://www.photonengine.com/PUN/Pricing](https://www.photonengine.com/PUN/Pricing)

- Suitable for ˜ 8 k MAU
- 500 Msg/s per Room
- Up to 16 Peers per Room
- Includes 60.0 GB Traffic per Month
- CCU Burst not included

**Documentation:**

https://doc.photonengine.com/en-us/pun/current/demos-and-tutorials/pun-basics-tutorial/intro

**Showcase:**

https://www.photonengine.com/PUN/Showcase
