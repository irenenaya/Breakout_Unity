# Breakout - Unity

A Breakout implementation in Unity, based on Colton Ogden's Introduction to Game Development course's Lua/Löve2D version.

After reading about the use of AnimatorController state machines as a general purpose state machine in Unity AI Game Programming, Second Edition by Ray Barrera, Aung Sithu Kyaw, Clifford Peters and Thet Naing Swe we decided to try out the concept and used it to control the game states.

While we do use Unity's 2D physics we also manipulate the ball's bouncing angle a bit to add some randomness to the game.

We also added a class to manipulate the sound when pausing/unpausing the game or when entering some "cheat codes" :)

# Usage
- clone the repository
- open it in Unity (tested with 2017.x versions)
- to play in the Unity Editor load _Scenes/PersistentScene

# TODO / Known Bugs
- A warning of "Unloading the last loaded scene Assets/_Scenes/PersistentScene.unity(build index: 0), is not supported. Please use SceneManager.LoadScene()/EditorSceneManager.OpenScene() to switch to another scene." is reported when SceneController attempts to unload the persistent scene. This doesn't crash the game but we should see if there's an elegant-ish fix to this.
- Add sound controls to lower the volume. Currently the only way to silence the music is to hit tab while in game play and type "shutup" without the quotation marks. Other "cheats", all sound related, are tab "jolene" or tab "dollyparton", tab "runtothehills", tab "shout", tab "slowride". Check out the CheatMachine object in the persistent scene.
- Balls will bounce off each other when there's more than one ball in play. This often causes one of the balls to slow down a lot and the other to speed up. Think of how we want to treat this.

# Pseudorandom quote
"I tried so hard and got so far, But in the end it doesn't even matter" - Linkin Park
