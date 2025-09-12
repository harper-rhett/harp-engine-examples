using HarpEngine;
using HarpEngine.Windowing;
using HarpEngine.Graphics;
using HarpEngine.Particles;
using HarpEngine.Utilities;
using System.Numerics;
using HarpEngine.Animation;

internal class FireworksExample : Game
{
	private Scene scene = new();

	public FireworksExample()
	{
		Window.SetResizable(true);
		Window.SetRendererUnclipped(Colors.DarkGray);

		FireworkLauncher fireworkLauncher = new(scene);
		fireworkLauncher.Start();
	}

	public override void Update(float frameTime)
	{
		scene.Update(frameTime);
	}

	public override void Draw()
	{
		scene.Draw();
	}
}

internal class FireworkLauncher : FireTimer
{
	ParticleEngine2D fireworks;
	ParticleEngine2D explosions;
	private const float gravity = 50;
	private const float reloadTime = 2;
	private const float launchForce = -150;
	private const float fireworkRadius = 1;

	public FireworkLauncher(Scene scene) : base(scene, reloadTime)
	{
		explosions = new(scene);
		explosions.RenderAsCircle(1);
		explosions.AddInitializer(ParticleInitializers.RandomizeLifespan(1, 2));
		explosions.AddInitializer(ParticleInitializers.RandomizeDirection());
		explosions.AddInitializer(ParticleInitializers.RandomizeSpeed(25, 50));
		explosions.AddModifier(ParticleModifiers.AdjustColor(Colors.SkyBlue, Colors.White.DropAlpha(), Curves.Cubic));
		explosions.AddModifier(ParticleModifiers.AddVelocity(Vector2.UnitY * gravity));
		explosions.AddModifier(ParticleModifiers.ApplyMovement());

		fireworks = new(scene);
		fireworks.RenderAsCircle(fireworkRadius);
		fireworks.AddInitializer(ParticleInitializers.ConicDirection(Vector2.UnitY, 15));
		fireworks.AddInitializer(ParticleInitializers.SetSpeed(launchForce));
		fireworks.AddInitializer(ParticleInitializers.OverrideLifespan(3));
		fireworks.AddModifier(ParticleModifiers.AddVelocity(Vector2.UnitY * gravity));
		fireworks.AddModifier(ParticleModifiers.ApplyMovement());
		fireworks.AddModifier(ParticleModifiers.AdjustColor(Colors.Red, Colors.White, Curves.Linear));
		fireworks.AddFinalizer(ParticleFinalizers.CreateBurst(explosions, 50));
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
