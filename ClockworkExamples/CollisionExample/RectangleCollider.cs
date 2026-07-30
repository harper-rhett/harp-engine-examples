using Clockwork.Graphics;
using Clockwork.Shapes;
using System.Numerics;

internal class RectangleCollider : RectangleShape, ICollider
{
	private CollisionScene collisionScene;
	public bool IsSelected { get; set; }
	public bool IsCollidedWith { get; set; }

	public Vector2 Position
	{
		get => Transform.WorldPosition;
		set => Transform.WorldPosition = value;
	}

	public RectangleCollider(CollisionScene collisionScene, int width, int height) : base(width, height, CollisionScene.StaticColor)
	{
		this.collisionScene = collisionScene;
	}

	public override void OnUpdate()
	{
		if (IsSelected) Color = IsSelected ? CollisionScene.SelectedCollisionColor : CollisionScene.StaticColor;
		else Color = IsCollidedWith ? CollisionScene.StaticCollisionColor : CollisionScene.StaticColor;
	}

	public bool IsColliding(out ICollider otherCollider)
	{
		otherCollider = null;
		bool isCollision = false;
		foreach (ICollider collider in collisionScene.Colliders)
		{
			if (collider == this) continue;
			bool doesCollide = collider.IntersectsWithRectangle(this);
			collider.IsCollidedWith = doesCollide;
			isCollision = isCollision || doesCollide;
			if (doesCollide) otherCollider = collider;
		}
		Color = isCollision ? CollisionScene.SelectedCollisionColor : CollisionScene.SelectedColor;
		return isCollision;
	}
}