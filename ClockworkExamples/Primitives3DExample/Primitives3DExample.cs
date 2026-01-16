using Clockwork;
using Clockwork.Graphics.Draw3D;
using Clockwork.Graphics;
using System.Numerics;

public class Primitives3DExample : Game
{
	private Camera3DEntity Camera;
	private Scene scene = new();

	public Primitives3DExample() : base("Primitives 3D Example", 1920, 1080)
	{
		Camera = scene.AddEntity(new Camera3DEntity());
		scene.Camera = Camera;
	}

	public override void OnUpdate()
	{
		
	}

	public override void OnDraw()
	{
		Primitives3D.DrawSphere(new Vector3(0, 0, 3), 1, Colors.Crimson);
	}
}
