using System;				
using GXPEngine;
using System.Drawing;                  
using System.Collections.Generic;
using System.IO.Ports;

public class MyGame : Game
{
	RoadScroller raceScroller;
	CarSpawner carSpawner;
	Player player;
	SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
	public MyGame() : base(800, 600, false)		
	{
		EventSystem es = new EventSystem();
		raceScroller = new RoadScroller(1);
		carSpawner = new CarSpawner();
		player = new Player();
		AddChild(player);
		AddChild(raceScroller);
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