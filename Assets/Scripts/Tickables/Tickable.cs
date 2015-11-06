using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tickable : MonoBehaviour {
	public static int ID = -1;
	protected int id;

	protected string tickableName;

	void Start() {
		ID++;
		id = ID;
		tickableName = "Tickable";
	}

	void OnEnable() {
		Ticker.OnTick += OnTickAction;
	}

	void OnDisable() {
		Ticker.OnTick -= OnTickAction;
	}

	private void TickTest(float speed) {
		Debug.Log ("TickTest Complete on " + tickableName + " ID: " + id + " with speed: " + speed);

		if (tickableName != "Tickable") {
			Debug.LogWarning ("ID: " + id + " Make sure to overload OnTickAction!");
		}
	}

	public virtual void OnTickAction(float speed) {
		TickTest (speed);
	}
}
