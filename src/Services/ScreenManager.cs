using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PolyhydraGames.MonoGame.Interfaces;

namespace PolyhydraGames.MonoGame.Services;

/// <summary>
/// Holds the current state of the game
/// </summary>
public class ScreenManager
{
    protected ContentManager _content;
    protected SpriteBatch _spriteBatch;
    protected Vector2 _boundaryDimension;
    protected SoundManager _sfx;
    protected readonly IGameInterface _gameInterface;
    protected readonly IDrawHelper _drawHelper;
    public IGameState CurrentState { get; set; }


    public ScreenManager(ContentManager content, SpriteBatch spriteBatch, Vector2 boundaryDimension, SoundManager sfx, IGameInterface gameInterface, IDrawHelper drawHelper)
    {
        _content = content;
        _spriteBatch = spriteBatch;
        _boundaryDimension = boundaryDimension;
        _sfx = sfx;
        _gameInterface = gameInterface;
        _drawHelper = drawHelper;
    }

    //public void SetState(GameState state)
    //{
    //    switch (state)
    //    {
    //        case GameState.Loading:
    //            CurrentState = new LoadScreen(this, _content, _spriteBatch, _gameInterface, _boundaryDimension, _sfx, _drawHelper);
    //            break;
    //        case GameState.Title:
    //            CurrentState = new TitleScreen(this, _content, _spriteBatch, _gameInterface, _boundaryDimension, _sfx, _drawHelper);
    //            break;
    //        case GameState.Help:
    //            CurrentState = new HelpScreen(this, _content, _spriteBatch, _gameInterface, _boundaryDimension, _sfx, _drawHelper);
    //            break;
    //        case GameState.Story:
    //            CurrentState = new StoryScreen(this, _content, _spriteBatch, _gameInterface, _boundaryDimension, _sfx, _drawHelper);
    //            break;
    //        case GameState.Game:
    //            CurrentState = new ActiveScreen(this, _content, _spriteBatch, _gameInterface, _boundaryDimension, _sfx, _drawHelper);
    //            break;
    //        case GameState.Credits:
    //            CurrentState = new CreditsScreen(this, _content, _spriteBatch, _gameInterface, _boundaryDimension, _sfx, _drawHelper);
    //            break;
    //        case GameState.Test:
    //        case GameState.GameOver:
    //        default:
    //            throw new ArgumentOutOfRangeException(nameof(state), state, null);
    //    }
    //}
}