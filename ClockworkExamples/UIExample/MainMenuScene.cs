using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;
using Clockwork.Windowing;
using System;

public class MainMenuScene : Scene
{
	private UIExample uiExample;
	private VerticalStackContainer rootContainer;
	private TextButton playButton;
	private TextButton optionsButton;
	private TextButton exitButton;

	public MainMenuScene(UIExample uiExample)
	{
		this.uiExample = uiExample;
		CreateContainer();
		CreatePlayButton();
		CreateOptionsButton();
		CreateExitButton();
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

	private void CreatePlayButton()
	{
		playButton = new("PLAY");
		playButton.Released += uiExample.Play;
		rootContainer.AddChild(playButton);
	}

	private void CreateOptionsButton()
	{
		optionsButton = new("OPTIONS");
		optionsButton.Released += uiExample.OpenOptions;
		rootContainer.AddChild(optionsButton);
	}

	private void CreateExitButton()
	{
		exitButton = new("EXIT");
		exitButton.Released += () => Environment.Exit(0);
		rootContainer.AddChild(exitButton);
	}
}
