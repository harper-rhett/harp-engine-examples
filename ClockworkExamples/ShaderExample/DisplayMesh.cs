using Clockwork;
using Clockwork.Graphics.Draw3D;
using System.Numerics;
using Clockwork.Utilities;

public class DisplayMesh : Entity
{
	private Mesh mesh;
	private Vector3 position;

	public DisplayMesh(Mesh mesh, Vector3 position)
	{
		this.mesh = mesh;
		this.position = position;
	}

	public override void OnDraw()
	{
		mesh.Draw(new Material(), new Transform3D(position, Quaternion.Identity));
	}
}
