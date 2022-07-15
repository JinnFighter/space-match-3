using Assets.Scripts.Logic.Models;

public class ModelsContainer
{
    public GameFieldModel GameFieldModel { get; private set; } = new GameFieldModel();
    public SelectedTilesModel SelectedTilesModel { get; private set; } = new SelectedTilesModel();
}
