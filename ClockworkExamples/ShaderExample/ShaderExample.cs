using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw3D;
using Clockwork.Shapes;
using Clockwork.Utilities;
using System.Numerics;

public class ShaderExample : Game
{
	private Scene scene = new();
	private Camera3D camera;

	public ShaderExample() : base("Shader Example", 500, 500)
	{
		camera = scene.AddEntity(new Camera3D(new Vector3(0, 0, 3)));
		camera.InternalCamera.Target = Vector3.Zero;
		scene.Camera = camera;
		scene.AddEntity(new SphereShape(Vector3.Zero, 0.5f));
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
