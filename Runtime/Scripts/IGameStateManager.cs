using MoodyLib.GameStateManager;

/// <summary>
/// Interface for classes that manage a stack-based game state machine.
/// Allows pushing and popping states and exposing the active state.
/// Designed to be used with dependency injection or service locator patterns.
/// </summary>
public interface IGameStateManager {

    /// <summary>
    /// The state currently at the top of the stack, or null if no state is active.
    /// </summary>
    IGameState current { get; }

    /// <summary>
    /// Pushes a new state onto the stack, transitioning from the previous active state.
    /// </summary>
    void Push(IGameState state);

    /// <summary>
    /// Pops the current state and returns to the previous one.
    /// </summary>
    void Pop();
}