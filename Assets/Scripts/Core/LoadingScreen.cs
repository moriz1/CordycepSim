using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	void Start() {
		StartCoroutine ("FinishLoadingStartGame");
	}

	IEnumerator FinishLoadingStartGame() {
		yield return new WaitForSeconds(3.0f);
		SaveLoader.Load ();
		//Application.LoadLevel ("Game");
		if (GameStateManager.Instance != null) {
			GameStateManager.Instance.SetGameState(GameState.InGame);
		}
	}
}
