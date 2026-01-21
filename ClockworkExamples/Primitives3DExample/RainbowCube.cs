using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw3D;
using System.Numerics;

public class RainbowCube : Entity
{
	public Vector3 Position;
	private Gradient gradient = new(Colors.Red, Colors.Yellow, Colors.Lime, Colors.Blue, Colors.Red);
	private const float rainbowSeconds = 5f;

	public RainbowCube(Vector3 position)
	{
		Position = position;
	}

	public override void OnUpdate()
	{
		
	}

	public override void OnDraw()
	{
		float interpolation = (Scene.Time % rainbowSeconds) / rainbowSeconds;
		Color color = gradient.Sample(interpolation);
		Primitives3D.DrawCube(Position, 0.5f, color);
	}
}
