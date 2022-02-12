using System;				
using GXPEngine;
using System.Drawing;                  
using System.Collections.Generic;
using System.IO.Ports;

public class MyGame : Game
{
	ChunkController chunkController;
	RoadScroller raceScroller;
	CarSpawner carSpawner;
	Player player;
	public MyGame() : base(1366, 768, false)		
	{
		EventSystem es = new EventSystem();
		chunkController = new ChunkController();
		raceScroller = new RoadScroller(2);
		carSpawner = new CarSpawner();
		player = new Player();
		AddChild(raceScroller);
		AddChild(chunkController);
		AddChild(player);

		AddChild(carSpawner);

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		EventSystem.current.Update();
	}
	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();
	}
	
	
}