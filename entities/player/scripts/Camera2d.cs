using Godot;

public partial class Camera2d : Camera2D
{
    public override void _Ready()
    {
        GlobalLevelManager.Instance.TilemapBoundsChanged += UpdateLimits;
        UpdateLimits(GlobalLevelManager.Instance.currentTilemapBounds);
    }

    public void UpdateLimits(Vector2[] bounds)
    {
        LimitLeft = (int)(bounds[0].X);
        LimitTop = (int)(bounds[0].Y);
        LimitRight = (int)(bounds[1].X);
        LimitBottom = (int)(bounds[1].Y);
    }
}
