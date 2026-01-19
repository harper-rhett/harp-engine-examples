using Clockwork;
using Clockwork.Graphics.Draw3D;
using Clockwork.Graphics;
using System.Numerics;
using Clockwork.Utilities;

public class Primitives3DExample : Game
{
	private Camera3DEntity Camera;
	private Scene scene = new();
	private const int cubeCount = 100;
	private const int maxDistance = 15;

	public Primitives3DExample() : base("Primitives 3D Example", 1920, 1080)
	{
		//Camera = scene.AddEntity();
		scene.Camera = new Camera3DEntity();

		for (int cubeIndex = 0; cubeIndex < cubeCount; cubeIndex++)
		{
			Vector3 cubePosition = Generate.UnitVector3() * Generate.Float(maxDistance);
			scene.AddEntity(new RainbowCube(cubePosition));
		}
	}

	public override void OnUpdate()
	{
		scene.Update();
	}

	public override void OnDraw()
	{
		scene.Draw();
	}
}
