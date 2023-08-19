# MahmoudNasserTask18-8
Steps to run your project=> Project Is Created With Unity Version 2021.3.4f1 Only You will clone the project then import it and it will be running easily.

Instructions on how to navigate and play your game=>  When you run the game by only hit Play button game will start then when you press anyWhere game will start you controll the player with only ( A & D ) Buttons It will nagivate the player and move him left and right to collect the coins and if you love you will see the gameover panel if you want to restart the game just Click anyWhere in the screen and it will restart.



Information on how to access and play the game using a web browser after exporting it to WebGL=>  
By ONly build and run in unity on WebBrowser Setting it will be ready to  play it in a webserver and it will be localhosted





Optimization Methdology => "Object Pooling"
Object pooling is a design pattern that can provide performance optimization by reducing the processing power required of the CPU to run repetitive create and destroy calls. Instead, with object pooling, existing GameObjects can be reused over and over.The key function of object pooling is to create objects in advance and store them in a pool, rather than have them created and destroyed on demand. When an object is needed, it’s taken from the pool and used, and when no longer needed, it’s returned to the pool rather than being destroyed.Instead of creating and then destroying, the object pool pattern uses a set of initialized objects kept ready and waiting in a deactivated pool. The pattern then pre-instantiates all the objects needed at a specific moment before gameplay. The pool should be activated during an opportune time when the player won’t notice the stutter, such as during a loading screen.Once the GameObjects from the pool have been used, they’re deactivated and ready to use for when the game needs them again. When an object is needed, your application doesn’t need to instantiate it first. Instead, it can request it from the pool, activate and deactivate it, and then return it to the pool instead of destroying it.This pattern can reduce the cost of the heavy lifting needed from memory management to run garbage collection, as explained in the next section.To Sum Up The Object Pooling Is a Fast Method to Enable and disable Objects and Insantiate amout of Prefabs Limted Prefabs as we need and then we Activate and Deactivate objects By Instanite from This prefabs.

