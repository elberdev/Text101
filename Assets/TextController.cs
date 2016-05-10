using UnityEngine;
using UnityEngine.UI; // needs to be here any time we use UI elements
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	// enum containing the states for our state machine
	private enum States { 
		Cell, Mirror, Sheets_0, Lock_0, Cell_Mirror, Sheets_1, Lock_1, Corridor_0,
		Stairs_0, Stairs_1, Stairs_2, Courtyard, Floor, Corridor_1, Corridor_2,
		Corridor_3, Closet_Door, In_Closet
	};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.Cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if      (myState == States.Cell)        { Cell (); } 
		else if (myState == States.Sheets_0)    { Sheets_0 (); } 
		else if (myState == States.Sheets_1)    { Sheets_1 (); } 
		else if (myState == States.Lock_0) 	    { Lock_0 (); } 
		else if (myState == States.Lock_1)      { Lock_1 (); } 
		else if (myState == States.Mirror)      { Mirror (); } 
		else if (myState == States.Cell_Mirror) { Cell_Mirror (); } 
		else if (myState == States.Corridor_0)  { Corridor_0 (); }
		else if (myState == States.Corridor_1) 	{ Corridor_1 (); } 
		else if (myState == States.Corridor_2)  { Corridor_2 (); } 
		else if (myState == States.Corridor_3)  { Corridor_3 (); } 
		else if (myState == States.Stairs_0) 	{ Stairs_0 (); } 
		else if (myState == States.Stairs_1)  	{ Stairs_1 (); }
		else if (myState == States.Stairs_2) 	{ Stairs_2 (); } 
		else if (myState == States.Courtyard)   { Courtyard (); } 
		else if (myState == States.Floor)       { Floor (); } 
		else if (myState == States.Closet_Door) { Closet_Door (); } 
		else if (myState == States.In_Closet)   { In_Closet (); }
	}

	#region State handler methods
	void Cell() {
		text.text = "You are in a prison cell and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the " +
					"door is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, or L to check the door Lock.";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{ myState = States.Sheets_0; }
		else if (Input.GetKeyDown(KeyCode.M)) 	{ myState = States.Mirror; }
		else if (Input.GetKeyDown(KeyCode.L)) 	{ myState = States.Lock_0; }
	}

	void Sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Cell; }
	}

	void Sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Cell_Mirror; }
	}

	void Lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were--maybe that would help.\n\n" +
					"Press R to Return to roaming your cell.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Cell; }
	}

	void Lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make our fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open the door, or R to Retreat back into the safety of your cell.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Cell_Mirror; } 
		else if (Input.GetKeyDown (KeyCode.O))  { myState = States.Corridor_0; }
	}
	 
	void Mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to roaming the cell.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Cell; } 
		else if (Input.GetKeyDown (KeyCode.T)) 	{ myState = States.Cell_Mirror; }
	}

	void Cell_Mirror() {
		text.text = "You are still in your cell and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock.";
		if 		(Input.GetKeyDown (KeyCode.S)) 	{ myState = States.Sheets_1; } 
		else if (Input.GetKeyDown (KeyCode.L)) 	{ myState = States.Lock_1; }
	}

	void Corridor_0() {
		text.text = "You're out of your cell, but not out of trouble." +
					"You are in the corridor, there's a closet and there are some stairs " +
					"leading to the courtyard. There's also various detritus on the floor.\n\n" +
					"Press C to view the Closet, F to inspect the Floor, or S to climb the stairs.";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{ myState = States.Stairs_0; }
		else if (Input.GetKeyDown(KeyCode.F))  	{ myState = States.Floor; }
		else if (Input.GetKeyDown(KeyCode.C)) 	{ myState = States.Closet_Door;}
	}

	void Corridor_1() {
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
					"Now what? You wonder if that lock on the closet would succumb " + 
					"to some lock-picking?\n\n" +
					"Press P to Pick the lock, or S to climb the Stairs.";
		if 		(Input.GetKeyDown (KeyCode.P)) 	{ myState = States.In_Closet; } 
		else if (Input.GetKeyDown (KeyCode.S)) 	{ myState = States.Stairs_1; }
	}

	void Corridor_2() {
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
					"Press C to revisit the Closet, or S to climb the stairs.";
		if 		(Input.GetKeyDown (KeyCode.C)) 	{ myState = States.In_Closet; } 
		else if (Input.GetKeyDown (KeyCode.S)) 	{ myState = States.Stairs_2; }
	}

	void Corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press S to take the Stairs, or U to Undress.";
		if 		(Input.GetKeyDown (KeyCode.U)) 	{ myState = States.In_Closet; } 
		else if (Input.GetKeyDown (KeyCode.S)) 	{ myState = States.Courtyard; }
	}

	void Stairs_0() {
		text.text = "You start walking up the stairs towards the outside light. " +
					"You realize it's not break time, and you'll be caught immediately. " +
					"You slither back down the stairs and reconsider.\n\n" +
					"Press R to Return to the corridor.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Corridor_0; } 
	}

	void Stairs_1() {
		text.text = "Unfortunately, wielding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press R to Retreat down the stairs.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Corridor_1; } 	
	}

	void Stairs_2() {
		text.text = "You feel smug for picking the closet dooor open and are still armed with " +
					"a hairclip (now badly bent). Even these achievements together don't give " +
					"you the courage to climb up the stairs to your death!\n\n" +
					"Press R to Return to the corridor.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Corridor_2; } 	
	}

	void Courtyard() {
		text.text = "You walk through the courtyard dressed as a cleaner. " +
					"The guard tips his hat at you as you waltz past, claiming " + 
					"your freedom. You heart races but you walk defiantly into the sunset.\n\n" + 
					"Press P to Play again." ;
		if 		(Input.GetKeyDown(KeyCode.P)) 	{ myState = States.Cell; }
	}

	void Floor() {
		text.text = "Rummaging around on the dirty floor, you find a hairclip.\n\n" + 
					"Press S to Stand back up, or H to take the Hairclip." ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{ myState = States.Corridor_0; }
		else if (Input.GetKeyDown(KeyCode.H)) 	{ myState = States.Corridor_1; }
	}

	void Closet_Door() {
		text.text = "You are looking at a closet door which is unfortunately locked. " +
					"Maybe you could find something around to help encourage it open?\n\n" +
					"Press R to Return to the corridor.";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Corridor_0; } 
	}

	void In_Closet() {
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press D to Dress up, or R to Return to the corridor.";
		if 		(Input.GetKeyDown (KeyCode.D)) 	{ myState = States.Corridor_3; } 
		else if (Input.GetKeyDown (KeyCode.R)) 	{ myState = States.Corridor_2; }
	}
	#endregion
}
