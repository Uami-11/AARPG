using Godot;

public partial class Interactions : Node2D
{
    [Export]
    public Player player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player.DirectionChanged += UpdateDirection;
    }

    public void UpdateDirection(Vector2 newDirection)
    {
        if (newDirection == Vector2.Down)
            RotationDegrees = 0;
        else if (newDirection == Vector2.Up)
            RotationDegrees = 180;
        else if (newDirection == Vector2.Right)
            RotationDegrees = 270;
        else if (newDirection == Vector2.Left)
            RotationDegrees = 90;
    }
}
