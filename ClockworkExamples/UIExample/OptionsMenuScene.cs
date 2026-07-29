using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;

public class OptionsMenuScene : Scene
{
	private UIExample uiExample;
	private VerticalStackContainer rootContainer;
	private TextButton backButton;
	private TextToggle fullscreenToggle;

	public OptionsMenuScene(UIExample uiExample) : base(Colors.Gray)
	{
		this.uiExample = uiExample;
		CreateContainer();
		CreateFullscreenToggle();
		CreateBackButton();
	}

	private void CreateContainer()
	{
		rootContainer = new VerticalStackContainer
		{
			BackgroundColor = Colors.Clear,
			Padding = 50,
			Spacing = 25
		};

		Panel panel = AddEntity(new Panel(rootContainer, DrawContext.Game));
		panel.HorizontalAlignment = HorizontalAlignment.Center;
	}

	// Need to add slider

	private void CreateFullscreenToggle()
	{
		fullscreenToggle = new TextToggle("FULLSCREEN");
		fullscreenToggle.Toggled += uiExample.SetFullscreen;
		rootContainer.AddChild(fullscreenToggle);
	}

	private void CreateBackButton()
	{
		backButton = new("BACK");
		backButton.Released += uiExample.CloseOptions;
		rootContainer.AddChild(backButton);
	}

	public void Dispose()
	{
		backButton.Released -= uiExample.CloseOptions;
	}
}
