GUIDE FOR CREATING OBJECTS IN SCENE

Notes for adding level geometry:
	- Make a child of the GameObject called "Level Geometry (Obstacles)"
	- Scale for each object should be (2, 2, 1)
	- Add a Polygon collider
		- When setting collider points ignore flowers
		- Keep the collider outline as close to the sprite as possible (helps with the spotlight appearance)
	- Add a Rigidbody2D and set body type to "Kinematic"
		  
Notes for enemies:
	- Make a child of the GameObject called "Enemies"
	- Should have a NEW_InheritScrollScript component so that it scroll upward while offscreen
	- Add a LungingEnemyScript for eel or an AI_BounceScript for others
		- See existing enemies for reference
		- Easiest method is to duplicate existing enemies and change settings where needed
	- NEW_InheritScrollScript needs to be checked on and AI script should be checked off before starting game

Notes for middleground objects:
	- Make a child of the GameObject called "Middleground (Non-collidable)"
	- Make sure to set layer to "Non-collidable"
	- Scale should be larger than actual obstacles (ie a scale of (4, 4, 1)
		- If you want to flip the object horizontally or vertically use scale (ie to flip horizontally
			set scale to (-4, 4, 1))
	- Should also have Rigidbody2D set to Kinematic
	- For best visual effect set sprite color to grey (as opposed to default white)

Notes for Radar:
	- To get an object to appear on the radar first give it a child component
	- Set the layer of this child to "RadarViewable"
	- Add a sprite to the child
		- For enemies just use a square roughly the same size as the enemy
		- For obstacles use the same sprite as the parent object
	- Set the color of the child sprite to white [RGBA(1,1,1,1)]
	- Set the material on the child's Sprite Renderer to any of the Radar Materials (ie RadarObstacleMaterial)