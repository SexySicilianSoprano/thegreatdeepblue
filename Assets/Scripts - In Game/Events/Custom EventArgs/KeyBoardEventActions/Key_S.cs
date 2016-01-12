using UnityEngine;
using System.Collections;

public class Key_X : KeyBoardEventArgs {

	public Key_X() : base(KeyCode.X)
	{
		
	}
	
	public Key_X(bool keyDown, bool keyUp) : base(KeyCode.X, keyDown, keyUp)
	{

	}

	public override void Command()
	{
		selectedManager.GiveOrder (Orders.CreateStopOrder ());
	}
}
