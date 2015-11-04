using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour {

	public GameObject gameStateManager;

	void Awake() {
		if (GameStateManager.Instance == null) {
			Instantiate(gameStateManager);
		}
	}

	void Start() {
		GameStateManager.Instance.SetGameState (GameState.MainMenu);
	}
}
