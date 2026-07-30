using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Cameras;
using Clockwork.Shapes;
using System.Numerics;

// Hey, you! Listen!

// There is no shader example yet! This example is a WORK IN PROGRESS.

public class ShaderExample : Game
{
	private Scene scene = new();
	private Camera3D camera;

	public ShaderExample()
	{
		camera = scene.AddEntity(new Camera3D(new Vector3(0, 0, 3)));
		camera.InternalCamera.Target = Vector3.Zero;
		scene.Camera = camera;
		scene.AddEntity(new SphereShape(Vector3.Zero, 0.5f, Colors.White));
	}

	public override void OnUpdate()
	{
		scene.Update();
	}

	public override void OnDraw()
	{
		scene.Draw();
	}

	public override void OnDrawGUI()
	{
		scene.Draw();
	}
}
