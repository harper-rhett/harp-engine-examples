using Clockwork;
using System.Numerics;
using Clockwork.Utilities;
using Clockwork.Windowing;
using Clockwork.Graphics.Cameras;

public class Primitives3DExample : Game
{
	private Camera3D Camera;
	private Scene scene = new();
	private const int cubeCount = 150;
	private const float minDistance = 5;
	private const float maxDistance = 15;

	public Primitives3DExample()
	{
		Window.SetResizable(true);
		WindowRenderer.SetClipped();
		Camera = scene.AddEntity(new FreeCamera3D(Vector3.Zero));
		scene.Camera = Camera;

		for (int cubeIndex = 0; cubeIndex < cubeCount; cubeIndex++)
		{
			Vector3 cubePosition = Generate.UnitVector3() * Generate.Float(minDistance, maxDistance);
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
