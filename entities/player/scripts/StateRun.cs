using Godot;

public partial class StateRun : State
{
    [Export]
    public float moveSpeed = 200f;

    [ExportCategory("Other States")]
    [Export]
    public State idle;

    [Export]
    public State attack;

    public override void Enter()
    {
        player.UpdateAnimation("run");
    }

    public override void Exit() { }

    public override State Process(double delta)
    {
        if (player.direction == Vector2.Zero)
            return idle;

        player.Velocity = player.direction * moveSpeed;

        if (player.SetDirection())
            player.UpdateAnimation("run");

        return null;
    }

    public override State Physics(double delta)
    {
        return null;
    }

    public override State HandleInput(InputEvent _event)
    {
        if (_event.IsActionPressed("attack"))
        {
            return attack;
        }
        return null;
    }
}
