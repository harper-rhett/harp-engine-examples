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
	private float searchRadiusSquared;

	private Vector2 mousePosition;
	private List<Vector2> points = new();
	private Queue<float> quadtreeMilliseconds = new();
	private Queue<float> traditionalMilliseconds = new();
	private const int queueSize = 2500;
	private List<Vector2> quadtreePoints = new();
	private List<Vector2> traditionalPoints = new();

	public QuadtreeExample()
	{
		quadtree = new(Vector2.Zero, Engine.GameWidth, 1f);
		foreach (int example in Enumerable.Range(0, examples))
		{
			Vector2 position = Generate.Vector2(0, 0, Engine.GameWidth, Engine.GameHeight);
			points.Add(position);
			quadtree.Add(position, position);
		}
		searchRadius = Engine.GameWidth / 8f;
		searchRadiusSquared = searchRadius * searchRadius;
	}

	public override void OnUpdate()
	{
		mousePosition = Mouse.GamePosition;
		UpdateQuadtree();
		UpdateTraditional();
	}

	private void UpdateQuadtree()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		foreach (Vector2 point in points)
		{
			quadtreePoints.Clear();
			quadtree.QueryItems(point, searchRadiusSquared, quadtreePoints);
		}
		stopwatch.Stop();
		quadtreeMilliseconds.Enqueue(stopwatch.ElapsedMilliseconds);
		if (quadtreeMilliseconds.Count > queueSize) quadtreeMilliseconds.Dequeue();
	}

	private void UpdateTraditional()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		foreach (Vector2 pointA in points)
		{
			traditionalPoints.Clear();
			foreach (Vector2 pointB in points)
			{
				float distanceSquared = Vector2.DistanceSquared(pointA, pointB);
				if (distanceSquared < searchRadiusSquared) traditionalPoints.Add(pointB);
			}
		}
		stopwatch.Stop();
		traditionalMilliseconds.Enqueue(stopwatch.ElapsedMilliseconds);
		if (traditionalMilliseconds.Count > queueSize) traditionalMilliseconds.Dequeue();
	}

	public override void OnDraw()
	{
		Drawing.Clear(Colors.Black);

		Primitives2D.DrawCircle(mousePosition, 2, Colors.Blue);
		Primitives2D.DrawCircleLines(mousePosition, searchRadius, 2, Colors.Blue);

		List<Rectangle> intersectingBounds = new();
		quadtree.QueryBounds(mousePosition, searchRadiusSquared, intersectingBounds);
		List<Vector2> mousePoints = new();
		quadtree.QueryItems(mousePosition, searchRadiusSquared, mousePoints);

		quadtree.DrawBounds(2, Colors.Green);
		foreach (Rectangle bounds in intersectingBounds) Primitives2D.DrawRectangleLines(bounds, 1, Colors.Orange);
		foreach (Vector2 point in points) Primitives2D.DrawCircle(point, 2, Colors.White);
		foreach (Vector2 point in mousePoints) Primitives2D.DrawCircleLines(point, 4, 1, Colors.Red);

		Text.DrawDebug(30, Colors.White, $"Quad: {quadtreeMilliseconds.Average():F2}ms", $"Trad: {traditionalMilliseconds.Average():F2}");
	}

	public override void OnDrawGUI()
	{
		
	}
}
