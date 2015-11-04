using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void StartGameClicked() {
		if (GameStateManager.Instance != null) {
			GameStateManager.Instance.SetGameState(GameState.Loading);
		}
	}
}
