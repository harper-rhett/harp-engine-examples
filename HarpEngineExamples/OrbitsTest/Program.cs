using HarpEngine;

EngineSettings settings = new()
{
	GameWidth = 1000,
	GameHeight = 1000
};
Engine.Initialize(settings);
OrbitsTest orbitsTest = new();
Engine.Start(orbitsTest);