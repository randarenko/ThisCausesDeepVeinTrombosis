using System;				
using GXPEngine;
using System.Drawing;                  
using System.Collections.Generic;
using System.IO.Ports;

public class MyGame : Game
{
	public MyGame() : base(1366, 768, false)		
	{
		// menu = new Menu();	
		//AddChild(menu);
		Level level = new Level();
		AddChild(level);
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		Console.WriteLine(Player.current.y);
		Console.WriteLine(Player.current.x);

	}
	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();
	}
	
	
}