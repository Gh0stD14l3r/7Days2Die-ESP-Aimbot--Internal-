7 Days 2 Die - C# DLL Source [Base]

Note: This mod works with Wemod loaded aswell.
This is a basic mod menu created in C#. It is a base which you can add your own items to it or modifications. Currently it has the following.

 - ESP (Animals, Zombies/Enemies, Players, Dropped Items)
 - Bone ESP for enemies only.
 - Press Numpad 1 to enable Creative Menu (Works in online servers also)
 - Aimbot (Select for Enemies, Players or Animals)
 Note: For Aimbot, just equip any rifle, pistol, smg, shotgun and right click (ADS) and move towards the enemy. It will snap to their head
 
To improve performance, Threading was added to the code. This was causing a memory access violation which would kill the game after about 20-30 seconds. The code will remain the same as the older process for reliability. There will be short lag spikes now and then.
 
Insert Key - Show/Hide Menu End Key - Unload DLL File safely

To compile..

    Download & Open Sln file for Visual Studio
    Compile in Debug or Release (Doesn't matter)

To Inject..

    Use a Mono injector (Possibly MonoSharpInjector)
    Select Process and browse to the assembly to inject (Game_7D2D.dll)
    Use the following settings.. -- Namespace: Game_7D2D -- Class name: Loader -- Method name: init
    Press inject


![image](https://user-images.githubusercontent.com/38970826/180594355-e194b91e-ef4b-4c8c-896a-457d524f05fc.png)


![image](https://user-images.githubusercontent.com/38970826/180594413-3e7502c3-58b7-4989-a600-cadca337c042.png)

