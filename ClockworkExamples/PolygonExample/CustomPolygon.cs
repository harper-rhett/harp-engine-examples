using Clockwork.Graphics;
using Clockwork.Particles;
using Clockwork.Shapes;

public class CustomPolygon : PolygonShape
{
	// General
	private int index;
	private static int count;

	// Settings
	private const float radius = 16;

	// Particles
	private ParticleEngine2D particleEngine;

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