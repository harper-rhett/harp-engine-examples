using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;

public class UIExample : Game
{
	private Scene scene;

	public UIExample()
	{
		scene = new(Colors.DarkGray);

		// Create main container
		HorizontalStackContainer mainContainer = scene.AddEntity(new HorizontalStackContainer());
		mainContainer.StretchChildrenWidth = true;
		mainContainer.BackgroundColor = Colors.Clear;
		mainContainer.Padding = 25;

		// Create left container
		VerticalStackContainer leftContainer = scene.AddEntity(new VerticalStackContainer());
		mainContainer.AddChild(leftContainer);
		leftContainer.BackgroundColor = Colors.Green;
		leftContainer.Spacing = 25;
		leftContainer.Padding = 25;

		// Create right container
		VerticalStackContainer rightContainer = scene.AddEntity(new VerticalStackContainer());
		mainContainer.AddChild(rightContainer);
		rightContainer.BackgroundColor = Colors.Red;
		rightContainer.Spacing = 25;
		rightContainer.Padding = 25;

		// Play button
		Button playButton = scene.AddEntity(new Button());
		leftContainer.AddChild(playButton);

		TextElement playText = scene.AddEntity(new TextElement("PLAY"));
		playButton.AddChild(playText);
		playText.HorizontalAlignment = HorizontalAlignment.Center;
		playText.VerticalAlignment = VerticalAlignment.Center;

		// Settings button
		Button settingsButton = scene.AddEntity(new Button());
		leftContainer.AddChild(settingsButton);

		TextElement settingsText = scene.AddEntity(new TextElement("SETTINGS"));
		settingsButton.AddChild(settingsText);
		settingsText.HorizontalAlignment = HorizontalAlignment.Center;
		settingsText.VerticalAlignment = VerticalAlignment.Center;
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