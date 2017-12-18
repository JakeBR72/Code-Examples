FEATURES FOR SPRINT SIX:

-Main Menu a main menu was implemented at the start of the Mario game.
-Konomai code was implemented entering up up down down left right left right to get it.
-LevelEditor, this is accessed in debug mode by pressing 'p' and scrolling will change which object you are placing with
mouseclick1
-Achievements earned throughout the game can be seen in the main menu's achievements screen after earning them in game,
kiling a goomba is a simple first achievement.
-World 1-2 can be selected at the world selector screen or achieved after beating world 1-1, the warp room is present, however
it is not functional and the coin room was not added.
-World 1-4 can be selected at the world selector screen or achieved after beating world 1-2, the bowser is an unkillable 
monster.
-Save and loading can be done through the use of pause(Enter) and exiting the world to save and then loading in the main
menu.
-Global gravity can be altered by entering debug mode and pressing 'F' to decrease'G' to increase and 'R' to reset. 

Instructions:

Instructions for the main menu are given in the bottom left hand corner. Basic Mario movement was unaltered from what
was given by the instructors. Keys for new features are stated in their corresponding entries above. Spacebar/Start will 
pulse through the level list. A detailed list of mappings is below

Keyboard/GamePad
X/X -> Run
Z/A -> Up
Down/DPadDown -> Down
Left/DPadLeft -> Left
Right/DPadRight -> Right
Enter/Start -> Skip Level
Q/Back -> Quit
P -> Toggles debug mode
G* -> Gravity Increase
F* -> Gravity Decrease
R* -> Gravity Reset
Y* -> Mario turns small
T* -> Mario gains star
U* -> Mario turns big
I* -> Mario turns fire
L* -> Mario takes damage
O* -> Mario is killed


*With debugmode

Supressions:

Suppressed CLS errors

Suppressed never used graphics as it is used for spritebatch

Suppressed warning saying that "the 'this' parameter of 'BlockSpriteFactory.CreateInvisibleBlock()'
is never used".
The InvisibleBlockSprite object is being used as a null object for when a hidden block or any other
block does not need to be drawn.x`

Suppressed Cyclomatic error for parser. Due to nature of the parser,
it will have many choices to branch to. Given the amount of objects,
items, etc. it will be unable to be reduced by any means.

Suppressed warning about changing method in interface to property if applicable. Not applicable in this instance.

Suppressed create IDisposable for mario state machine. If implmented would break all exisiting connections as it MarioState machine has to implement IDisposable
and then Mario has to implememt it, which he already is implementing something else. 

Suppressed error in obj of physics. They will be used but not at the moment.

Suppressed cyclomatic error in menu. There are many checks and different "states" to be handled to explictly
reduce it.