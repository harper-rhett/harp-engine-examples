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
		// Start from the default world definition (it carries Box2D's tuned
		// defaults for contact stiffness, speed limits, etc.) and only change
		// gravity. Screen coordinates have +Y pointing down, so positive-Y
		// gravity makes bodies fall toward the bottom of the window.
		WorldDef worldDef = new();
		worldDef.Gravity = new Vector2(0, 980);
		world = new(worldDef);

		// Static ground: a wide platform near the bottom of the window.
		groundShape = CreateBox(BodyType.Static, new Vector2(500, 650), 400, 25);

		// Dynamic box: starts up high and falls onto the ground.
		fallingShape = CreateBox(BodyType.Dynamic, new Vector2(500, 100), 50, 50);
	}

	// Helper: creates a body with a single box shape and returns that shape.
	private Shape CreateBox(BodyType type, Vector2 position, float halfWidth, float halfHeight)
	{
		BodyDef bodyDef = new();
		bodyDef.Type = type;
		bodyDef.Position = position;
		Body body = new(world, bodyDef);

		Polygon polygon = Polygon.MakeBox(halfWidth, halfHeight);
		ShapeDef shapeDef = new();
		return new(body, shapeDef, polygon);
	}

	public override void OnUpdate()
	{
		// Advance the physics simulation by one fixed time step.
		world.Step(1f / 60f, 4);
	}

	public override void OnDraw()
	{
		Drawing.Clear(Colors.Navy);

		DrawShape(groundShape, Colors.Gray);
		DrawShape(fallingShape, Colors.Red);
	}

	// Box2D gives us the shape's corners in world space (already rotated and
	// translated). Its vertices are wound counter-clockwise in Box2D's Y-up
	// space, which is clockwise on the Y-down screen, so raylib would backface-
	// cull a triangle fan. Reversing the order makes the fill render.
	private void DrawShape(Shape shape, Color color)
	{
		Vector2[] vertices = shape.WorldVertices.ToArray();
		Array.Reverse(vertices);
		Primitives2D.DrawTriangleFan(vertices, color);
	}
}
