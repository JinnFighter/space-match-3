using Assets.Scripts.Common;
using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Controllers;
using Assets.Scripts.Logic.Models;

public class GameFieldInit : IInit
{
    public void Init(IGame game)
    {
        var gameFieldDescription = game.DescriptionContent.GameFieldDescription;
        var gameFieldModel = game.ModelsContainer.GameFieldModel;
        gameFieldModel.Tiles = new TileModel[gameFieldDescription.Width, gameFieldDescription.Height];

        for(var i = 0; i < gameFieldDescription.Width; i++)
        {
            for (var j = 0; j < gameFieldDescription.Height; j++)
            {
                gameFieldModel.Tiles[i, j] = new TileModel { Position = new(i, j) };
            }
        }

        game.ControllerContainer.Add(new CompositeController(new System.Collections.Generic.List<IController>
        {
            new TileSelectionController(gameFieldModel, game.ModelsContainer.SelectedTilesModel),
            new GameFieldContentController(gameFieldModel, game.ModelsContainer.SelectedTilesModel, game.PrefabsContent, game.ViewContainer),
        }));
    }
}
