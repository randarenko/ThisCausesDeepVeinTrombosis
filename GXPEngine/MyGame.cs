using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;
using System.IO.Ports;

public class MyGame : Game
{
	RoadScroller rs;
	Player player;
	List<Car> cars = new List<Car>();
	SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
	int carSpawnTime = 0;
	public MyGame() : base(800, 600, false)		
	{
		rs = new RoadScroller(1);
		player = new Player();
		foreach (var item in rs.map)
		{
			AddChild(item);
		}
		sp.Open();
		AddChild(player);

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		rs.MoveRoad();
		rs.MoveRoad();
		sp.DiscardInBuffer();
		Console.WriteLine(sp.ReadLine());
		player.Move(sp.ReadLine());
		UpdateCars();
	}
	void UpdateCars()
	{
		
		if(Time.time > carSpawnTime)
		{
			Car car = new Car(Utils.Random(0.8f, 1f), Utils.Random(0,2));
			AddChild(car);
			cars.Add(car);
			carSpawnTime += Utils.Random(1500, 5000);
		}
		foreach (var car in cars)
		{
			car.Move();
		}
	}
	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();
	}
	
	
}