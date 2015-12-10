using UnityEngine;
using System.Collections;

public static class GUIStyles 
{
	//Static styles ---------------------------------------------------------
	private static GUIStyle m_NormalText;
	
	private static GUIStyle m_MoneyLabel;
	private static GUIStyle m_ItemFinishedLabel;
	
	public static GUIStyle MoneyLabel
	{
		get
		{
			return m_MoneyLabel;
		}
	}
	
	public static GUIStyle ItemFinishedLabel
	{
		get
		{
			return m_ItemFinishedLabel;
		}
	}
	
	
	
	//----------------------------------------------------------------------
	
	public static void Initialise()
	{
		m_NormalText = new GUIStyle();
		
		m_MoneyLabel = new GUIStyle();
		m_MoneyLabel.fontSize = 20;
		m_MoneyLabel.normal.textColor = Color.white;
		m_MoneyLabel.alignment = TextAnchor.MiddleCenter;
		
		m_ItemFinishedLabel = new GUIStyle();
		m_ItemFinishedLabel.fontSize = 20;
		m_ItemFinishedLabel.normal.textColor = Color.black;
		m_ItemFinishedLabel.alignment = TextAnchor.MiddleCenter;
	}
	
	//Dynamic Styles-------------------------------------------------------
	
	//Type button style
	public static GUIStyle CreateTypeButtonStyleB()
	{
		GUIStyle style = new GUIStyle();
		
		style.normal.background = GUITextures.TypeButtonNormalB;
		//style.normal.textColor = Color.white;
		
		style.hover.background = GUITextures.TypeButtonHoverB;
		//style.hover.textColor = Color.white;
		
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = 30;
		return style;
	}

	public static GUIStyle CreateTypeButtonStyleSc()
	{
		GUIStyle style = new GUIStyle();
		
		style.normal.background = GUITextures2.TypeButtonNormalSc;
		//style.normal.textColor = Color.white;
		
		style.hover.background = GUITextures2.TypeButtonHoverSc;
		//style.hover.textColor = Color.white;
		
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = 30;
		return style;
	}

	public static GUIStyle CreateTypeButtonStyleSh()
	{
		GUIStyle style = new GUIStyle();
		
		style.normal.background = GUITextures3.TypeButtonNormalSh;
		//style.normal.textColor = Color.white;
		
		style.hover.background = GUITextures3.TypeButtonHoverSh;
		//style.hover.textColor = Color.white;
		
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = 30;
		return style;
	}
	
	public static GUIStyle CreateQueueButtonStyle()
	{
		GUIStyle style = new GUIStyle();
		
		style.normal.background = GUITextures.TypeButtonNormalB;
		//style.normal.textColor = Color.white;
		
		style.hover.background = GUITextures.TypeButtonHoverB;
		//style.hover.textColor = Color.white;
		
		/*style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = 30;*/
		
		return style;
	}
	
	public static GUIStyle CreateQueueContentButtonStyle()
	{
		GUIStyle style = new GUIStyle();
		
		
		
		return style;
	}
	//----------------------------------------------------------------------
}
