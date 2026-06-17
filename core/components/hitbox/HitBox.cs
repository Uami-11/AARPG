using Godot;

public partial class HitBox : Area2D
{
    [Signal]
    public delegate void DamagedEventHandler(HurtBox hurtBox);

    public override void _Ready() { }

    public override void _Process(double delta) { }

    public void TakeDamage(HurtBox hurtbox)
    {
        GD.Print($"Took {hurtbox.damage} damage");
        EmitSignal(SignalName.Damaged, hurtbox);
    }
}
