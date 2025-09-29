using HarpEngine;

EngineSettings settings = new()
{
	WindowName = "Polygon Example"
};
Engine.Initialize(settings);
PolygonExample polygonExample = new();
Engine.Start(polygonExample);