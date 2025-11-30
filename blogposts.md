# VR1 -> Catarina -Storyline, Setup of the project and introduction 

For this project, we focused on an Indiana Jones inspired escape room. Firstly, the player is presented with a short introduction to give the context. 
The introduction also serves as a transition moment for the player to adapt to the transition into the VR game. In the beginning, the player spawns in the middle of a temple and 
is prompted to solve enigmas throughout the experience to try to escape. 

The project was created with the VR core template. To create the three existent scenes, the sample scene was duplicated and then adapted the GameObjects present to each one of the 
scene’s needs. 

For the construction of the environment on all the scenes, it is composed of a plane, four walls and 4 columns, all prefabs of the correspondent GameObjects. For all of them, base 
assets to build materials were imported (sources bellow). For each type of structure, there was a material created to be able to insert the assets imported into the actual game. The 
purplish color tones were put in the Normal color slot, the beiger tones in the Base color slot and the actual texture on the “Metallic map”. All the GameObjects that are part of the 
core structure of the temple have a box collider so that the player does not go through them. 

All the scenes have the same existent component XR Origin (VR), which is the component responsible for the main setup of the player and the way the player can interact with the environment
around. To configure some of the embodiments of the player inside the game, the character controller component in the XR Origin was adapted to set the player to a reasonable height and 
radius to set. 


## Introduction scene 

Regarding the introduction scene, the main focus is on the following: the UI, with contains two canvas (one for the black background and the other for the text) and the IntroSceneManager 
class, to manage the UI transitions and the transition into the main scene. 
 

In the IntroSceneManagerController.cs there are two private variables: the introduction UI panel from the type CanvasGroup and a fadeDuration variable of type float. Both of these variables 
are private as it is good practice, but both are Serialized fields as to be reached from the Unity Editor. Lastly there is also an Image object, which is there to hold the black background 
for the transition in the introduction. 

 
In the Start() method, the coroutine is started with the StartIntro() method and the introPanel UI set to false. 

In this script, the highlight is on the StartIntro() method, which is from type IEnumerator, as coroutines were used to make the introduction possible. IEnumerator methods are the ones 
mostly used when dealing with coroutines as they are iterators that go through the set path of events. In this method, we take the color of the fadeImage variable and set it to value 1 
alpha, which means it will be completely visible and then it sets it as the new background color. In order to trigger steps only after a certain amount of time or a specific event, yield 
is the keyword used. In the StartIntro() method, there is a moment of wait before starting another coroutine, Fade(), which is used to smoothen the transition into the introduction text and
then into the next scene. Finally in the StartIntro() function, the UI panel’s alpha is set to true, yield is used again to hold the sequence for a couple of seconds and the next scene is 
loaded. 

Regarding the Fade() method, it is a method as mentioned above to smoothen the introduction’s transitions. This was a method important to include due to the players possible bad reaction 
to fast transitions and color environment changes when wearing the VR glasses, as those factors may cause for example discomfort and dizziness. In this method, In order to control the fade 
between the sequence’s steps, firstly we get the current transparency and set a time variable to zero. Following there is a while loop so that while the time spent is lower than the time 
set for the duration of the fade, the transparency values can transition smoothly from 1 to 0 using the Mathf.Lerp . Finally the transparency is set to the maximum when the time spent equals
the time set for the transition.  




# VR2 -> Catarina- The main scene 

Right after being spawned into the scene, the player is presented with the first clue. The player should then find a key, situated on the altar with all the drawings and use the key to open
a music box that is on top of a piece of furniture. Only after collecting the key the music box opens and reveals a short video with a small melody, which is the second clue. 

To perform all these steps, there is the following logic behind: 
 

## Key 

For the key functionality, we have a KeyHandler class where we have a KeyCollectedUI CanvasGroup and a bool static variable to check if the player has the key, which is privately set in 
this class, but can be accessed by other classes.  

In the Start () method the KeyCollectedUI is set to not be active after checking if it exists. 

Next there is a method called TryCollectKey() where it checks if the player has collected the key already. If not then it sets the variable KeyCollected as true and starts the 
HandleKeyCollectionSequence coroutine. 

The HandleKeyCollectionSequence() method is responsible for activating the KeyCollectedUI, waiting for a couple of seconds and deactivating it, so that the player can be notified of 
the collection of the key, which is destroyed at the end of this sequence, to avoid further confused for the player. 

Regarding the Unity Editor, the key was set on the scene with a quad as it is easier to manage its position than another plane, and the image of the key itself was converted into a material
by inserting the raw image in the Base map slot and the surfice type made transparent, just like the materials for the floor and walls. The material was applied to the quad and the tiling 
was adjusted to make the proportions appear more realistic. The KeyHandler script was attached to the key object and the pertinent GameObject variables of the script assigned. 

 

## Music Box 

In order to open the music box, in the KeyHandler class the variable bool hasKey was set to public static so that in the MusicHandler class we could use that information to reveal or not 
the next clue. 

In this class we have two different UI’s, one to display a message if the music box is opened and another to display a message if the box is locked. There is also a variable for the music 
box video and the hasKey variable from type KeyHandler. 

In the Start() function, all the variables but hasKey are set to false or deactivated, and the audio for the music video is fetched and stopped. 

Then there is a function called when the user attempts to open the music box where all coroutines are stopped and the OpenMusicBox coroutine is started. 

In this OpenMusicBox method, it checks if the player has the key and if so activates the UI correspondent and plays the audio and video. If the player does not have a key, then it activates
the musicBoxLockedUI. 

 

## Music Cubes 

Using the melody from the music box, the player should then reproduce the sequence with the music cubes also in the altar. After the sequence is performed, another clue hints at the final
tragedy and the user is redirected to the ending scene. 

To make sure that the functionality of the music cubes worked, there are two classes, one to control the music cubes, and another one to manage them.  

In the MusicCubeController class, there are four variables: a variable note of string type to hold the id of the note played, a variable to hold the audio source, a variable to hold the 
actual music clip and a manager of type MusicCubeManager. 

The first function is an Awake() function, where we initialize the manager and fetch the audio source component that is linked through the unity editor. Following that we have a function 
dedicated to the functionality regarding the cube actually being selected called OnCubeSelected() where the private functions PlayNote() and SendToManager() are called. These last two are 
set private as there only needs to be one public exposition (the OnCubeSelected method) since the functions mentioned are how the cubes function internally. Still regading the last two 
functions, PlayNote() checks if the audio clip and audio source exist, attaches the clip to the audio source and plays it. For the SendNoteToManager class, it checks if the manager is null 
and then uses the manager variable to access a method called AddNoteToMelody to register which note was played. 

Regarding the MusicCubeManager class, we have 2 lists both type string (one to hold the correct melody and the other one to hold the played melody), two Canvas to hold the right sequence 
and wrong sequence UI and a private float variable to hold the display time for the wrong sequence UI. 

In the Start(), the correct melody is initialized to a specific sequence, the playedMelody list is also instantiated and both the UI gameobjects are set to false. 

Following there are three methods that make up the manager’s functionality: AddNoteToMelody method, where the notes are added to the played melody list and CheckMelody method is invoked, 
CheckMelody method, that waits for all the notes to be played, checks if the played melody matches with the correct melody and if so it sets the right sequence UI to active and the wrong 
sequence UI to not be active and invokes the NextScene method- if not then its sets activates the wrong sequence UI and deactivates the other UI and first stops the HideWrongSequence 
coroutine, just to start the same coroutine the next line . Finally, we have HideWrongSequence method, which waits for the time set for the wrongSequenceDisplayTime variable, and 
deactivates the wrongSequence gameObject. 

The last method in this class is the NextScene method that uses the scene manager to load the ending scene. 

 

 

# VR3 -> Catarina and Lyubomir- Ending scene, problems faced and final touches 

 
## The Ending scene 

The third scene is the Ending scene, which is the is where the player discovers the end of the game- a mummy attack, as there was no possible escape in the first place. This ending was 
created with a twist to the original classic storyline of escape rooms as the intention was to catch the player off-guard and offer a surprising ending. 

In the OutroSceneManager, there are three UI’s (one for the ending message, one for the mummy image and one for the cliff hanger), two audio sources for the mummy jumpscare and three 
float variables to define timing regarding this three steps. 

In the Start function, Only the professor UI is set to full visiblity while the other panels are set to be invisible. The PlaySequence coroutine is started. 

In the PlaySequence() method, yield is used for waiting a couple of seconds before playing the footsteps audio, and then again before the jumpscare audio is played. There is a while loop 
that uses again the Mathf.Lerp function to fade the visibility of the mummy panel before yield is used again, as to introduce the fade in of the outro panel. Lastly there is a RestartScene()
method for the functionality of the restart button. 

The Ending scene was made very similar to the Introduction scene, as both of them are build with the same goal of showing transition of UI panels, with the exception this scene also includes
a restart button. The functionality for this button was implemented with an OnCollisionEnter() method that triggers another method called RestartScene() in which the SceneManager loads the 
introduction scene. The script for this functionality, also like in the introduction scene, is attached to an empty GameObject in the unity editor. 

 

## Problems faced 

Throughout the development of this game, there were a couple of problems that presented themselves as a challenge. The first major problem were merging conflicts. The GitHub repository for 
this game was build on the following architecture: Each branch concerns a step of the game. Every pull request is merged to sandbox and then from sandbox to main. This had the goal of 
preventing the merge of faulty code. The problems lied on the fact that several parts of the game were developed simultaneously and had commits to sandbox, and therefore there were conflicts
on the scenes themselves. This made merging everything together almost impossible, losing some progress when the merge was finally successful as not every piece of code could persist, in 
risk of clashing with some other change. For this merge, the following merging tool was used: 
 

Broken assets was one of the problems faced. In the TMP packages, two of the assets were broken, which was portraited by Unity by making the assets hot pink. A lot of fixes were tried, 
including reinstalling the TMP packages and the extras. The winning solution was to just move permanently the files somewhere else. Thankfully only one of the group members faced this issue. 
 
The last big issue faced was understanding how to set up XR device simulator as duplicate hidden functionality in the scripts and created GameObjects, e.g. locomotion, made it impossible 
for the simulator to run properly. 

 
## Additions 

Because it is a VR project, giving the player an immersive feeling is also a core part of the experience. To be help contribute to the realism of the environment some GameObjects were added 
to the scenes, such as torches. 

 
