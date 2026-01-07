using Clockwork;
using Clockwork.Windowing;
using Clockwork.Graphics;
using Clockwork.Input;
using Clockwork.Shapes;
using Clockwork.Particles;
using Clockwork.Animation;

internal class PolygonExample : Game
{
	Scene scene = new();

	public PolygonExample()
	{
		Window.SetResizable(true);
		WindowRenderer.SetUnclipped(Colors.DarkGray);
		scene.Camera = new Camera2D();

		scene.AddEntity(new CustomPolygon(3, Colors.Green));
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

internal class CustomPolygon : PolygonShape
{
	// General
	private int index;
	private static int count;

	// Settings
	private const float radius = 16;

	// Particles
	ParticleEngine2D particleEngine;

	public CustomPolygon(int sideCount, Color color) : base(radius, sideCount, color)
	{
		// Self
		index = count;
		count++;

		// Particles
		particleEngine = new();
		particleEngine.DrawLayer = -1;
		particleEngine.IsStreaming = true;
		particleEngine.StreamCooldownTime = 0.01f;
		particleEngine.StreamFired += StreamParticle;
		particleEngine.RenderAsPixel();
		particleEngine.AddInitializer(ParticleInitializers.SetColors(Color, Color.DropAlpha()));
		particleEngine.AddInitializer(ParticleInitializers.RandomizeDirection());
		particleEngine.AddInitializer(ParticleInitializers.ScatterByDirection(radius / 2f));
		particleEngine.AddInitializer(ParticleInitializers.SetSpeed(15));
		particleEngine.AddModifier(ParticleModifiers.ApplyMovement());
	}

	public override void OnAddedToScene()
	{
		Scene.AddEntity(particleEngine);
	}

	public override void OnUpdate()
	{
		// Movement
		float rotationOffset = ((float)index / count) * MathF.Tau;
		float x = MathF.Cos(Scene.Time + rotationOffset) * 64;
		float y = MathF.Sin(Scene.Time + rotationOffset) * 64;
		Transform.WorldRotation = Scene.Time * -100f;
		Transform.WorldPosition = new(x, y);
	}

	private void StreamParticle(out Particle2D particleTemplate)
	{
		particleTemplate = new()
		{
			Position = Transform.WorldPosition,
			Lifespan = 1
		};
	}
}