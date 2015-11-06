using UnityEngine;
using System.Collections;

public delegate void TickAction (float speed);

public class Ticker : MonoBehaviour {

	public float TicksPerMinute = 2.0f;

	public static event TickAction OnTick;

	private static int tick;
	public int Tick {
		get { return tick; }
	}

	void Awake() {
		tick = 0;

		if (Game.Current != null) {
			Debug.Log("loading!");
			tick = Game.Current.CurrentTick;
			TicksPerMinute = Game.Current.SimulationSpeed;
		}
	}
	
	void Start() {
		StartCoroutine ("RunTick");
	}

	IEnumerator RunTick() {
		for (;;) {
			Debug.Log (tick);

			if (OnTick != null) {
				OnTick(TicksPerMinute / 60.0f);
			}

			yield return new WaitForSeconds (60.0f / TicksPerMinute);

			tick++;
		}
	}
}
