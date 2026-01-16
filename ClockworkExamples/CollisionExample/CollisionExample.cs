using Clockwork;
using Clockwork.Graphics;
using Clockwork.Windowing;

public class CollisionExample : Game
{
	private CollisionScene collisionScene;

	public CollisionExample() : base("Collision Example", 500, 500)
	{
		collisionScene = new();
		WindowRenderer.SetUnclipped(Colors.Gray);
		Window.SetResizable(true);
	}

	public override void OnUpdate()
	{
		collisionScene.Update();
	}

	public override void OnDraw()
	{
		collisionScene.Draw();
	}
}
