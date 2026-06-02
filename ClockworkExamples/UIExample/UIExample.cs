using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;

// Hey! This example is unfinished.

// IT IS A WORK IN PROGRESS. Come back later to check out the complete version.

public class UIExample : Game
{
	private Scene scene;

	public UIExample()
	{
		scene = new(Colors.Black);

		Container mainContainer = scene.AddEntity(new Container());
		mainContainer.BackgroundColor = Colors.Clear;
		mainContainer.Padding = 15;
		mainContainer.AddChild(scene.AddEntity(new Button()));
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
