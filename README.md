# Chrome Dino Game

## Instructions

### 1 - Clone the repo to your computer
1. After the first batch of students, you can skip this step.

### 2 - Duplicate the "Chrome-Dino-Game" folder
1. This will allow you to retain an original so you do not have to keep cloning or reverting your steps.

### 3 - Changing the Gravity
1. On line 24 is the gravity setting. By default it is set to 0.4. 
2. Try setting it to 2. Then set it to -0.4.
3. Play with the setting and see what makes it the most favorable for you. 

### 4 - Changing the Speed
1. On line 22 is the speed setting. By default it is set ot 6.
2. Try setting it to 1. Then set it to 10.
3. Play with the setting and see what makes it the most favorable for you.
4. On line 23 is the speed increment setting. By default it is set to 0.003.
5. Try setting it to 0.1. Then set it to 2.
6. Play with both settings and see what makes it the most favorable to you.
7. Combine with gravity settings.

### 5 - Changing the Score
1. Score incrementing is on lines 209 and 217. By default they are set to 1.
2. Change the number so that the score goes up by 10, 5, or 200,000 each time the dino jumps a cactus or ducks a bird.
3. Change line 201 from just "{" to "totalScore = totalScore + 1;" and then try changing the value for more points.
4. Experament with these settings to see what is most favorable for you.
5. Combine with gravity settings and speed settings for more fun.

### 6 - Changing the Keybindings
1. Change line 79 from "if ((e.KeyCode == Keys.Up) && dino.Location.Y >= dinoLowLocation)"
2. Add before the "&&" the following: " || (e.KeyCode == Keys.Space)" 
3. This will allow the space key to be used instead of or in addition to up.

### 7 - Explore
1. Encourage students to explore combinations of changes from the last few steps.
2. Make the game impossible or really easy.
3. Go crazy with changes to the point of breaking the game.

### 8 - Delete the copied "Chrome-Dino-Game" folder
1. When the session ends, send the student on their way and thank them for coming to our class.
2. Delete the copied "Chrome-Dino-Game" folder that you made with this student.
3. Prepare for the next student by starting over at step 2.

