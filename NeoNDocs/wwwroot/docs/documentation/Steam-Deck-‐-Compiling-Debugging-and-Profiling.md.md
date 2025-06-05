## Compiling

* On your dev pc, make sure you have the linux build support installed with your unity version.
* In build settings select target platform linux.
* Build it.
* Transfer the files to the Steam Deck.
   * For easy transfer of builds you can use SyncTrayzor to automatically transfer files.
   * Follow [this guide](https://www.kodeco.com/40446818-how-to-transfer-game-builds-to-a-steam-deck) to set up the auto transfer. Step 1 and 2 should already be completed on the Steam Deck and you can skip to page 3, PC Side Installation. If not; start from step 1.
   * Make sure you are on the same internet connection and you have no VPN turned on!
   * After completing the setup you can directly compile the Unity build to the folder you have chosen to sync to Steam Deck and it should automatically transfer the build.
   * If a build is already on the Steam Deck it will simply overwrite the changes allowing you to quickly test changes. This also works in gaming mode.

* If you’re only transferring files once or twice, this method is more recommended.
   * Put all the files into a folder and convert it to .zip.
   * Transfer the zip file to Steam Deck (usb, filetransfer).
   * Unpack the zip file.

* Run the .x84_64 file to run the game.

## Add the build to steam library

* Enter small picture mode.
* Select “_games_” at the top of your screen.
* Select “_add a Non-steam game to library_”.
* Select “_Browse_”. 
* At the bottom of your screen drop down the filter menu and select “_all files_”.
* Navigate to the folder with the game build and open the .x84_64 file.
* Select “_Add selected programs_”.
* The game can now be found in your library.


## Remote debugging and profiling the build
### Debugging
* Open the game on Steam Deck.
* Open the same version of the project in Rider on your dev pc.
* Click on the settings button on the top right next to the debug button.
* Select “_attach to Unity process_”.
* Select “_Add players address manually_”.
* Enter the IP and Port of your running build.
   * Go [here](https://github.com/BAStudio/OperationStarfall/wiki/Steam-Deck%3A-Compiling%2C-Debugging-and-Profiling/#finding-the-ip-and-port-of-your-running-build) to find the IP and Port.
* Select OK and the Unity process should attach.

### Profiling
* Open the project in Unity, make sure this is the same version that is running on the Steam Deck.
* Add the profiler tab in thee editor.
* Open the drop down menu next to profiler modules which should say "_playmode_".
* Select "_Enter IP_" and enter the IP of the build.
   * Go [here](https://github.com/BAStudio/OperationStarfall/wiki/Steam-Deck%3A-Compiling%2C-Debugging-and-Profiling/#finding-the-ip-and-port-of-your-running-build) to find the IP.


## Finding the IP and Port of your running build
* Open the Konsole on the Steam Deck.
* Input the command: 
`cat ~/.config/unity3d/DefaultCompany/Operation\ Starfall/Player.log | grep -i debugger`
![Screenshot_20231003_132635](https://github.com/BAStudio/OperationStarfall/assets/90691070/0a77e6c0-bbca-4710-9aa0-9374f17c4c45)
   * This will get you the port, (This number will change every time you start the game)
* Input the command:
`cat ~/.config/unity3d/DefaultCompany/Operation\ Starfall/Player.log | grep -i multi-casting`
![Screenshot_20231003_132552](https://github.com/BAStudio/OperationStarfall/assets/90691070/9e6b06f3-72d9-4f26-8773-32f5a423af9a)
   * This will get you the IP, (This number will stay the same every time you start the game)