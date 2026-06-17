using Godot;

public partial class Plant : Node2D
{
    [Export]
    public HitBox hitbox;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        hitbox.Damaged += TakeDamage;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public void TakeDamage(HurtBox hurtBox)
    {
        QueueFree();
    }
}
