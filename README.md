# Time_Manipulation_based_FPS
This Project is meant to serve as a proof of concept and an attempt at creating a linear level based FPS in Unity. Core gameplay involves the popular : 'Time moves when you move' mechanic. 

Assets modelled using Blender :
1. Enemy/NPCs
2. Gun - common for both Player and Enemies
3. Bullets and casing

Greyboxing for level layout was done using pro-builder in Unity. Materials use the standard shader provided in Unity and texture packs were imported from Unity Asset store.
Animations for Enemy NPCs were downloaded from Mixamo and retargeted in Blender. Muzzle Flash, Muzzle smoke and bullet-enemy impact effects were created using Unity's default particle system, while bullet trails were created using trail renderer.

Since the target platform has moved between PC and Android over multiple iterations, optimal lighting settings for both platforms are :
1. PC : Mixed Lighting - static lightmaps + dynamic light sources
2. Android : Static Lightmaps (Consider lowering lightmap resolution if optimization required)
Post processing was only implemented in the PC version which includes effects such as bloom and color grading.

Few screenshots of gameplay :
## Initial testing :
![Screenshot 14](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Supercool_fps%20Screenshot%202019.12.22%20-%2000.01.52.59.png)
![Screenshot 15](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Supercool_fps%20Screenshot%202019.12.22%20-%2000.02.15.32.png)
![Screenshot 4](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(24).png)
![Screenshot 6](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(27).png)
![Screenshot 9](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(35).png)
## Completed PC level :
![Screenshot 1](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(1).png)
![Screenshot 8](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(3).png)
![Screenshot 11](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(4).png)
![Screenshot 13](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(7).png)
![Screenshot 2](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(20).png)
## Completed Android Level :
![Screenshot 3](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(22).png)
![Screenshot 5](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(26).png)
![Screenshot 7](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(28).png)
![Screenshot 10](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(39).png)
![Screenshot 12](https://github.com/SIDD017/Time_Manipulation_based_FPS/blob/master/Screenshots/Screenshot%20(45).png)

## NOTE
This is not a complete game. It's a test project that was meant to serve as a base to build upon. Subsequent levels were planned to provide more mechanics such as rewind, time dash and the popular bullet time for puzzles, traversal and combat. There is no optimization implemented in the form of LODs, mipmaps, etc
