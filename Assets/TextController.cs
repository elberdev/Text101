using UnityEngine;
using UnityEngine.UI; // needs to be here any time we use UI elements
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	// enum containing the states for our state machine
	private enum States { Cell, Mirror, Sheets_0, Lock_0, Cell_Mirror, Sheets_1, Lock_1, Freedom };
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.Cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.Cell) {
			State_Cell ();
		} else if (myState == States.Sheets_0) {
			State_Sheets_0 ();
		}
	}

	void State_Cell() {
		text.text = "You are in a prison cell and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the " +
					"door is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, or L to check the door Lock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.Sheets_0;
		}
	}

	void State_Sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.Cell;
		}
	}
}
