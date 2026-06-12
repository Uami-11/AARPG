using Godot;

public partial class Enemy : CharacterBody2D
{
    [Signal]
    public delegate void directionChangedEventHandler(Vector2 newDirection);

    [Signal]
    public delegate void enemyDamagedEventHandler();

    public Vector2[] DIR = new Vector2[] { Vector2.Right, Vector2.Down, Vector2.Left, Vector2.Up };

    [Export]
    public int health = 3;

    public Vector2 cardinalDirection = Vector2.Down;

    public Vector2 direction = Vector2.Zero;

    public Player player;

    public bool invulnerable = false;

    [Export]
    public AnimatedSprite2D sprite;

    [Export]
    public HitBox hitBox;

    [Export]
    public EnemyStateMachine stateMachine;

    public override void _Ready()
    {
        stateMachine.Initialize(this);
        player = GlobalPlayerManager.Instance.player;
    }

    public override void _Process(double delta) { }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    public bool SetDirection(Vector2 newDir)
    {
        direction = newDir;
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
        EmitSignal(SignalName.directionChanged, cardinalDirection);
        if (cardinalDirection == Vector2.Left)
            sprite.FlipH = true;
        else
            sprite.FlipH = false;

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
