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
		if      (myState == States.Cell)        { State_Cell (); } 
		else if (myState == States.Sheets_0)    { State_Sheets_0 (); } 
		else if (myState == States.Sheets_1)    { State_Sheets_1 (); } 
		else if (myState == States.Lock_0) 	    { State_Lock_0 (); } 
		else if (myState == States.Lock_1)      { State_Lock_1 (); } 
		else if (myState == States.Mirror)      { State_Mirror (); } 
		else if (myState == States.Cell_Mirror) { State_Cell_Mirror (); } 
		else if (myState == States.Freedom)     { State_Freedom (); }
	}

	void State_Cell() {
		text.text = "You are in a prison cell and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the " +
					"door is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, or L to check the door Lock.";
		if (Input.GetKeyDown(KeyCode.S)) 		{ myState = States.Sheets_0; }
		else if (Input.GetKeyDown(KeyCode.M)) 	{ myState = States.Mirror; }
		else if (Input.GetKeyDown(KeyCode.L)) 	{ myState = States.Lock_0; }
	}

	void State_Sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) 		{ myState = States.Cell; }
	}

	void State_Sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) 		{ myState = States.Cell_Mirror; }
	}

	void State_Lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were--maybe that would help.\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) 		{ myState = States.Cell; }
	}

	void State_Lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make our fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or M to put the Mirror back into the cell.";
		if (Input.GetKeyDown (KeyCode.M)) 		{ myState = States.Cell_Mirror; } 
		else if (Input.GetKeyDown (KeyCode.O))  { myState = States.Freedom; }
	}
	 
	void State_Mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to roaming the cell.";
		if (Input.GetKeyDown (KeyCode.R)) 		{ myState = States.Cell; } 
		else if (Input.GetKeyDown (KeyCode.T)) 	{ myState = States.Cell_Mirror; }
	}

	void State_Cell_Mirror() {
		text.text = "You are still in your cell and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock.";
		if (Input.GetKeyDown (KeyCode.S)) 		{ myState = States.Sheets_1; } 
		else if (Input.GetKeyDown (KeyCode.L)) 	{ myState = States.Lock_1; }
	}

	void State_Freedom() {
		text.text = "YOU ARE FREE!\n\n" +
					"Press P to Play again.";
		if (Input.GetKeyDown(KeyCode.P)) 		{ myState = States.Cell; }
	}
}
