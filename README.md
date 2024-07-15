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

**CURRENT - 15/07/24 , SWAT Game Design**

![ALt text](/Blackboard/SwatgameTestPlay.png)

**06/07/24 , SWAT Game Rendering Begins**

![ALt text](/Blackboard/READMEImage.png)

**06/07/24 , click handlers**

![ALt text](/Blackboard/README1.png)

**11/04/24, Planning**

![ALt text](/Blackboard/Plan1.jpg)


## Latest Build

*15/07/24 , SWAT Game Design*

![ALt text](/Blackboard/SwatgameTestPlay.png)

## Latest Update Notes:

```
15/07/24:{

	ScifiSim.Logic : {
		Models:{
			System:{
				RaidGame:{
					Core:[
						"Added Deck to handle in-game card handling",
						"Added Card to associate action with a unique card",
						]
				}
			}
		}
	},
	ScifiSim.Test : {
		CardGameTest : ["Made console testing script to simulate UI for new Deck and Card mechanics, and renderign text based on actions to implement core gameplay"]
	}
	
}

```

## Latest Updates

*15/07/24 - SWAT Game Design*

Implemented basic COnsole-based UI for SWAT game, ran a test game for MVP gameplay 

![ALt text](/Blackboard/SwatgameTestPlay.png)

## Next Build

30/07/24 - BaseGame  **Delayed 3 Months Due To Contract Work**

* SWAT game MVP implemented

* Handcuffing suspected terrorist will prevent movement and plot


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
