using HarpEngine;

EngineSettings settings = new()
{
	WindowName = "Gradient Example",
	GameWidth = 64,
	GameHeight = 64
};
Engine.Initialize(settings);
GradientExample gradientExample = new();
Engine.Start(gradientExample);