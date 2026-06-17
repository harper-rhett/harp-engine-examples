using Clockwork.Shapes;
using System.Numerics;
using Clockwork.Intersections;

internal interface ICollider : IIntersectsWithRectangle, IIntersectsWithCircle, IIntersectsWithLine
{
	public Vector2 Position { get; set; }
	public bool IsSelected { set; }
	public bool IsCollidedWith { get; set; }

	public bool IsColliding(out ICollider otherCollider);
}