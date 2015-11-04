using UnityEngine;
using System.Collections;

public enum GameState : int {
	MainMenu = 0,
	Loading,
	InGame,
	Paused,
	Closing
}

public class GameStateManager : MonoBehaviour {

	public static GameStateManager Instance = null;

	public GameState State { get; private set; }

	void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		}
		else if (Instance != null) {
			Destroy(gameObject);
		}
	}

	public void SetGameState(GameState state) {
		State = state;

		toggleGameStates ();
	}

	private void toggleGameStates() {
		switch (State) {
		case GameState.MainMenu:
			Application.LoadLevel("MainMenu");
			break;
		case GameState.Loading:
			Application.LoadLevel("Loading");
			break;
		case GameState.InGame:
			Application.LoadLevel("Game");
			break;
		case GameState.Paused:
			Debug.Log("Paused");
			break;
		case GameState.Closing:
		default:
			Application.LoadLevel("Loading");
			break;
		}
	}
}
