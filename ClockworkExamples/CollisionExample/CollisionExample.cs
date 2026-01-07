using Clockwork;
using Clockwork.Graphics;
using Clockwork.Input;
using Clockwork.Shapes;
using Clockwork.Utilities;
using Clockwork.Windowing;

internal class CollisionExample : Game
{
	private CollisionScene collisionScene = new();

	public CollisionExample()
	{
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
