using Clockwork;
using Box2D;
using System.Numerics;
using Clockwork.Graphics.Draw2D;
using Clockwork.Graphics;

public class Physics2DExample : Game
{
	private World world;
	private Shape groundShape;
	private Shape fallingShape;

	public Physics2DExample()
	{
		WorldDef worldDef = new();
		worldDef.Gravity = new Vector2(0, 980);
		world = new(worldDef);

		groundShape = CreateBox(BodyType.Static, new Vector2(500, 650), 750, 25);
		fallingShape = CreateBox(BodyType.Dynamic, new Vector2(500, 100), 50, 50);
	}

	private Shape CreateBox(BodyType type, Vector2 position, float width, float height)
	{
		BodyDef bodyDef = new();
		bodyDef.Type = type;
		bodyDef.Position = position;
		Body body = new(world, bodyDef);

		Polygon polygon = Polygon.MakeBox(width / 2f, height / 2f);
		ShapeDef shapeDef = new();
		return new(body, shapeDef, polygon);
	}

	public override void OnUpdate()
	{
		world.Step(1f / 60f, 4);
	}

	public override void OnDraw()
	{
		Drawing.Clear(Colors.Black);

		DrawShape(groundShape, Colors.Blue);
		DrawShape(fallingShape, Colors.Red);
	}

	private void DrawShape(Shape shape, Color color)
	{
		Vector2[] vertices = shape.WorldVertices.ToArray();
		Array.Reverse(vertices);
		Primitives2D.DrawTriangleFan(vertices, color);
	}
}
