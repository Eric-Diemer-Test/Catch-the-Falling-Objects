Instructions:

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

Questions:
Describe any important assumptions that you have made in your code.
First I assumed this was more of a prototype.  Also assumed there was not need for addressables, json files, multiple scenes, sprite sheets, etc due to the size of the overall game
I did however assume would want to give to a designer to tweak all the variables such as: spawn rate, spawn chance, objects speed, score, etc .. which is why they are arrays in the game manager.  

What edge cases have you considered in your code? What edge cases have you yet to handle?
The biggest one is even noted in the code.  Possible Edge Case if Lowest Chance is not the following:  Bass, Snake, Hook, Bream, Minnow

What are some things you would like to do if you had more time? 
Like to have added an arcade mode that the fish would run away if hit a moving trigger close to the net.
Also like to added if bigger fish eats smaller fish they are worth more points than both.  
Would love to add animations instead of a lerp for the movement.  To slow on creating animations
Sprite animations would have been amazing as well, however I am an horrible artist if you can't tell. 
 
Is there anything you would have to change about the design of your current code to do these things? 
A. Would of liked to have set up the vars as a json file so wouldn't have to update the game.  
B. Would of liked to have it setup for animations for the movement already so scaling would be easier.
Give a rough outline of how you might implement these ideas. 
A.  Have the json files loaded from local files instead of array.  A little more time consuming but then would have been easy to setup to load off a cdn
B.  Have it play an unity animation instead of a lerp.  Also add a check if left or right side so can randomly play the right or left side animation to give more creativity for the fish movement.  
Project Title: Unity Mini-Game - "Catch the Falling Objects"

Assignment:
Objective:
The objective of this assignment is to create a 2D game where the player controls a character at the bottom of the screen and attempts to catch falling objects. Please refer to the attached project description for detailed requirements.

Project Description:
Please take note of the following key features:

Gameplay Mechanics:
The player controls a character (e.g., a basket, a catcher's mitt) at the bottom of the screen using keyboard input (left and right arrow keys).
Objects should fall from the top of the screen at random intervals.
The player earns points for successfully catching objects.
The game should have a time limit (e.g., 60 seconds).

Objects:
At least three different types of objects should fall (e.g., fruits, shapes, etc.).
Each type of object should have a different point value.

UI:
 Display the player's score.
 Display the time remaining.

End Conditions:
 When the time runs out, display the final score.
 Allow the player to restart the game.

Graphics and Audio:
Use simple 2D graphics for the objects and background.
Add basic sound effects (e.g., object catching sound).

Additional Considerations:
  Ensure the code is well-organized and commented for clarity.
  Use appropriate collision detection techniques.
  Optimize the project for performance.

Deliverables:
The Unity project folder containing all necessary assets and scripts. 
A short documentation file (.pdf or .txt) explaining how to play the game and any additional features you added.

Submission Instructions:
Kindly provide a link to your version-controlled repository (e.g., GitHub) containing the Unity project. Additionally, include the documentation file.

Evaluation Criteria:
Your project will be assessed based on the following criteria:

Functional completeness of the game.
Code quality, including organization, readability, and use of best practices.
Creativity and attention to detail in design and gameplay.
Adherence to the specified requirements.
Readme File Questions:
In your GitHub repository, please include a Readme file addressing the following questions:

Describe any important assumptions that you have made in your code.
What edge cases have you considered in your code? What edge cases have you yet to handle?
What are some things you would like to do if you had more time? Is there anything you would have to change about the design of your current code to do these things? Give a rough outline of how you might implement these ideas.

