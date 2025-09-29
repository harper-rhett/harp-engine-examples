using HarpEngine;
using HarpEngine.Graphics;
using HarpEngine.Windowing;

internal class GradientExample : Game
{
	private Gradient gradient;
	private Color[] gradientOutput;

	public GradientExample()
	{
		Window.SetResizable(true);

		gradient = new(Colors.Red, 0);
		gradient.AddColor(Colors.Yellow, 0.25f);
		gradient.AddColor(Colors.Green, 0.75f);
		gradient.AddColor(Colors.Blue, 1.0f);

		gradientOutput = new Color[Engine.GameWidth];
		for (int x = 0; x < Engine.GameWidth; x++)
		{
			float position = (float)x / Engine.GameWidth;
			Color color = gradient.Sample(position);
			gradientOutput[x] = color;
			Console.WriteLine($"X: {x} Pos: {position} Col: {color}");
		}
	}

	public override void Update()
	{
		
	}

	public override void Draw()
	{
		for (int x = 0; x < Engine.GameWidth; x++)
		{
			Color color = gradientOutput[x];
			Primitives.DrawLine(x + 1, 0, x + 1, Engine.GameHeight, color);
		}
	}
}
