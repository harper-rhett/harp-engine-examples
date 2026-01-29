using Clockwork;
using Clockwork.Graphics.Draw3D;
using System.Numerics;

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
		Mesh.Draw(mesh, new(), new(position, Quaternion.Identity));
	}
}
