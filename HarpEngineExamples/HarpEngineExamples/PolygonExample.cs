using HarpEngine;
using HarpEngine.Windowing;
using HarpEngine.Graphics;
using HarpEngine.Input;
using HarpEngine.Shapes;
using HarpEngine.Particles;
using HarpEngine.Animation;

internal class PolygonExample : Game
{
	Scene scene = new();

	public PolygonExample()
	{
		Window.SetResizable(true);
		Window.SetFullRenderer(Colors.DarkGray);
		new Camera2D(scene);

		new CustomPolygon(scene, 3, Colors.Green);
		new CustomPolygon(scene, 4, Colors.Blue);
		new CustomPolygon(scene, 5, Colors.Red);
	}

	public override void Update(float frameTime)
	{
		if (Keyboard.IsKeyPressed(KeyboardKey.Space)) scene.IsPaused = !scene.IsPaused;

		scene.Update(frameTime);
	}

	public override void Draw()
	{
		Drawing.Clear(Colors.Black);
		scene.Draw();
	}
}

internal class CustomPolygon : Polygon
{
	// General
	private int index;
	private static int count;

	// Settings
	private const float radius = 16;

	// Particles
	ParticleEngine2D particleEngine;

	public CustomPolygon(Scene scene, int sideCount, Color color) : base(scene, radius, sideCount, color)
	{
		// Self
		index = count;
		count++;

		// Particles
		scene.Entities.NextDrawLayer = -1;
		particleEngine = new(scene);
		particleEngine.IsStreaming = true;
		particleEngine.StreamCooldownTime = 0.01f;
		particleEngine.StreamFired += StreamParticle;
		particleEngine.RenderAsPixel();
		particleEngine.AddInitializer(ParticleInitializers.RandomizeDirection());
		particleEngine.AddInitializer(ParticleInitializers.ScatterByDirection(radius / 2f));
		particleEngine.AddInitializer(ParticleInitializers.SetSpeed(15));
		particleEngine.AddModifier(ParticleModifiers.ApplyMovement());
		particleEngine.AddModifier(ParticleModifiers.AdjustColor(color, color.DropAlpha(), Curves.Linear));
	}

	public override void Update(float frameTime)
	{
		// Movement
		float rotationOffset = ((float)index / count) * MathF.Tau;
		float x = MathF.Cos(scene.Time + rotationOffset) * 64;
		float y = MathF.Sin(scene.Time + rotationOffset) * 64;
		Transform.WorldRotation = scene.Time * -100f;
		Transform.WorldPosition = new(x, y);
	}

	private void StreamParticle(out Particle2D particleTemplate)
	{
		particleTemplate = new()
		{
			Position = Transform.WorldPosition,
			Color = Color,
			Lifespan = 1
		};
	}
}