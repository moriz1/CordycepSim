using UnityEngine;
using System.Collections;

public class TickableInheritanceTest : Tickable {

	void Start() {
		ID++;
		id = ID;
		tickableName = "TickableInheritanceTest";
	}

	private void OtherTickTest(float speed) {
		Debug.Log ("ID: " + id + ", " + tickableName + " running OtherTickTest! With speed: " + speed);
	}

	public override void OnTickAction(float speed) {
		OtherTickTest (speed);
	}
}
