using Clockwork;
using Clockwork.Graphics;
using Clockwork.Shapes;
using System.Numerics;

internal class LineCollider : LineShape, ICollider
{
	private CollisionScene collisionScene;
	public bool IsSelected { get; set; }
	public bool IsCollidedWith { get; set; }

	private Vector2 endOffset;
	public Vector2 Position
	{
		get => StartPosition;
		set
		{
			StartPosition = value;
			base.EndPosition = StartPosition + endOffset;
		}
	}
	public new Vector2 EndPosition
	{
		set
		{
			base.EndPosition = value;
			endOffset = base.EndPosition - StartPosition;
		}
	}

	public LineCollider(CollisionScene collisionScene, float thickness) : base(thickness, CollisionScene.StaticColor)
	{
		this.collisionScene = collisionScene;
	}

	public override void OnUpdate()
	{
		if (IsSelected) Color = IsSelected ? CollisionScene.SelectedCollisionColor : CollisionScene.StaticColor;
		else Color = IsCollidedWith ? CollisionScene.StaticCollisionColor : CollisionScene.StaticColor;
	}

	bool ICollider.IsColliding(out ICollider otherCollider)
	{
		otherCollider = null;
		bool isCollision = false;
		foreach (ICollider collider in collisionScene.Colliders)
		{
			if (collider == this) continue;
			bool doesCollide = collider.IntersectsWithLine(this);
			collider.IsCollidedWith = doesCollide;
			isCollision = isCollision || doesCollide;
			if (doesCollide) otherCollider = collider;
		}
		Color = isCollision ? CollisionScene.SelectedCollisionColor : CollisionScene.SelectedColor;
		return isCollision;
	}
}
