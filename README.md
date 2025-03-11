# Arc
## MTEC-340 Midterm Project

### Proposal 

My game will be called "Arc", and it is inspired by the mobile game [Duet](https://www.duetgame.com/). The player will be controlling an arc, rotating it around falling blocks. 

Good Outcome: 
The game will function as explained below, with the player rotating the arc around falling blocks using the arrow keys. The speed of the falling blocks will gradually increase, and will also be affected by a freeze powerup which slows them down. The speed at which the arc rotates will also gradually increase at the same rate, and will be affected by a speedup powerup which allows it to rotate faster. The player will earn points for each block avoided, and the game will be over upon collision with the blocks. 

Better Outcome: 
The game will feature different UIs for the powerups (ie, the blocks are outlined in blue during the freeze powerup, or the arc is outlined in red during the speed powerup). The game will feature different music in the home screen than during gameplay, and will seamlessly layer two soundtracks together to create this. I am envisioning ambient introductory music that continues to play throughout the game, but a rhythmic component that only plays during gameplay.

Best Outcome: 
When powerups are in use, there will be a "progress" bar that shows how much longer until they go out of effect. This may require some additional research, as I would need to figure out a way to synchronize the progress bar with the use of the powerup. The transitions between the home screen and gameplay will be smooth. The home screen will begin with a large arc, the title, and a message indicating how to start the game. Once the player starts, the arc will gradually reduce in size and move to its initial position and the game will start. 

### Game Design Primer

Concept: 
The concept of the game is simple: the player rotates an arc to avoid collisions with falling objects. It is a minimalist arcade game. 

Core Mechanics:
The playable features are limited to controlling the direction of rotation of the arc. The speed of rotation will be constant, unless a powerup is in use. 

Control Schemes:
The player will use the right and left arrow keys to determine the direction of rotation. The arc will rotate around a fixed point, following a circular path. The player can click the spacebar to pause the game, and escape to quit.  

Story:
The story aspect does not really apply to this game--it only involves moving around geometric objects. 

Art Style:
The art style will be minimalist and sleek. I would like the game to have a simplistic, clean look. 

Win/Lose Conditions: 
The player earns points for each block that is avoided, and the game continues until a collision eventually occurs. There will be powerups that the player can "catch" to change either the arc's rotation speed or the speed at which the blocks are falling. Upon collision with the powerups, the appropriate speed change will occur temporarily until the powerup "runs out". 

