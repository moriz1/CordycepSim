using UnityEngine;
using System.Collections;

public class TickableContainer : MonoBehaviour {

	public Tickable tickable;
	public string Name = "Tickable";

	//public int ID { get { return tickable.ID; } }

	void Start() {
		tickable = new Tickable(Name);

		if (GameStateManager.Instance != null) {
			tickable.ID = GameStateManager.Instance.Tickables.Count;
			GameStateManager.Instance.Tickables.Add (tickable);
		}
	}

	void OnEnable() {
		Ticker.OnTick += OnTickAction;
	}

	void OnDisable() {
		Ticker.OnTick -= OnTickAction;
	}

	public void OnTickAction(float speed) {
		tickable.OnTickAction(speed);
	}
}
