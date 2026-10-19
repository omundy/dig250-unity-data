


# dig250-unity-data

A sample Unity project with:




## AdditiveSceneLoading

- Keep "global" scenes (game manager, UI) open while swapping "world" scenes in and out
- Press Play in any scene and the rest of the game loads automatically
- See the comments in [LoadSceneManager.cs](Assets/AdditiveSceneLoading/Scripts/LoadSceneManager.cs) and [AdditiveSceneManager.cs](Assets/AdditiveSceneLoading/Scripts/AdditiveSceneManager.cs)

<a href="_Screenshots/additive-scenes.png"><img width="500" src="_Screenshots/additive-scenes.png"></a>




## Data_Handling 

- Working with different C# data types (struct, class, dictionary, etc.)
- Working with external data (e.g. JSON)

<a href="_Screenshots/data-handling.png"><img width="500" src="_Screenshots/data-handling.png"></a>






## Event_Manager

- Example with additive scene loading  
- Notify other game objects across additive scenes about events using [EventManager](https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#)

<a href="_Screenshots/eventmanager.png"><img width="700" src="_Screenshots/eventmanager.png"></a>





## Object_Manager 

- Spawning new objects using Collider2D bounds
- Moving objects from an origin to a target
- Coroutine to Instantiate new objects

<a href="_Screenshots/object-manager.png"><img width="500" src="_Screenshots/object-manager.png"></a>




## ProgrammingPatterns/StrategyPattern

- Implementation of composition over inheritance using C# interfaces

<a href="_Screenshots/strategy-pattern.png"><img width="500" src="_Screenshots/strategy-pattern.png"></a>



## ScriptableObjects

- Uses Scriptable Objects (serialized data containers) to store details about random events that can happen in a game.
- See [Unity Manual: ScriptableObject](https://docs.unity3d.com/Manual/class-ScriptableObject.html) or [this reference sheet](https://github.com/omundy/dig250-game-art-dev/blob/main/reference-sheets/Unity-Scripting-Collections.md) for details

<a href="_Screenshots/scriptables.png"><img width="500" src="_Screenshots/scriptables.png"></a>



## UI Examples

- Different ways to add UI elements (anchor vs. pixel)
- How to use ray tracing to detect clicks on objects in 3D space
- Clicking, text changes, and data exchange between UI elements


<a href="_Screenshots/ui-example.png"><img width="500" src="_Screenshots/ui-example.png"></a>