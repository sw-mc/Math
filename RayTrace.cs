namespace SkyWing.Math;

public class RayTraceResult {

	public AxisAlignedBB BB { get; set; }

	public Direction HitFace { get; set; }

	public Vector3 HitVector { get; set; }

	public RayTraceResult(AxisAlignedBB bb, Direction hitFace, Vector3 hitVector) {
		BB = bb;
		HitFace = hitFace;
		HitVector = hitVector;
	}
}