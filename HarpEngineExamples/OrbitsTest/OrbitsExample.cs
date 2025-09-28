using HarpEngine;
using HarpEngine.Windowing;
using HarpEngine.Graphics;
using HarpEngine.Shapes;
using System.Numerics;

internal class OrbitsExample : Game
{
	Scene scene = new();

	public OrbitsExample()
	{
		Window.SetResizable(true);
		Window.SetRendererUnclipped(Colors.DarkGray);
		scene.Camera = new Camera2D(scene);

		CelestialBody sun = new(scene, 75, Colors.Orange);

		CelestialBody earth = new(scene, 25, Colors.SkyBlue);
		earth.Transform.Parent = sun.Transform;
		earth.Transform.LocalPosition = Vector2.UnitX * 250;

		CelestialBody moon = new(scene, 10, Colors.Gray);
		moon.Transform.Parent = earth.Transform;
		moon.Transform.LocalPosition = Vector2.UnitX * 100;
	}

	public override void Update()
	{
		scene.Update();
	}

	public override void Draw()
	{
		scene.Draw();
	}
}

internal class CelestialBody : Polygon
{
	private const int fontSize = 20;
	private Vector2 textOffset;

	public CelestialBody(Scene scene, float radius, Color color) : base(scene, radius, 6, color)
	{
		textOffset = new(Radius, -Radius);
	}

	public override void Update()
	{
		Transform.LocalRotation += 10 * Engine.FrameTime;
	}

	public override void Draw()
	{
		
		Text.Draw(Transform.WorldPosition.ToString("F0"), Transform.WorldPosition + textOffset, fontSize, Colors.White);

		base.Draw();
	}
}