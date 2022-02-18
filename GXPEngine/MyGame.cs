using System;				
using GXPEngine;
using System.Drawing;                  
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

public class MyGame : Game
{
	ChunkController chunkController;
	RoadScroller raceScroller;
	Player player;
	PoliceCar policeCar;
	SpeedController speedController;
	EasyDraw highscore;
	public MyGame() : base(1366, 768, false)		
	{
		StartGame();
	}
	void StartGame()
	{
		EventSystem es = new EventSystem();
		chunkController = new ChunkController();
		raceScroller = new RoadScroller(2);
		player = new Player();
		policeCar = new PoliceCar();
		speedController = new SpeedController();
		highscore = new EasyDraw(300, 150);

		

		AddChild(raceScroller);
		AddChild(chunkController);
		AddChild(player);
		AddChild(policeCar);
		AddChild(highscore);

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		EventSystem.current.Update();
		if (Input.GetKeyDown(Key.A))
		{
			//EventSystem.current.MagnetPickedUp(Time.time, 5000);
		}
		RemoveChild(highscore);
		highscore.Clear(0,0,0);
		highscore.SetXY(0, 00);
		highscore.TextAlign(CenterMode.Center, CenterMode.Center);
		highscore.Fill(255, 255, 255, 255);
		highscore.Text(EventSystem.score.ToString());
		AddChild(highscore);
		if (EventSystem.lives == 0)
		{
			RemoveChild(raceScroller);
			RemoveChild(player);
			RemoveChild(policeCar);
			RemoveChild(chunkController);
			EasyDraw ed = new EasyDraw(300, 150);
			ed.SetOrigin(150, 75);
			ed.Fill(255, 255, 255);
			ed.SetXY(1366 / 2, 768 / 2);
			ed.TextAlign(CenterMode.Center, CenterMode.Center);
			ed.Text("GameOver \n Score: ");
			AddChild(ed);
		}
	}
	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();
	}
	
	
}