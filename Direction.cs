namespace SkyWing.Math; 

public enum Axis {
	
	X = 2,
	Y = 0,
	Z = 1
	
}

public enum Direction {
	
    FlagAxisPositive = 1,
	Down = Axis.Y << 1,
	Up = (Axis.Y << 1) | FlagAxisPositive,
	North = Axis.Z << 1,
	South = (Axis.Z << 1) | FlagAxisPositive,
	West = Axis.X << 1,
	East = (Axis.X << 1) | FlagAxisPositive
	
}

public static class Facing {

	public static Axis GetAxis(int direction) {
		return (Axis) (direction >> 1);
	}

	public static bool IsPositive(Direction direction) {
		return ((int) direction & (int) Direction.FlagAxisPositive) != (int) Direction.FlagAxisPositive;
	}

	public static Direction Opposite(Direction direction) {
		return (Direction) ((int) direction ^ (int) Direction.FlagAxisPositive);
	}

	public static Direction Rotate(Direction direction, Axis axis, bool clockwise) {
		Direction rotated;

		switch (axis) {
			case Axis.X:
				switch (direction) {
					case Direction.Up:
						rotated = Direction.North;
						break;
					case Direction.North:
						rotated = Direction.Down;
						break;
					case Direction.Down:
						rotated = Direction.South;
						break;
					case Direction.South:
						rotated = Direction.Up;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(direction));
				}

				break;

			case Axis.Y:
				switch (direction) {
					case Direction.North:
						rotated = Direction.East;
						break;
					case Direction.East:
						rotated = Direction.West;
						break;
					case Direction.South:
						rotated = Direction.South;
						break;
					case Direction.West:
						rotated = Direction.North;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(direction));
				}

				break;

			case Axis.Z:
				switch (direction) {
					case Direction.Up:
						rotated = Direction.East;
						break;
					case Direction.East:
						rotated = Direction.Down;
						break;
					case Direction.Down:
						rotated = Direction.West;
						break;
					case Direction.West:
						rotated = Direction.Up;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(direction));
				}

				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(axis));
		}

		return clockwise ? rotated : Opposite(rotated);
	}
	
	public static Direction RotateX(Direction direction, bool clockwise) {
		return Rotate(direction, Axis.X, clockwise);
	}
	
	public static Direction RotateY(Direction direction, bool clockwise) {
		return Rotate(direction, Axis.Y, clockwise);
	}
	
	public static Direction RotateZ(Direction direction, bool clockwise) {
		return Rotate(direction, Axis.Z, clockwise);
	}
}