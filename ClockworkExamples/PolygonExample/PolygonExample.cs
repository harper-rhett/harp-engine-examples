using Clockwork;
using Clockwork.Windowing;
using Clockwork.Graphics;
using Clockwork.Input;
using Clockwork.Graphics.Cameras;

public class PolygonExample : Game
{
	Scene scene = new();

	public PolygonExample()
	{
		Window.SetResizable(true);
		WindowRenderer.SetUnclipped(Colors.DarkGray);
		scene.Camera = new Camera2D();

		scene.AddEntity(new CustomPolygon(3, Colors.Lime));
		scene.AddEntity(new CustomPolygon(4, Colors.Blue));
		scene.AddEntity(new CustomPolygon(5, Colors.Red));
	}

	public override void OnUpdate()
	{
		if (Keyboard.IsKeyPressed(KeyboardKey.Space)) scene.IsPaused = !scene.IsPaused;
		
		scene.Update();
	}

	public override void OnDraw()
	{
		scene.Draw();
	}
}