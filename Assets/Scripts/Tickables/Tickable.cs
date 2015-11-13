using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tickable {
	//protected static int counter = 0;

	protected string tickableName = "Tickable";

	public int ID { get; set; }
	public string TickableName { get { return tickableName; } }

	public Tickable() {
		//this.ID = System.Threading.Interlocked.Increment (ref counter);
	}

	public Tickable(string n) : this() {
		tickableName = n;
	}

	private void TickTest(float speed) {
		Debug.Log ("TickTest Complete on " + tickableName + " ID: " + ID + " with speed: " + speed);

		if (tickableName != "Tickable") {
			Debug.LogWarning ("ID: " + ID + " Make sure to overload OnTickAction!");
		}
	}

	public virtual void OnTickAction(float speed) {
		TickTest (speed);
	}
}
