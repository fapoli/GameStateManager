namespace MoodyLib.GameStateManager {

    /// <summary>
    /// Represents a game state used by the <see cref="AbstractGameStateManager"/>.
    /// 
    /// Each state must define what happens when it becomes active (OnStateEnter)
    /// and when it stops being active (OnStateExit). These methods are triggered
    /// automatically when the state is pushed onto or popped from the state stack.
    /// 
    /// Implementations should be lightweight and avoid expensive initialization
    /// inside constructors, since instances may be created frequently.
    /// </summary>
    public interface IGameState {
        
        /// <summary>
        /// Called when the state becomes the active state.
        /// Use this to initialize UI, gameplay mode, input bindings, etc.
        /// </summary>
        void OnStateEnter();

        /// <summary>
        /// Called when the state is no longer the active state.
        /// Use this to clean up UI, disable systems, or revert changes done on enter.
        /// </summary>
        void OnStateExit();
    }
}