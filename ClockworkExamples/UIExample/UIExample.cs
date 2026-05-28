using Clockwork;
using Clockwork.UI;

public class UIExample : Game
{
	Scene scene;

	public UIExample()
	{
		scene = new([new Button()]);
	}

	public override void OnUpdate()
	{
		scene.Update();
	}

	public override void OnDraw()
	{
		scene.Draw();
	}
}
