using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;
using Clockwork.Windowing;

public class UIExample : Game
{
	private Scene scene;

	public UIExample()
	{
		scene = new(Colors.DarkGray);
		Window.SetResizable(true);

		// Create main container
		HorizontalStackContainer mainContainer = new();
		mainContainer.StretchChildrenWidth = true;
		mainContainer.BackgroundColor = Colors.Clear;
		mainContainer.Padding = 25;

		InitializeLeft(mainContainer);
		InitializeRight(mainContainer);

		// Add to panel
		Panel panel = scene.AddEntity(new Panel(mainContainer, DrawContext.Game));
	}

	private void InitializeLeft(Container mainContainer)
	{
		// Create left container
		VerticalStackContainer leftContainer = new();
		mainContainer.AddChild(leftContainer);
		leftContainer.BackgroundColor = Colors.Green;
		leftContainer.Spacing = 25;
		leftContainer.Padding = 25;

		// Play button
		Button playButton = new();
		leftContainer.AddChild(playButton);

		TextElement playText = new("PLAY");
		playButton.AddChild(playText);
		playText.HorizontalAlignment = HorizontalAlignment.Center;
		playText.VerticalAlignment = VerticalAlignment.Center;

		// Settings button
		Button settingsButton = new();
		leftContainer.AddChild(settingsButton);

		TextElement settingsText = new("SETTINGS");
		settingsButton.AddChild(settingsText);
		settingsText.HorizontalAlignment = HorizontalAlignment.Center;
		settingsText.VerticalAlignment = VerticalAlignment.Center;
	}

	private void InitializeRight(Container mainContainer)
	{
		// Create right container
		Container rightContainer = new();
		mainContainer.AddChild(rightContainer);
		rightContainer.BackgroundColor = Colors.Red;
		rightContainer.Padding = 25;

		// Create text
		TextElement text = new("This is what UI currently looks like!");
		rightContainer.AddChild(text);
	}

	public override void OnUpdate()
	{
		scene.Update();
	}

	public override void OnDraw()
	{
		scene.Draw();
	}

	public override void OnDrawGUI()
	{
		scene.DrawGUI();
	}
}