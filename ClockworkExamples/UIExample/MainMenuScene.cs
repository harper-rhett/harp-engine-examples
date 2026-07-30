using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;
using Clockwork.Windowing;
using System;

public class MainMenuScene : Scene, IDisposable
{
	private UIExample uiExample;
	private VerticalStackContainer rootContainer;
	private TextButton playButton;
	private TextButton optionsButton;
	private TextButton exitButton;

	public MainMenuScene(UIExample uiExample) : base(Colors.Gray)
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
			PaddingTop = 50,
			PaddingBottom = 50,
			PaddingLeft = 150,
			PaddingRight = 150,
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
		exitButton.Released += uiExample.Exit;
		rootContainer.AddChild(exitButton);
	}

	public void Dispose()
	{
		playButton.Released -= uiExample.Play;
		optionsButton.Released -= uiExample.OpenOptions;
		exitButton.Released -= uiExample.Exit;
	}
}
