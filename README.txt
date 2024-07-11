TODO:
Change the Fish to it's own class
Add all fish data into a json file on firebase

Instructions:

Open the MainScene .. looks best at 1280 x 800 but looks good at all resolutions I tested.
Used unity version 2022.3.5f1

Start Menu:
Click the yellow Circle I button next to any Mode Button for Information on that Mode
Click on the red circle X button to close the Info Window
Click on the Easy, Medium, Hard buttons to start the Game

Game Play:
Use the left and right buttons to move the net to catch the fish
Minnows are worth 10 points
Bream are worth 20 points
Bass are worth 20 points
Snakes are worth -25 points
Hooks will make the net unmovable for 3 seconds

Once Timer has reach zero the end game screen will automatically display

End Game Menu
Click the yellow Circle I button next to any Mode Button for Information on that Mode
Click on the red circle X button to close the Info Window
Click on the Easy, Medium, Hard buttons to start the Game

NOTES:  
I assumed this was for a prototype.  Also assumed there was no need for addressables, JSON files, multiple scenes, sprite sheets, etc due to the size of the game.
Due to time limit there is not optimization of code nor design.
I did assume you would want the ability to give a designer the ability to tweak all the variables such as: spawn rate, spawn chance, objects speed, score, etc .. which is why the variables are arrays in the game data.  
A simple Firebase Bucket was created for the "Fish" Images. Which can be changed and added for the data as well with some reworking of classes and structure. (Once again, prototype with limited time)

Edge case is even commented in the code.  Possible Edge Case, if Lowest Chance is not in the following order:  Bass, Snake, Hook, Bream, Minnow
To solve, copy array into another array and sort, then do the checking based on that array / indexes.  

If I had more time:
Add an arcade mode that the fish would run away if hit by a moving trigger close to the net.
Add if bigger fish eats smaller fish they are worth more points than both.  
Add animations instead of a lerp for the movement.  
Sprite animations would have been amazing as well. 
 
Things to do to make some of those changes:
A. Sett up the vars as a JSON file so you wouldn't have to update the game.  
B. Have it setup for animations for the movement already, so scaling would be easier.
C. Arcade Mode
Give a rough outline of how you might implement these ideas. 
A.  JSON files load from local instead of array.  A little more time consuming but then would have been easy to setup to load off a CDN
B.  Play an unity animation instead of a lerp.  Add a check if left or right side so can randomly play the right or left side animation to give more creativity for the fish movement.  
C. In Arcade mode add power ups, fish run away, fish swimming in circles, etc



