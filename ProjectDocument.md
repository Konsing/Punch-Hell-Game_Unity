# PunchHell #

## Summary ##

PunchHell is a Touhou-style Danmaku (bullet hell) game, also known as a "shoot em' up." PunchHell takes inspiration and plays like many other shoot em' up games: a character is stationed on a stage that might appear to be scrolling vertically (or horizontally, as some games do it) and enemies spawn on the screen and approach the player's character in the stage. The enemies then spawn projectiles into the stage with varying behavior based on what sort of attacks that they were programmed to make. The player's goal is to dodge these bullets, kill the enemies with their own projectiles, and progress through the stages which present a variety of enemies to encounter and a variety of bullet patterns to dodge.

## Project Resources

[Web-playable version of your game.](https://itch.io/)  
[Trailor](https://youtube.com)  
[Press Kit](https://dopresskit.com/)  
[Proposal: make your own copy of the linked doc.](https://docs.google.com/document/d/1qwWCpMwKJGOLQ-rRJt8G8zisCa2XHFhv6zSWars0eWM/edit?usp=sharing)  

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. Explaining the button mappings and the most optimal gameplay strategy is encouraged.**

The gameplay is similar to traditional Danmaku games.

The player is able to move with directional keys as input. That is, movement is accomplished through the classic keys that we have all grown to know and love:

- W: Move up
- A: Move left
- S: Move down
- D: Move right
- ESC: Pause game

And as in many other bullet hell games, there are also gameplay elements which change how the player moves and interacts with the game. These gameplay elements, and their corresponding input keys, are enumerated as follows:

- *Score*. A score counter is displayed on the bottom left corner of the screen, and increases under the following conditions: an enemy is killed (and subsequently having their on-screen bullets converted to a point drop), a bullet is grazed, a blue point drop is collected.

- *Power*. The player has one stream of projectiles at the beginning of the stage. Two additional "turrets" can be acquired by the player through collecting red power ups, which some enemies drop. The power ups fill the meter, and when the power meter is full, another turret is spawned, up to a maximum of 3.

- *Precise Movement*; Input: Fire2/RClick. At normal player movement speed, macro dodging of bullets is easy. However, when patterns start becoming complex and there is less space to dodge, the player can switch to slow movement mode with the Fire2 input. In slow movement mode, the character's movement speed slows and a precise hitbox is shown to facilitate micro doging.

- *Life*. The player has a fixed number of lives, which are lost if the player comes into contact with bullets. If there are no lives remaining, then the game ends and the player is forced to restart or quit the game. After death, a short period of invincibility is granted to the player to prevent chain deaths.

- *Graze*. When doging bullets, there are two hitboxes that a bullet could come into contact with: the core hitbox, which kills the player if touching a bullet, and the graze hitbox, which adds to the player's score for every bullet that remains in contact with it. Coming close to bullets in such a fashion is known as "grazing," and in this game also fills up the Roll Meter which is described subsequently.

- *Roll*; Input: SPACE. The player's character can "Roll" and gain a short period of invincibility and increased movement speed. The player can only roll when the Roll Meter, displayed as a white bar on the HUD, is full. The Roll Meter fills through grazing bullets.


**Add it here if you did work that should be factored into your grade but does not fit easily into the proscribed roles! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least four such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The game's background consists of procedurally generated terrain produced with Perlin noise. The game can modify this terrain at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

**Describe the steps you took in your role as producer. Typical items include group scheduling mechanisms, links to meeting notes, descriptions of team logistics problems with their resolution, project organization tools (e.g., timelines, dependency/task tracking, Gantt charts, etc.), and repository management methodology.**

## User Interface and Input

**Describe your user interface and how it relates to gameplay. This can be done via the template.**
**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets, including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Game Logic

**Document the game states and game data you managed and the design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets, including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel and Polish

**Document what you added to and how you tweaked your game to improve its game feel.**
