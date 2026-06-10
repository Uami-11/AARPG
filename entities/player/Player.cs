using Godot;

public partial class Player : CharacterBody2D
{
    [ExportCategory("Player Values")]
    [Export]
    public float moveSpeed = 100.0f;

    public override void _Ready() { }

    public override void _Process(double delta)
    {
        Vector2 direction = Vector2.Zero;

        direction.X = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        direction.Y = Input.GetActionStrength("down") - Input.GetActionStrength("up");

        Velocity = direction * moveSpeed;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
}
