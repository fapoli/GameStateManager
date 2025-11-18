using System.Collections.Generic;
using UnityEngine;

namespace MoodyLib.GameStateManager {

    /// <summary>
    /// Base class for managing game states using a stack-based state machine.
    /// 
    /// This pattern is useful for layered or temporary states such as menus, pause screens,
    /// cutscenes, dialogues, or overlays. The state at the top of the stack is always the
    /// active state.
    /// 
    /// The manager automatically:
    /// - Pushes the initial state in Awake()
    /// - Calls OnStateExit() on the outgoing state when pushing or popping
    /// - Calls OnStateEnter() on the incoming state
    /// 
    /// Subclasses must override <see cref="GetInitialState"/> to define the first active state.
    /// </summary>
    public abstract class AbstractGameStateManager : MonoBehaviour, IGameStateManager {
        public IGameState current => stateStack.Count > 0 ? stateStack.Peek() : null;

        private readonly Stack<IGameState> stateStack = new Stack<IGameState>();

        protected void Awake() {
            Push(GetInitialState());
        }

        /// <summary>
        /// Returns the initial state that will be pushed when the manager initializes.
        /// 
        /// Subclasses must return a valid instance that implements <see cref="IGameState"/>.
        /// Avoid returning null. This method is called during Awake(), so the returned state
        /// should not rely on scene objects that may not yet be initialized.
        /// 
        /// Example:
        ///     return new MainMenuState();
        /// </summary>
        /// <returns>The initial active state.</returns>
        protected abstract IGameState GetInitialState();

        /// <summary>
        /// Pushes a new state onto the stack. The current active state (if any) receives
        /// OnStateExit(), and the pushed state receives OnStateEnter().
        /// </summary>
        /// <param name="state">The state to activate.</param>
        public void Push(IGameState state) {
            current?.OnStateExit();
            stateStack.Push(state);
            state.OnStateEnter();
        }

        /// <summary>
        /// Pops the current state off the stack. The popped state receives OnStateExit().
        /// If a previous state exists, it becomes active and receives OnStateEnter().
        /// </summary>
        public void Pop() {
            if (stateStack.Count == 0) return;

            var top = stateStack.Pop();
            top?.OnStateExit();

            current?.OnStateEnter();
        }
    }
}
