using Clockwork;
using Clockwork.Windowing;
using Clockwork.Graphics;
using Clockwork.Particles;
using Clockwork.Utilities;
using System.Numerics;
using Clockwork.Animation;

internal class FireworksExample : Game
{
	private Scene scene = new();

	public FireworksExample()
	{
		Window.SetResizable(true);
		WindowRenderer.SetUnclipped(Colors.DarkGray);

		FireworkLauncher fireworkLauncher = new();
		fireworkLauncher.Start();
		scene.AddEntity(fireworkLauncher);
	}

	public override void OnUpdate()
	{
		scene.Update();
	}

	public override void OnDraw()
	{
		scene.Draw();
	}
}

internal class FireworkLauncher : FireTimer
{
	private ParticleEngine2D fireworks;
	private ParticleEngine2D explosions;

	private Color[] colors = new Color[]
	{
		Colors.Red,
		Colors.Blue,
		Colors.Green,
		Colors.Yellow,
	};

	private const float gravity = 50;
	private const float reloadTime = 0.5f;
	private const float launchForce = -150;
	private const float fireworkRadius = 1;

	public FireworkLauncher() : base(reloadTime)
	{
		explosions = new();
		explosions.RenderAsCircle(1);
		explosions.AddInitializer(ParticleInitializers.RandomizeLifespan(1, 2));
		explosions.AddInitializer(ParticleInitializers.RandomizeDirection());
		explosions.AddInitializer(ParticleInitializers.RandomizeSpeed(10, 50));
		explosions.AddModifier(ParticleModifiers.AddVelocity(Vector2.UnitY * gravity));
		explosions.AddModifier(ParticleModifiers.ApplyMovement());

		fireworks = new();
		fireworks.RenderAsCircle(fireworkRadius);
		fireworks.AddInitializer(ParticleInitializers.SetColors(Colors.Red, Colors.White));
		fireworks.AddInitializer(ParticleInitializers.ConicDirection(Vector2.UnitY, 15));
		fireworks.AddInitializer(ParticleInitializers.SetSpeed(launchForce));
		fireworks.AddInitializer(ParticleInitializers.OverrideLifespan(3));
		fireworks.AddModifier(ParticleModifiers.AddVelocity(Vector2.UnitY * gravity));
		fireworks.AddModifier(ParticleModifiers.ApplyMovement());
		fireworks.AddFinalizer(CreateExplosion(explosions, 100));
	}

	public Particle2DFinalizer CreateExplosion(ParticleEngine2D burstEngine, int particleCount)
	{
		return (Particle2D particle, ParticleEngine2D engine) =>
		{
			Color color = colors[Generate.Integer(colors.Length)];
			Particle2D particleTemplate = new()
			{
				Position = particle.Position,
				Gradient = new(color, Colors.White.DropAlpha())
			};
			burstEngine.SpawnBurst(particleTemplate, particleCount);
		};
	}

	public override void OnAddedToScene()
	{
		Scene.AddEntity(explosions);
		Scene.AddEntity(fireworks);
	}

	protected override void OnFired()
	{
		Particle2D firework = new()
		{
			Position = new(Engine.HalfGameWidth, Engine.GameHeight),
		};
		fireworks.SpawnParticle(firework);
	}
}
