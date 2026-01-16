using Clockwork;
using Clockwork.Windowing;
using Clockwork.Graphics;
using Clockwork.Shapes;
using System.Numerics;
using Clockwork.Graphics.Text;
using Clockwork.Graphics.Draw2D;

public class OrbitsExample : Game
{
	Scene scene = new();

	public OrbitsExample() : base("Orbits Example", 1000, 1000)
	{
		Window.SetResizable(true);
		WindowRenderer.SetUnclipped(Colors.DarkGray);
		scene.Camera = scene.AddEntity(new Camera2DEntity());

		CelestialBody sun = scene.AddEntity(new CelestialBody(75, Colors.Orange));

		CelestialBody earth = scene.AddEntity(new CelestialBody(25, Colors.SkyBlue));
		earth.Transform.Parent = sun.Transform;
		earth.Transform.LocalPosition = Vector2.UnitX * 250;

		CelestialBody moon = scene.AddEntity(new CelestialBody(10, Colors.Gray));
		moon.Transform.Parent = earth.Transform;
		moon.Transform.LocalPosition = Vector2.UnitX * 100;
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

internal class CelestialBody : PolygonShape
{
	private const int fontSize = 20;
	private Vector2 textOffset;

	public CelestialBody(float radius, Color color) : base(radius, 6, color)
	{
		textOffset = new(Radius, -Radius);
	}

	public override void OnUpdate()
	{
		Transform.LocalRotation += 10 * Engine.FrameTime;
	}

	public override void OnDraw()
	{
		Text.Draw(Transform.WorldPosition.ToString("F0"), Transform.WorldPosition + textOffset, fontSize, Colors.White);
		base.OnDraw();
	}
}