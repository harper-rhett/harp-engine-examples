using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;

public class OptionsMenuScene : Scene
{
	private UIExample uiExample;
	private VerticalStackContainer rootContainer;

	public OptionsMenuScene(UIExample uiExample)
	{
		this.uiExample = uiExample;
		CreateContainer();
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
}
