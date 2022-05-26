namespace SkyWing.Math;

public class Vector2 {

	public float X {
		get => _x;
		set => _x = value;
	}

	public int FloorX => (int) MathF.Floor(_x);

	public float Y {
		get => _y;
		set => _y = value;
	}
	
	public int FloorY => (int) MathF.Floor(_y);

	private float _x;
	private float _y;
	
	public Vector2(float x, float y) {
		_x = x;
		_y = y;
	}

	public static Vector2 operator +(Vector2 a, Vector2 b) {
		return new Vector2(a.X + b.X, a.Y + b.Y);
	}
	
	public static Vector2 operator +(Vector2 a, float b) {
		return new Vector2(a.X + b, a.Y + b);
	}
	
	public static Vector2 operator -(Vector2 a, Vector2 b) {
		return new Vector2(a.X - b.X, a.Y - b.Y);
	}
	
	public static Vector2 operator -(Vector2 a, float b) {
		return new Vector2(a.X - b, a.Y - b);
	}
	
	public static Vector2 operator *(Vector2 a, float b) {
		return new Vector2(a.X * b, a.Y * b);
	}
	
	public static Vector2 operator /(Vector2 a, float b) {
		return new Vector2(a.X / b, a.Y / b);
	}
	
	public static Vector2 Zero() => new Vector2(0, 0);

	public Vector2 Add(float x, float y) {
		return new Vector2(_x + x, _y + y);
	}
	
	public Vector2 Add(Vector2 v) {
		return Add(v.X, v.Y);
	}
	
	public Vector2 Subtract(float x, float y) {
		return new Vector2(_x - x, _y - y);
	}
	
	public Vector2 Subtract(Vector2 v) {
		return Subtract(v.X, v.Y);
	}
	
	public Vector2 Multiply(float v) {
		return new Vector2(_x * v, _y * v);
	}

	public Vector2 Divide(float v) {
		return new Vector2(_x / v, _y / v);
	}

	public Vector2 Ceiling() {
		return new Vector2((float) System.Math.Ceiling(_x), (float) System.Math.Ceiling(_y));
	}
	
	public Vector2 Floor() {
		return new Vector2((float) System.Math.Floor(_x), (float) System.Math.Floor(_y));
	}
	
	public Vector2 Round() {
		return new Vector2((float) System.Math.Round(_x), (float) System.Math.Round(_y));
	}
	
	public Vector2 Abs() {
		return new Vector2(System.Math.Abs(_x), System.Math.Abs(_y));
	}

	public float Distance(Vector2 pos) {
		return (float) System.Math.Sqrt(DistanceSquared(pos));
	}
	
	public float DistanceSquared(Vector2 pos) {
		return (float) (System.Math.Pow(_x - pos.X, 2) + System.Math.Pow(_y - pos.Y, 2));
	}
	
	public float Length() {
		return (float) System.Math.Sqrt(LengthSquared());
	}

	public float LengthSquared() {
		return _x * _x + _y * _y;
	}
	
	public Vector2 Normalize() {
		var len = Length();
		return len > 0 ? Divide(len) : Zero();
	}

	public float Dot(Vector2 v) {
		return _x * v.X + _y * v.Y;
	}

	public override string ToString() {
		return "Vector2(x=" + _x + ", y=" + _y + ")";
	}
	
	public bool Equals(Vector2 that) {
		return _x.Equals(that.X) && _y.Equals(that.Y);
	}
	
	public static Vector2 MinComponents(Vector2 a) {
		return MinComponents(a, new Vector2[] { });
	}
	
	public static Vector2 MinComponents(Vector2 a, IEnumerable<Vector2> vectors) {
		var x = a.X;
		var y = a.Y;
		foreach (var v in vectors) {
			x = System.Math.Min(x, v.X);
			y = System.Math.Min(y, v.Y);
		}
		return new Vector2(x, y);
	}
	
	public static Vector2 MaxComponents(Vector2 a) {
		return MaxComponents(a, Array.Empty<Vector2>());
	}
	
	public static Vector2 MaxComponents(Vector2 a, IEnumerable<Vector2> vectors) {
		var x = a.X;
		var y = a.Y;
		foreach (var v in vectors) {
			x = System.Math.Max(x, v.X);
			y = System.Math.Max(y, v.Y);
		}
		return new Vector2(x, y);
	}
	
	public static Vector2 Sum(Vector2 a, IEnumerable<Vector3> vectors) {
		var x = a.X;
		var y = a.Y;
		foreach (var v in vectors) {
			x += v.X;
			y += v.Y;
		}
		return new Vector2(x, y);
	}
	
}

public class Vector3 {

	public float X {
		get => _x;
		set => _x = value;
	}

	public int FloorX => (int) MathF.Floor(_x);

	public float Y {
		get => _y;
		set => _y = value;
	}

	public int FloorY => (int) MathF.Floor(_y);

	public float Z {
		get => _z;
		set => _z = value;
	}

	public int FloorZ => (int) MathF.Floor(_z);

	private float _x;
	private float _y;
	private float _z;

	public Vector3(float x, float y, float z) {
		_x = x;
		_y = y;
		_z = z;
	}

	public static Vector3 operator +(Vector3 a, Vector3 b) {
		return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
	}

	public static Vector3 operator +(Vector3 a, float b) {
		return new Vector3(a.X + b, a.Y + b, a.Z + b);
	}

	public static Vector3 operator -(Vector3 a, Vector3 b) {
		return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
	}

	public static Vector3 operator -(Vector3 a, float b) {
		return new Vector3(a.X - b, a.Y - b, a.Z - b);
	}

	public static Vector3 operator *(Vector3 a, float b) {
		return new Vector3(a.X * b, a.Y * b, a.Z * b);
	}

	public static Vector3 operator /(Vector3 a, float b) {
		return new Vector3(a.X / b, a.Y / b, a.Z / b);
	}

	public static Vector3 Zero() => new Vector3(0, 0, 0);

	public Vector3 Add(float x, float y, float z) {
		return new Vector3(_x + x, _y + y, _z + z);
	}

	public Vector3 Add(Vector3 v) {
		return Add(v.X, v.Y, v.Z);
	}

	public Vector3 Subtract(float x, float y, float z) {
		return new Vector3(_x - x, _y - y, _z - z);
	}

	public Vector3 Subtract(Vector3 v) {
		return Subtract(v.X, v.Y, v.Z);
	}

	public Vector3 Multiply(float v) {
		return new Vector3(_x * v, _y * v, _z * v);
	}

	public Vector3 Divide(float v) {
		return new Vector3(_x / v, _y / v, _z / v);
	}

	public Vector3 Ceiling() {
		return new Vector3((float) System.Math.Ceiling(_x), (float) System.Math.Ceiling(_y),
			(float) System.Math.Ceiling(_z));
	}

	public Vector3 Floor() {
		return new Vector3((float) System.Math.Floor(_x), (float) System.Math.Floor(_y), (float) System.Math.Floor(_z));
	}

	public Vector3 Round(int precision = 2) {
		return new Vector3((float) System.Math.Round(_x, precision), (float) System.Math.Round(_y, precision),
			(float) System.Math.Round(_z, precision));
	}

	public Vector3 Abs() {
		return new Vector3(System.Math.Abs(_x), System.Math.Abs(_y), System.Math.Abs(_z));
	}

	public Vector3 GetSide(Direction side, int step = 1) {
		return side switch {
			Direction.Down => new Vector3(_x, _y - step, _z),
			Direction.Up => new Vector3(_x, _y + step, _z),
			Direction.North => new Vector3(_x, _y, _z - step),
			Direction.South => new Vector3(_x, _y, _z + step),
			Direction.West => new Vector3(_x - step, _y, _z),
			Direction.East => new Vector3(_x + step, _y, _z),
			_ => this
		};
	}

	public Vector3 Down(int step = 1) {
		return GetSide(Direction.Down, step);
	}

	public Vector3 Up(int step = 1) {
		return GetSide(Direction.Up, step);
	}

	public Vector3 North(int step = 1) {
		return GetSide(Direction.North, step);
	}

	public Vector3 South(int step = 1) {
		return GetSide(Direction.South, step);
	}

	public Vector3 West(int step = 1) {
		return GetSide(Direction.West, step);
	}

	public Vector3 East(int step = 1) {
		return GetSide(Direction.East, step);
	}

	public float Distance(Vector3 pos) {
		return (float) System.Math.Sqrt(DistanceSquared(pos));
	}

	public float DistanceSquared(Vector3 pos) {
		return (float) (System.Math.Pow(_x - pos.X, 2) + System.Math.Pow(_y - pos.Y, 2) +
		                System.Math.Pow(_z - pos.Z, 2));
	}

	public float Length() {
		return (float) System.Math.Sqrt(LengthSquared());
	}

	public float LengthSquared() {
		return _x * _x + _y * _y + _z * _z;
	}

	public Vector3 Normalize() {
		var len = Length();
		return len > 0 ? Divide(len) : Zero();
	}

	public float Dot(Vector3 v) {
		return _x * v.X + _y * v.Y + _z * v.Z;
	}

	public Vector3 Cross(Vector3 v) {
		return new Vector3(_y * v.Z - _z * v.Y, _z * v.X - _x * v.Z, _x * v.Y - _y * v.X);
	}

	public override string ToString() {
		return "Vector3(x=" + _x + ", y=" + _y + ", z=" + _z + ")";
	}

	public bool Equals(Vector3 that) {
		return _x.Equals(that.X) && _y.Equals(that.Y) && _z.Equals(that.Z);
	}

	/**
	 * Returns a new vector with x value equal to the second parameter, along the line between this vector and the
	 * passed in vector, or null if not possible.
	 */
	public Vector3? GetIntermediateWithXValue(Vector3 v, float x) {
		var xDiff = v.X - X;
		if ((xDiff * xDiff) < 0.0000001) {
			return null;
		}

		var f = (x - X) / xDiff;

		if (f < 0 || f > 1) {
			return null;
		}

		return new Vector3(x, Y + (v.Y - Y) * f, Z + (v.Z - Z) * f);
	}

	/**
	 * Returns a new vector with y value equal to the second parameter, along the line between this vector and the
	 * passed in vector, or null if not possible.
	 */
	public Vector3? GetIntermediateWithYValue(Vector3 v, float y) {
		var yDiff = v.Y - Y;
		if ((yDiff * yDiff) < 0.0000001) {
			return null;
		}

		var f = (y - Y) / yDiff;

		if (f < 0 || f > 1) {
			return null;
		}

		return new Vector3(X + (v.X - X) * f, y, Z + (v.Z - Z) * f);
	}

	/**
	 * Returns a new vector with z value equal to the second parameter, along the line between this vector and the
	 * passed in vector, or null if not possible.
	 */
	public Vector3? GetIntermediateWithZValue(Vector3 v, float z) {
		var zDiff = v.Z - Z;
		if ((zDiff * zDiff) < 0.0000001) {
			return null;
		}

		var f = (z - z) / zDiff;

		if (f < 0 || f > 1) {
			return null;
		}

		return new Vector3(X + (v.X - X) * f, Y + (v.Y - Y) * f, z);
	}

	public static Vector3 MinComponents(Vector3 a) {
		return MinComponents(a, new Vector3[] { });
	}

	public static Vector3 MinComponents(Vector3 a, IEnumerable<Vector3> vectors) {
		var x = a.X;
		var y = a.Y;
		var z = a.Z;
		foreach (var v in vectors) {
			x = System.Math.Min(x, v.X);
			y = System.Math.Min(y, v.Y);
			z = System.Math.Min(z, v.Z);
		}

		return new Vector3(x, y, z);
	}

	public static Vector3 MaxComponents(Vector3 a) {
		return MaxComponents(a, Array.Empty<Vector3>());
	}

	public static Vector3 MaxComponents(Vector3 a, IEnumerable<Vector3> vectors) {
		var x = a.X;
		var y = a.Y;
		var z = a.Z;
		foreach (var v in vectors) {
			x = System.Math.Max(x, v.X);
			y = System.Math.Max(y, v.Y);
			z = System.Math.Max(z, v.Z);
		}

		return new Vector3(x, y, z);
	}

	public static Vector3 Sum(Vector3 a, IEnumerable<Vector3> vectors) {
		var x = a.X;
		var y = a.Y;
		var z = a.Z;
		foreach (var v in vectors) {
			x += v.X;
			y += v.Y;
			z += v.Z;
		}

		return new Vector3(x, y, z);
	}
}