using Godot;

public partial class StateIdle : State
{
    public override void Enter()
    {
        player.UpdateAnimation("idle");
    }

    public override void Exit() { }

    public override State Process(double delta)
    {
        return null;
    }

    public override State Physics(double delta)
    {
        return null;
    }

    public override State HandleInput(InputEvent _event)
    {
        return null;
    }
}
