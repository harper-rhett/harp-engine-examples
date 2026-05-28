using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw2D;
using Clockwork.Graphics.Text;
using Clockwork.Input;
using Clockwork.Utilities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

public class QuadtreeExample : Game
{
	private Quadtree<Vector2> quadtree;
	private int examples = 1000;
	private float searchRadius;

	private Vector2 mousePosition;
	private List<Vector2> points = new();

	public QuadtreeExample()
	{
		quadtree = new(Vector2.Zero, Engine.GameWidth);
		foreach (int example in Enumerable.Range(0, examples))
		{
			Vector2 position = Generate.Vector2(0, 0, Engine.GameWidth, Engine.GameHeight);
			points.Add(position);
			quadtree.Add(position, position);
		}
		searchRadius = Engine.GameWidth / 8f;
	}

	public override void OnUpdate()
	{
		mousePosition = Mouse.GamePosition;
	}

	public override void OnDraw()
	{
		Drawing.Clear(Colors.Black);

		Primitives2D.DrawCircle(mousePosition, 2, Colors.Blue);
		Primitives2D.DrawCircleLines(mousePosition, searchRadius, 2, Colors.Blue);

		List<Rectangle> intersectingBounds = quadtree.GetBoundsIntersectingRadius(mousePosition, searchRadius);
		List<Vector2> intersectingPoints = quadtree.GetItemsInRadius(mousePosition, searchRadius);

		quadtree.DrawBounds(2, Colors.Green);
		foreach (Rectangle bounds in intersectingBounds) Primitives2D.DrawRectangleLines(bounds, 1, Colors.Orange);
		foreach (Vector2 point in points) Primitives2D.DrawCircle(point, 2, Colors.White);
		foreach (Vector2 point in intersectingPoints) Primitives2D.DrawCircleLines(point, 4, 1, Colors.Red);
	}
}
