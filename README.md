# Anti-Terror-Control-Platform -> Multi-minigame Form Simulating '24'-esque anti terror operations

![Alt text](/Blackboard/SamplePathfind.gif)

## Notes/Know Bugs:

> *Important* Ongoing WIP issues such as thread lock conditions

> *Important* Several Minigames missing

> Randomized movement times to prevent gridlock when moving agents


## Features(Planned In Brackets)

ChatGPT-API enabled agents representing both terrorists and civilians

Card-based turnbase combat minigame at the same time as terrorist deduction game, code breaker game and UAV game

Generic logic project to allow any form of visulization

SVG code to render assets within c# form

## View of progress


**CURRENT 30/07/24 , SWAT Game Console MVP**

![SWAT Console Game](/Blackboard/README2.PNG)

**15/07/24 , SWAT Game Design**

![ALt text](/Blackboard/SwatgameTestPlay.png)

**06/07/24 , SWAT Game Rendering Begins**

![ALt text](/Blackboard/READMEImage.png)

**06/07/24 , click handlers**

![ALt text](/Blackboard/README1.png)

**11/04/24, Planning**

![ALt text](/Blackboard/Plan1.jpg)


## Latest Build

*30/07/24 , SWAT Game Console MVP*

![SWAT Console Game](/Blackboard/README2.PNG)

## Latest Update Notes:

```
30/07/24:{

	ScifiSim.Logic : {
		Models:{
			System:{
				RaidGame:{
					Core:[
						"Add Grid to be a container and logic handler for interconnected places"
						]
				}
			}
		}
	},
	ScifiSim.Test : {
		CardGameTest : ["Made console testing script to simulate grid generation and more in-depth gameplay"]
	}
	
}

```

## Latest Updates

*30/07/24 - SWAT Game Design*

Implemented console MVP of random house generation and enemy placement for cardgame MVP

![SWAT Console Game](/Blackboard/README2.PNG)

## Next Build

31/08/24 - Complete MVP  **On Track**

* SWAT MVP, Suspect viewer, codeword minigame with UI and functional/ interconnected

* User Guide adjusted to be clear. clean.

* Overall UI of application improved

* Intro scene detailing a how-to guide


## Skill developing

I planned on this project improving my skills in the following:

> SVG rednering

> Generic logic to allow externa lrendering of app

> Personal project for fun

## Installing and Compiling:

*To be completed * 
## Step 1: Install Visual Studio
1. Go to the [Visual Studio Download Page](https://visualstudio.microsoft.com/downloads/).
2. Download the **Visual Studio Community** edition.
3. Run the installer and follow the instructions.
4. During installation, ensure to select the **.NET desktop development** workload.

## Step 2: Open the Project
1. Open Visual Studio.
2. Click on **Open a project or solution**.
3. Navigate to the folder where your project is located and select the `.sln` (solution) file.

## Step 3: Compile the Project
1. Once the project is loaded in Visual Studio, go to the **Build** menu at the top.
2. Click on **Build Solution** or press `Ctrl+Shift+B`.

## Step 4: Get the .exe File
1. After the build is successful, open **File Explorer**.
2. Navigate to the project directory, then go to the `bin\Debug\net6.0-windows` or similar directory depending on your .NET version.
3. You will find the `.exe` file of your project in this directory.

## Troubleshooting
- If you encounter any errors during the build process, check the **Error List** at the bottom of Visual Studio for details and try to resolve them.
- Make sure all required dependencies and packages are installed by restoring NuGet packages if prompted.

That's it! You now have the executable file for your .NET WinForms project.

*Click on grid* - Spawn handcuffs 


Developed by Starshiplad 

[Twitter](https://twitter.com/StarshipladDevp) 

[Discord](https://discord.gg/jAqfVpmqdA)

![Developed by Starshipladdev](LogoFull.png)
