using UnityEngine;
using System.Collections;

[System.Serializable]
public class TickableInheritanceTest : Tickable {

	public TickableInheritanceTest() : base() { }

	public TickableInheritanceTest(string n) : base(n) { }

	private void OtherTickTest(float speed) {
		Debug.Log ("ID: " + ID + ", " + tickableName + " running OtherTickTest! With speed: " + speed);
	}

	public override void OnTickAction(float speed) {
		OtherTickTest (speed);
	}
}
