using Clockwork;
using Clockwork.Graphics;
using Clockwork.Windowing;

public class CollisionExample : Game
{
	private CollisionScene collisionScene;

	public CollisionExample()
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

	public override void OnDrawGUI()
	{
		collisionScene.DrawGUI();
	}
}
