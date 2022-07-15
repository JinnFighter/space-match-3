using Assets.Scripts.Common;
using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Controllers;
using Assets.Scripts.Logic.Models;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldInit : IInit
{
    public void Init(IGame game)
    {
        var tileStatesDescription = game.DescriptionContent.TileStatesDescription;
        var gameFieldDescription = game.DescriptionContent.GameFieldDescription;
        var gameFieldModel = game.ModelsContainer.GameFieldModel;
        gameFieldModel.Tiles = new TileModel[gameFieldDescription.Width, gameFieldDescription.Height];

        for(var i = 0; i < gameFieldDescription.Width; i++)
        {
            for (var j = 0; j < gameFieldDescription.Height; j++)
            {
                gameFieldModel.Tiles[i, j] = new TileModel { Position = new(i, j), State = Random.Range(0, tileStatesDescription.MaxState) };
            }
        }

        game.ControllerContainer.Add(new CompositeController(new List<IController>
        {
            new TileSelectionController(gameFieldModel, game.ModelsContainer.SelectedTilesModel),
            new GameFieldContentController(gameFieldModel, game.ModelsContainer.SelectedTilesModel, game.PrefabsContent, game.ViewContainer),
        }));
    }
}
