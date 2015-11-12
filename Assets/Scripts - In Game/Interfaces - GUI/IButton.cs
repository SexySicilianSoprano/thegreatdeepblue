using UnityEngine;
using System.Collections;

public interface IButton 
{
	bool Selected { get; }
	
	void Execute();
	void ChangeStyle(GUIStyle style);
}
