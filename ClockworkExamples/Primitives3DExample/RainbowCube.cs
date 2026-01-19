using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw3D;
using System.Numerics;

public class RainbowCube : Entity
{
	public Vector3 Position;

	public RainbowCube(Vector3 position)
	{
		Position = position;
	}

	public override void OnDraw()
	{
		Primitives3D.DrawCube(Position, 0.5f, Colors.HotPink);
	}
}
