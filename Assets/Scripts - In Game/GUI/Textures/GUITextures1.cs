using UnityEngine;
using System.Collections;

public static class GUITextures2
{
	private static Texture2D m_TypeButtonNormal;
	private static Texture2D m_TypeButtonHover;
	private static Texture2D m_TypeButtonSelected;
	
	private static Texture2D m_QueueButtonNormal;
	private static Texture2D m_QueueButtonHover;
	private static Texture2D m_QueueButtonSelected;
	
	private static Texture2D m_QueueContentNormal;
	private static Texture2D m_QueueContentHover;
	private static Texture2D m_QueueContentSelected;


	//Building Buttons
	/*public static Texture2D TypeButtonNormalB
	{
		get
		{
			return m_TypeButtonNormal ?? (m_TypeButtonNormal = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_bg1") as Texture2D);
		}
	}
	
	public static Texture2D TypeButtonHoverB
	{
		get
		{
			return m_TypeButtonHover ?? (m_TypeButtonHover = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_bg2") as Texture2D);
		}
	}
	
	public static Texture2D TypeButtonSelectedB
	{
		get
		{
			return m_TypeButtonSelected ?? (m_TypeButtonSelected = Resources.Load ("GUI/Buttons/TypeButtons/sidemenubutton_bg3") as Texture2D);
		}
	}
*/
	// Science buttons
	public static Texture2D TypeButtonNormalSc
	{
		get
		{
			return m_TypeButtonNormal ?? (m_TypeButtonNormal = Resources.Load ("GUI/Buttons/TypeButtons/Science/ScienceButton1") as Texture2D);
		}
	}
	
	public static Texture2D TypeButtonHoverSc
	{
		get
		{
			return m_TypeButtonHover ?? (m_TypeButtonHover = Resources.Load ("GUI/Buttons/TypeButtons/Science/ScienceButton2") as Texture2D);
		}
	}
	
	public static Texture2D TypeButtonSelectedSc
	{
		get
		{
			return m_TypeButtonSelected ?? (m_TypeButtonSelected = Resources.Load ("GUI/Buttons/TypeButtons/Science/ScienceButton3") as Texture2D);
		}
	}
	/*
	//Ship buttons
	public static Texture2D TypeButtonNormalSh
	{
		get
		{
			return m_TypeButtonNormal ?? (m_TypeButtonNormal = Resources.Load ("GUI/Buttons/TypeButtons/Ship/ShipButton1") as Texture2D);
		}
	}
	
	public static Texture2D TypeButtonHoverSh
	{
		get
		{
			return m_TypeButtonHover ?? (m_TypeButtonHover = Resources.Load ("GUI/Buttons/TypeButtons/Ship/ShipButton2") as Texture2D);
		}
	}
	
	public static Texture2D TypeButtonSelectedSh
	{
		get
		{
			return m_TypeButtonSelected ?? (m_TypeButtonSelected = Resources.Load ("GUI/Buttons/TypeButtons/Ship/ShipButton3") as Texture2D);
		}
	}*/
}
