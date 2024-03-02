using PolyhydraGames.MonoGame.Services;

namespace PolyhydraGames.MonoGame.Interfaces;

public interface IGameStateFactory
{
    public IGameState GetState(GameState state);
    public void Load(GameState state, Func<IGameState> func);
}

public class GameStateFactory : IGameStateFactory
{
    public Dictionary<GameState, Func<IGameState>> States { get; } = new Dictionary<GameState, Func<IGameState>>();

    public void Load(GameState state, Func<IGameState> func)
    {
        States.Add(state, func);
    }

    public IGameState GetState(GameState state)
    {
        return States[state]();
    }
}