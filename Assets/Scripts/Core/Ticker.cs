using UnityEngine;
using System.Collections;
using System.IO;

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
			TicksPerMinute = Game.Current.TicksPerMinute;
		}

		//Initialize Tickables!

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

//	private void InitTickables() {
//		int foundTickables = 0;
//
//		int i = 0;
//
//		for (;;) {
//			if (Application.isEditor || Application.isWebPlayer) {
//				if (File.Exists (Application.dataPath + "/SaveData/Tickable" + i + ".xml")) {
//
//				}
//				else {
//					break;
//				}
//			}
//		}
//	}

	void OnApplicationQuit() {
		Game.Current.CurrentTick = Tick;
		Game.Current.TicksPerMinute = TicksPerMinute;
		SaveLoader.Save ();
	}
}
