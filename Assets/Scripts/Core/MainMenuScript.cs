using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public GameObject CloseButton;

	void Start() {
		if (GameStateManager.Instance == null) {
			GameObject g = new GameObject("GameStateManager");
			g.AddComponent<GameStateManager>();
			Instantiate(g);

			GameStateManager.Instance.SetGameStateInternal(GameState.MainMenu);
		}

		if (Application.platform == RuntimePlatform.OSXPlayer || Application.isEditor
		    || Application.isWebPlayer) {
			if (CloseButton != null) {
				CloseButton.SetActive(false);
			}
		}
	}

	public void StartGameClicked() {
		GameStateManager.Instance.SetGameState(GameState.Loading);
	}

	public void EndGameClicked() {
		GameStateManager.Instance.SetGameState(GameState.Closing);
	}
}
