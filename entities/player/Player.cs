using Godot;

public partial class Player : CharacterBody2D
{
    public Vector2[] DIR = new Vector2[] { Vector2.Right, Vector2.Down, Vector2.Left, Vector2.Up };

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
        if (direction == Vector2.Zero)
        {
            return false;
        }

        int directionID = (int)(Mathf.Round((direction.Angle() / float.Tau * DIR.Length)));

        Vector2 newDirection = DIR[directionID];

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
