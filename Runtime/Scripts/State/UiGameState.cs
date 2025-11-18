using UnityEngine;

namespace MoodyLib.GameStateManager {

    /// <summary>
    /// A simple <see cref="IGameState"/> implementation that activates or deactivates
    /// a UI GameObject when entering or exiting the state.
    /// 
    /// This is useful for menu screens, overlays, HUD variations, or any UI element
    /// that should only be visible while a specific state is active.
    /// </summary>
    public class UiGameState : IGameState {
        private readonly GameObject _uiElementRoot;

        /// <summary>
        /// Creates a UI state that toggles the given UI GameObject.
        /// </summary>
        /// <param name="uiElementRoot">
        /// The root GameObject of the UI element to enable and disable.
        /// </param>
        public UiGameState(GameObject uiElementRoot) {
            _uiElementRoot = uiElementRoot;
        }

        /// <summary>
        /// Activates the assigned UI GameObject when this state becomes active.
        /// </summary>
        public void OnStateEnter() {
            _uiElementRoot.SetActive(true);
        }

        /// <summary>
        /// Deactivates the assigned UI GameObject when this state stops being active.
        /// </summary>
        public void OnStateExit() {
            _uiElementRoot.SetActive(false);
        }
    }
}