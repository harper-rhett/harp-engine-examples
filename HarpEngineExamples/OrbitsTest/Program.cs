using HarpEngine;

EngineSettings settings = new()
{
	WindowName = "Orbits Example",
	GameWidth = 1000,
	GameHeight = 1000
};
Engine.Initialize(settings);
OrbitsExample orbitsExample = new();
Engine.Start(orbitsExample);