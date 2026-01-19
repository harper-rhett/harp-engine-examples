using Clockwork;
using Clockwork.Graphics;
using Clockwork.Utilities;
using System.Numerics;

internal class CollisionScene : Scene
{
	public ICollider[] Colliders = new ICollider[25];
	private const int MinimumSize = 25;
	private const int MaximumSize = 50;
	public static Color StaticColor = Colors.Blue;
	public static Color StaticCollisionColor = Colors.Cyan;
	public static Color SelectedColor = Colors.Green;
	public static Color SelectedCollisionColor = Colors.Lime;

	public CollisionScene()
	{
		for (int colliderIndex = 0; colliderIndex < Colliders.Length; colliderIndex++)
		{
			int modulo = colliderIndex % 3;
			if (modulo == 0) AddRectangle(colliderIndex);
			else if (modulo == 1) AddCircle(colliderIndex);
			else AddLine(colliderIndex);
		}

		Selector selector = AddEntity(new Selector(Colliders[0]));
	}

	private void AddRectangle(int colliderIndex)
	{
		int width = Generate.Integer(MinimumSize, MaximumSize);
		int height = Generate.Integer(MinimumSize, MaximumSize);
		RectangleCollider rectangleCollider = AddEntity(new RectangleCollider(this, width, height));
		int x = Generate.Integer(0, Engine.GameWidth - width);
		int y = Generate.Integer(0, Engine.GameHeight - height);
		rectangleCollider.Transform.WorldPosition = new(x, y);
		Colliders[colliderIndex] = rectangleCollider;
	}

	private void AddCircle(int colliderIndex)
	{
		float radius = Generate.Float(MinimumSize / 2f, MaximumSize / 2f);
		CircleCollider circleCollider = AddEntity(new CircleCollider(this, radius));
		float x = Generate.Float(radius, Engine.GameWidth - radius);
		float y = Generate.Float(radius, Engine.GameHeight - radius);
		circleCollider.Transform.WorldPosition = new(x, y);
		Colliders[colliderIndex] = circleCollider;
	}

	private void AddLine(int colliderIndex)
	{
		LineCollider lineCollider = AddEntity(new LineCollider(this, 2.5f));
		int x = Generate.Integer(MaximumSize, Engine.GameWidth - MaximumSize);
		int y = Generate.Integer(MaximumSize, Engine.GameHeight - MaximumSize);
		Vector2 position = new(x, y);
		float halfLength = Generate.Float(MinimumSize, MaximumSize);
		Vector2 halfDirection = Generate.UnitVector2();
		lineCollider.StartPosition = position + halfDirection * halfLength;
		lineCollider.EndPosition = position + -halfDirection * halfLength;
		Colliders[colliderIndex] = lineCollider;
	}
}