using Clockwork;
using Clockwork.Graphics;
using Clockwork.Windowing;
using Clockwork.Graphics.Draw2D;

public class GradientExample : Game
{
	private Gradient gradient;
	private Color[] gradientOutput;

	public GradientExample() : base("Gradient Example", 64, 64)
	{
		Window.SetResizable(true);

		gradient = new(Colors.Red, Colors.Yellow, Colors.Green, Colors.Blue);

		gradientOutput = new Color[Engine.GameWidth];
		for (int x = 0; x < Engine.GameWidth; x++)
		{
			float position = (float)x / Engine.GameWidth;
			Color color = gradient.Sample(position);
			gradientOutput[x] = color;
		}
	}

	public override void OnUpdate()
	{
		
	}

	public override void OnDraw()
	{
		for (int x = 0; x < Engine.GameWidth; x++)
		{
			Color color = gradientOutput[x];
			Primitives2D.DrawLine(x + 1, 0, x + 1, Engine.GameHeight, 1, color);
		}
	}
}
