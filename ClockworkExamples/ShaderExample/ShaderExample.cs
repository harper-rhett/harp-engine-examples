using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw3D;
using System.Numerics;

public class ShaderExample : Game
{
	private Scene scene = new();

	public ShaderExample() : base("Shader Example", 500, 500)
	{
		Camera3D camera = scene.AddEntity(new Camera3D(new Vector3(1, 1, 1)));
		camera.Transform.WorldPosition = new(0, 0, -2);
		scene.AddEntity(new DisplayMesh(Mesh.GenerateSphere(0.5f, 12, 12), Vector3.Zero));
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
