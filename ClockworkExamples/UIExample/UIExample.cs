using Clockwork;
using Clockwork.Graphics.Text;
using Clockwork.Windowing;
using System;

public class UIExample : Game
{
	private Scene activeScene;
	private MainMenuScene mainMenu;
	private OptionsMenuScene optionsMenu;

	public UIExample()
	{
		Window.SetResizable(true);
		Font.Default = Font.Load("Rajdhani-Bold.ttf", 100);
		mainMenu = new MainMenuScene(this);
		activeScene = mainMenu;
	}

	public override void OnUpdate()
	{
		activeScene.Update();
	}

	public override void OnDraw()
	{
		activeScene.Draw();
	}

	public override void OnDrawGUI()
	{
		activeScene.DrawGUI();
	}

	public void Play()
	{
		activeScene = new GameScene();
		mainMenu.Dispose();
		mainMenu = null;
		if (optionsMenu is not null) optionsMenu.Dispose();
		optionsMenu = null;
	}

	public void OpenOptions()
	{
		if (optionsMenu is null) optionsMenu = new OptionsMenuScene(this);
		activeScene = optionsMenu;
	}

	public void SetFullscreen(bool isFullscreen) => Window.SetFullscreen(isFullscreen);

	public void CloseOptions()
	{
		activeScene = mainMenu;
	}

	public void Exit() => Environment.Exit(0);
}