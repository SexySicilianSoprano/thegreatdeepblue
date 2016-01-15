using UnityEngine;
using System.Collections;
using System;

public abstract class KeyBoardEventArgs : EventArgs {

	public KeyCode Key;
	protected bool KeyDown = true;	
	
	public abstract void Command();
}
