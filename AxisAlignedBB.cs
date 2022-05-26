namespace SkyWing.Math;

public class AxisAlignedBB {

	public float MinX;
	public float MinY;
	public float MinZ;
	public float MaxX;
	public float MaxY;
	public float MaxZ;

	public AxisAlignedBB(float minX, float minY, float minZ, float maxX, float maxY, float maxZ) {
		if (MinX > MaxX) {
			throw new ArgumentException("MinX MinX is larger than MaxX MaxX");
		}

		if (MinY > MaxY) {
			throw new ArgumentException("MinY MinY is larger than MaxY MaxY");
		}

		if (MinZ > MaxZ) {
			throw new ArgumentException("MinZ MinZ is larger than MaxZ MaxZ");
		}

		MinX = minX;
		MinY = minY;
		MinZ = minZ;
		MaxX = maxX;
		MaxY = maxY;
		MaxZ = maxZ;
	}

	/*
	 * Returns a new AxisAlignedBB extended by the specified X, Y && Z.
	 * If each of X, Y && Z are positive, the relevant max bound will be increased. If negative, the relevant min
	 * bound will be decreased.
	 */
	public AxisAlignedBB AddCoord(float x, float y, float z) {
		var minX = MinX;
		var minY = MinY;
		var minZ = MinZ;
		var maxX = MaxX;
		var maxY = MaxY;
		var maxZ = MaxZ;

		switch (x) {
			case < 0:
				minX += x;
				break;
			case > 0:
				maxX += x;
				break;
		}

		switch (y) {
			case < 0:
				minY += y;
				break;
			case > 0:
				maxY += y;
				break;
		}

		switch (z) {
			case < 0:
				minZ += z;
				break;
			case > 0:
				maxZ += z;
				break;
		}

		return new AxisAlignedBB(minX, minY, minZ, maxX, maxY, maxZ);
	}

	/*
	 * Outsets the bounds of this AxisAlignedBB by the specified X, Y && Z.
	 */
	public AxisAlignedBB Expand(float x, float y, float z) {
		MinX -= x;
		MinY -= y;
		MinZ -= z;
		MaxX += x;
		MaxY += y;
		MaxZ += z;

		return this;
	}

	/*
	 * Returns an expanded clone of this AxisAlignedBB.
	 */
	public AxisAlignedBB ExpandedCopy(float x, float y, float z) {
		return Clone().Expand(x, y, z);
	}

	/*
	 * Shifts this AxisAlignedBB by the given X, Y && Z.
	 */
	public AxisAlignedBB Offset(float x, float y, float z) {
		MinX += x;
		MinY += y;
		MinZ += z;
		MaxX += x;
		MaxY += y;
		MaxZ += z;

		return this;
	}

	/*
	 * Returns an offset clone of this AxisAlignedBB.
	 */
	public AxisAlignedBB OffsetCopy(float x, float y, float z) {
		return Clone().Offset(x, y, z);
	}

	/*
	 * Insets the bounds of this AxisAlignedBB by the specified X, Y && Z.
	 */
	public AxisAlignedBB Contract(float x, float y, float z) {
		MinX += x;
		MinY += y;
		MinZ += z;
		MaxX -= x;
		MaxY -= y;
		MaxZ -= z;

		return this;
	}

	/*
	 * Returns a contracted clone of this AxisAlignedBB.
	 */
	public AxisAlignedBB ContractedCopy(float x, float y, float z) {
		return Clone().Contract(x, y, z);
	}

	/*
	 * Extends the AABB in the given direction.
	 */
	public AxisAlignedBB Extend(Direction face, float distance) {
		switch (face) {
			case Direction.Down:
				MinY -= distance;
				break;
			case Direction.Up:
				MaxY += distance;
				break;
			case Direction.North:
				MinZ -= distance;
				break;
			case Direction.South:
				MaxZ += distance;
				break;
			case Direction.West:
				MinX -= distance;
				break;
			case Direction.East:
				MaxX += distance;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(face));
		}

		return this;
	}

	/*
	 * Returns an extended clone of this bounding box.
	 */
	public AxisAlignedBB ExtendedCopy(Direction face, float distance) {
		return Clone().Extend(face, distance);
	}

	/*
	 * Inverse of extend().
	 */
	public AxisAlignedBB Trim(Direction face, float distance) {
		return Extend(face, -distance);
	}

	/*
	 * Returns a trimmed clone of this bounding box.
	 */
	public AxisAlignedBB TrimmedCopy(Direction face, float distance) {
		return ExtendedCopy(face, -distance);
	}

	/*
	 * Increases the dimension of the AABB along the given axis.
	 */
	public AxisAlignedBB Stretch(Axis axis, float distance) {
		switch (axis) {
			case Axis.Y:
				MinY -= distance;
				MaxY += distance;
				break;
			case Axis.Z:
				MinZ -= distance;
				MaxZ += distance;
				break;
			case Axis.X:
				MinX -= distance;
				MaxX += distance;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(axis));
		}

		return this;
	}

	/*
	 * Returns a stretched copy of this bounding box.
	 */
	public AxisAlignedBB StretchedCopy(Axis axis, float distance) {
		return Clone().Stretch(axis, distance);
	}

	/*
	 * Reduces the dimension of the AABB on the given axis. Inverse of stretch().
	 */
	public AxisAlignedBB Squash(Axis axis, float distance) {
		return Stretch(axis, -distance);
	}

	/*
	 * Returns a squashed copy of this bounding box.
	 */
	public AxisAlignedBB SquashedCopy(Axis axis, float distance) {
		return StretchedCopy(axis, -distance);
	}

	public float CalculateXOffset(AxisAlignedBB bb, float x) {
		if (bb.MaxY <= MinY || bb.MinY >= MaxY) {
			return x;
		}

		if (bb.MaxZ <= MinZ || bb.MinZ >= MaxZ) {
			return x;
		}

		if (x > 0 && bb.MaxX <= MinX) {
			var x1 = MinX - bb.MaxX;
			if (x1 < x) {
				x = x1;
			}
		}
		else if (x < 0 && bb.MinX >= MaxX) {
			var x2 = MaxX - bb.MinX;
			if (x2 > x) {
				x = x2;
			}
		}

		return x;
	}

	public float CalculateYOffset(AxisAlignedBB bb, float y) {
		if (bb.MaxX <= MinX || bb.MinX >= MaxX) {
			return y;
		}

		if (bb.MaxZ <= MinZ || bb.MinZ >= MaxZ) {
			return y;
		}

		if (y > 0 && bb.MaxY <= MinY) {
			var y1 = MinY - bb.MaxY;
			if (y1 < y) {
				y = y1;
			}
		}
		else if (y < 0 && bb.MinY >= MaxY) {
			var y2 = MaxY - bb.MinY;
			if (y2 > y) {
				y = y2;
			}
		}

		return y;
	}

	public float CalculateZOffset(AxisAlignedBB bb, float z) {
		if (bb.MaxX <= MinX || bb.MinX >= MaxX) {
			return z;
		}

		if (bb.MaxY <= MinY || bb.MinY >= MaxY) {
			return z;
		}

		if (z > 0 && bb.MaxZ <= MinZ) {
			var z1 = MinZ - bb.MaxZ;
			if (z1 < z) {
				z = z1;
			}
		}
		else if (z < 0 && bb.MinZ >= MaxZ) {
			var z2 = MaxZ - bb.MinZ;
			if (z2 > z) {
				z = z2;
			}
		}

		return z;
	}

	/*
	 * Returns whether any part of the specified AABB is inside (intersects with) this one.
	 */
	public bool IntersectsWith(AxisAlignedBB bb, float epsilon = 0.000001f) {
		if (bb.MaxX - MinX > epsilon && MaxX - bb.MinX > epsilon) {
			if (bb.MaxY - MinY > epsilon && MaxY - bb.MinY > epsilon) {
				return bb.MaxZ - MinZ > epsilon && MaxZ - bb.MinZ > epsilon;
			}
		}

		return false;
	}

	/*
	 * Returns whether the specified vector is within the bounds of this AABB on all axes.
	 */
	public bool IsVectorInside(Vector3 vector) {
		if (vector.X <= MinX || vector.X >= MaxX) {
			return false;
		}

		if (vector.Y <= MinY || vector.Y >= MaxY) {
			return false;
		}

		return vector.Z > MinZ && vector.Z < MaxZ;
	}

	/*
	 * Returns the mean average of the AABB's X, Y && Z lengths.
	 */
	public float GetAverageEdgeLength() {
		return (MaxX - MinX + MaxY - MinY + MaxZ - MinZ) / 3;
	}

	public float GetXLength() {
		return MaxX - MinX;
	}

	public float GetYLength() {
		return MaxY - MinY;
	}

	public float GetZLength() {
		return MaxZ - MinZ;
	}

	public bool IsCube(float epsilon = 0.000001f) {
		var xLen = GetXLength();
		var yLen = GetYLength();
		var zLen = GetZLength();
		return System.Math.Abs(xLen - yLen) < epsilon && System.Math.Abs(yLen - zLen) < epsilon;
	}

	/*
	 * Returns the interior volume of the AABB.
	 */
	public int GetVolume() {
		return Convert.ToInt32((MaxX - MinX) * (MaxY - MinY) * (MaxZ - MinZ));
	}

	/*
	 * Returns whether the specified vector is within the Y && Z bounds of this AABB.
	 */
	public bool IsVectorInYZ(Vector3 vector) {
		return vector.Y >= MinY && vector.Y <= MaxY && vector.Z >= MinZ && vector.Z <= MaxZ;
	}

	/*
	 * Returns whether the specified vector is within the X && Z bounds of this AABB.
	 */
	public bool IsVectorInXZ(Vector3 vector) {
		return vector.X >= MinX && vector.X <= MaxX && vector.Z >= MinZ && vector.Z <= MaxZ;
	}

	/*
	 * Returns whether the specified vector is within the X && Y bounds of this AABB.
	 */
	public bool IsVectorInXY(Vector3 vector) {
		return vector.X >= MinX && vector.X <= MaxX && vector.Y >= MinY && vector.Y <= MaxY;
	}

	/**
	 * Performs a ray-trace && calculates the point on the AABB's edge nearest the start position that the ray-trace
	 * collided with. Returns a RayTraceResult with colliding vector closest to the start position.
	 * Returns null if no colliding point was found.
	 */
	public RayTraceResult? CalculateIntercept(Vector3 pos1, Vector3 pos2) {
		var v1 = pos1.GetIntermediateWithXValue(pos2, MinX);
		var v2 = pos1.GetIntermediateWithXValue(pos2, MaxX);
		var v3 = pos1.GetIntermediateWithYValue(pos2, MinY);
		var v4 = pos1.GetIntermediateWithYValue(pos2, MaxY);
		var v5 = pos1.GetIntermediateWithZValue(pos2, MinZ);
		var v6 = pos1.GetIntermediateWithZValue(pos2, MaxZ);

		if (v1 != null && !IsVectorInYZ(v1)) {
			v1 = null;
		}

		if (v2 != null && !IsVectorInYZ(v2)) {
			v2 = null;
		}

		if (v3 != null && !IsVectorInXZ(v3)) {
			v3 = null;
		}

		if (v4 != null && !IsVectorInXZ(v4)) {
			v4 = null;
		}

		if (v5 != null && !IsVectorInXY(v5)) {
			v5 = null;
		}

		if (v6 != null && !IsVectorInXY(v6)) {
			v6 = null;
		}

		Vector3? vector = null;
		var distance = float.MaxValue;

		foreach (var v in new[] {v1, v2, v3, v4, v5, v6}) {
			if (v == null) continue;
			var d = pos1.DistanceSquared(v);
			if (!(d < distance)) continue;
			vector = v;
			distance = d;
		}

		if (vector == null) {
			return null;
		}

		Direction f;

		if (vector == v1) {
			f = Direction.West;
		}
		else if (vector == v2) {
			f = Direction.East;
		}
		else if (vector == v3) {
			f = Direction.Down;
		}
		else if (vector == v4) {
			f = Direction.Up;
		}
		else if (vector == v5) {
			f = Direction.North;
		}
		else if (vector == v6) {
			f = Direction.South;
		}
		else {
			//TODO: This should never happen.
			throw new Exception("No face found.");
		}

		return new RayTraceResult(this, f, vector);
	}

	public override string ToString() {
		return "AxisAlignedBB(minX=" + MinX + ", minY=" + MinY + ", minZ=" + MinZ + ", maxX=" + MaxX + ", maxY=" +
		       MaxY + ", maxZ=" + MaxZ + ")";
	}

	/*
	 * Returns a 1x1x1 bounding box starting at grid position 0,0,0.
	 */
	public static AxisAlignedBB One() {
		return new AxisAlignedBB(0, 0, 0, 1, 1, 1);
	}

	private AxisAlignedBB Clone() {
		return new AxisAlignedBB(MinY, MinZ, MinX, MaxY, MaxZ, MaxX);
	}
}