using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	void Start() {
		if (GameStateManager.Instance == null) {
			GameObject g = new GameObject("GameStateManager");
			g.AddComponent<GameStateManager>();
			Instantiate(g);

			GameStateManager.Instance.SetGameStateInternal(GameState.MainMenu);
		}
	}

	public void StartGameClicked() {
		if (GameStateManager.Instance != null) {
			GameStateManager.Instance.SetGameState(GameState.Loading);
		}
	}
}
