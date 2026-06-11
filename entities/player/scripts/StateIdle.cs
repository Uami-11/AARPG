using Godot;

public partial class StateIdle : State
{
    [ExportCategory("Other States")]
    [Export]
    public State run;

    [Export]
    public State attack;

    public override void Enter()
    {
        player.UpdateAnimation("idle");
    }

    public override void Exit() { }

    public override State Process(double delta)
    {
        if (player.direction != Vector2.Zero)
            return run;

        player.Velocity = Vector2.Zero;
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
