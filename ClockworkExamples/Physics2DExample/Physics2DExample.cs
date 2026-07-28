using Clockwork;
using Box2D;
using System.Numerics;
using Clockwork.Graphics.Draw2D;
using Clockwork.Graphics;
using System;
using Clockwork.Utilities;

// HughPH.Box2D is the recommended library for 2D physics.
// A physics engine my be built into Clockwork Engine in the future.

public class Physics2DExample : Game
{
	private World world;
	private Body groundBody;
	private Shape groundShape;
	private Body boxBody;
	private Shape boxShape;

	public Physics2DExample()
	{
		Core.LengthUnitsPerMeter = 128;
		WorldDef worldDef = new(gravity: new Vector2(0, 100f));
		world = new(worldDef);

		CreateBox(out groundBody, out groundShape, BodyType.Static, new Vector2(500, 650), 750, 25, 0f);
		CreateBox(out boxBody, out boxShape, BodyType.Dynamic, new Vector2(500, 100), 50, 50, Generate.Radians());
		boxShape.Restitution = 0.5f;
	}

	private void CreateBox(out Body body, out Shape shape, BodyType type, Vector2 position, float width, float height, float rotation)
	{
		BodyDef bodyDef = new(type: type, position: position, rotation: rotation);
		body = new(world, bodyDef);

		float halfWidth = width / 2f;
		float halfHeight = height / 2f;
		Polygon polygon = Polygon.MakeBox(halfWidth, halfHeight);

		ShapeDef shapeDef = new();
		shape = new Shape(body, shapeDef, polygon);
	}

	public override void OnUpdate()
	{
		world.Step(1f / 60f, 4);
	}

	public override void OnDraw()
	{
		Drawing.Clear(Colors.Black);
		DrawShape(groundShape, Colors.Blue);
		DrawShape(boxShape, Colors.Red);
	}

	public override void OnDrawGUI() { }

	private void DrawShape(Shape shape, Color color)
	{
		Vector2[] vertices = shape.WorldVertices.ToArray();
		Array.Reverse(vertices);
		Primitives2D.DrawTriangleFan(vertices, color);
	}
}
