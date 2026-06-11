using Godot;

public partial class Player : CharacterBody2D
{
    [ExportCategory("Player Nodes")]
    [Export]
    public AnimatedSprite2D sprite;

    [Export]
    public PlayerStateMachine stateMachine;

    [ExportCategory("Player Values")]
    [Export]
    public Vector2 cardinalDirection = Vector2.Down;

    public Vector2 direction = Vector2.Zero;

    [Signal]
    public delegate void DirectionChangedEventHandler(Vector2 newDirection);

    public override void _Ready()
    {
        stateMachine.Initialize(this);
    }

    public override void _Process(double delta)
    {
        direction.X = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        direction.Y = Input.GetActionStrength("down") - Input.GetActionStrength("up");

        direction = direction.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    public bool SetDirection()
    {
        Vector2 newDirection = cardinalDirection;
        if (direction == Vector2.Zero)
        {
            return false;
        }
        if (direction.Y == 0)
        {
            newDirection = (direction.X < 0) ? Vector2.Left : Vector2.Right;
        }
        else if (direction.X == 0)
        {
            newDirection = (direction.Y < 0) ? Vector2.Up : Vector2.Down;
        }

        if (newDirection == cardinalDirection)
        {
            return false;
        }

        cardinalDirection = newDirection;
        EmitSignal(SignalName.DirectionChanged, cardinalDirection);
        if (cardinalDirection == Vector2.Left)
        {
            sprite.FlipH = true;
        }
        else
        {
            sprite.FlipH = false;
        }
        return true;
    }

    public void UpdateAnimation(string state)
    {
        sprite.Play(state + "_" + AnimDirection());
    }

    public string AnimDirection()
    {
        if (cardinalDirection == Vector2.Down)
        {
            return "down";
        }
        else if (cardinalDirection == Vector2.Up)
        {
            return "up";
        }
        else
        {
            return "side";
        }
    }
}
