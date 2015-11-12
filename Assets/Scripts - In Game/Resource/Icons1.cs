using UnityEngine;
using System.Collections;

/// <summary>
/// Icons. This is a script following the same logic as Strings script class.
/// </summary>

public static class Icons2
{
	/*public const Texture2D B = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_icon1") as Texture2D;
	public const Texture2D Sc = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_icon2") as Texture2D;
	public const Texture2D Sh = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_icon3") as Texture2D;*/

	private static Texture2D m_Icon;

	//Buttoniconitekstuurit
	
	/*public static Texture2D B
	{
		get
		{
			return m_Icon ?? (m_Icon = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_icon1") as Texture2D);
		}
	}*/

	public static Texture2D Sc
	{
		get
		{
			return m_Icon ?? (m_Icon = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_icon2") as Texture2D);
		}
	}

	/*
	public static Texture2D Sh
	{
		get
		{
			return m_Icon ?? (m_Icon = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_icon3") as Texture2D);
		}
	}*/
}
