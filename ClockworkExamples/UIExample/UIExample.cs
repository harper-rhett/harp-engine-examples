using Clockwork;
using Clockwork.UI;

// Hey! This example is unfinished.

// IT IS A WORK IN PROGRESS. Come back later to check out the complete version.

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
