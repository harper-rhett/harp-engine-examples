using HarpEngine;

EngineSettings settings = new()
{
	WindowName = "Fireworks Example"
};
Engine.Initialize(settings);
FireworksExample fireworksExample = new();
Engine.Start(fireworksExample);