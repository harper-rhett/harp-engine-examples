using Clockwork;
using Clockwork.Graphics.Text;
using Clockwork.Windowing;

public class UIExample : Game
{
	private Scene activeScene;
	private Scene mainMenu;
	private Scene optionsMenu;

	public UIExample()
	{
		Window.SetResizable(true);
		Font.Default = Font.Load("Rajdhani-Bold.ttf", 100);
		mainMenu = new MainMenuScene(this);
		optionsMenu = new OptionsMenuScene(this);
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
		mainMenu = null;
		optionsMenu = null;
	}

	public void OpenOptions()
	{
		activeScene = optionsMenu;
	}
}