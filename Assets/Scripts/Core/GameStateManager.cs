using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState : int {
	MainMenu = 0,
	Loading,
	InGame,
	Paused,
	Closing
}

[System.Serializable]
public class Game {
	public static Game Current;
	public string GameName;
	public float SimulationSpeed;
	public int CurrentTick;

	public List<Tickable> Tickables;
	
	public Game(float simSpeed = 6.0f, int currentTick = 0) {
		Tickables = new List<Tickable> ();
		SimulationSpeed = simSpeed;
		CurrentTick = currentTick;
		GameName = "DefaultName";
	}
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
		SetGameStateInternal (state);

		toggleGameStates ();
	}

	public void SetGameStateInternal(GameState state) {
		State = state;
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
			//Application.LoadLevel("Loading");
			Application.Quit();
			break;
		}
	}


}
