using Godot;

public partial class Player : CharacterBody2D
{
    public Vector2[] DIR = new Vector2[] { Vector2.Right, Vector2.Down, Vector2.Left, Vector2.Up };

    [ExportCategory("Player Nodes")]
    [Export]
    public AnimationPlayer animationPlayer;

    [Export]
    public Sprite2D sprite;

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
        GlobalPlayerManager.Instance.player = this;
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
            return false;

        int directionID;
        bool isHoriz = cardinalDirection == Vector2.Left || cardinalDirection == Vector2.Right;

        if (isHoriz && direction.X != 0)
            directionID = direction.X > 0 ? 0 : 2;
        else if (!isHoriz && direction.Y != 0)
            directionID = direction.Y > 0 ? 1 : 3;
        else if (Mathf.Abs(direction.X) > Mathf.Abs(direction.Y))
            directionID = direction.X > 0 ? 0 : 2;
        else
            directionID = direction.Y > 0 ? 1 : 3;

        Vector2 newDirection = DIR[directionID];

        if (newDirection == cardinalDirection)
            return false;

        cardinalDirection = newDirection;
        EmitSignal(SignalName.DirectionChanged, cardinalDirection);

        float newX = (cardinalDirection == Vector2.Left) ? -1f : 1f;
        sprite.Scale = new Vector2(newX, sprite.Scale.Y);

        return true;
    }

    public void UpdateAnimation(string state)
    {
        animationPlayer.Play(state + "_" + AnimDirection());
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
