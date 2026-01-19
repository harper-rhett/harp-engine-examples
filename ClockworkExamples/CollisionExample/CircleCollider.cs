using Clockwork.Graphics;
using Clockwork.Shapes;
using System.Numerics;

internal class CircleCollider : CircleShape, ICollider
{
	private CollisionScene collisionScene;
	public bool IsSelected { get; set; }
	public bool IsCollidedWith { get; set; }

	public Vector2 Position
	{
		get => Transform.WorldPosition;
		set => Transform.WorldPosition = value;
	}

	public CircleCollider(CollisionScene collisionScene, float radius) : base(radius, CollisionScene.StaticColor)
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
			bool doesCollide = collider.IntersectsWithCircle(this);
			collider.IsCollidedWith = doesCollide;
			isCollision = isCollision || doesCollide;
			if (doesCollide) otherCollider = collider;
		}
		Color = isCollision ? CollisionScene.SelectedCollisionColor : CollisionScene.SelectedColor;
		return isCollision;
	}
}