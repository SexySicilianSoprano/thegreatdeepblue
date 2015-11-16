using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Type button. This is where the TAB buttons are located
/// TODO: Remove all queuebutton references, since we don't need queuebuttons.
/// </summary>

public class TypeButton : ITypeButton
{
	private bool m_Selected = false;
	private List<IQueueButton> m_QueueButtons = new List<IQueueButton>();
	private ButtonType m_ButtonType;
	
	public GUIStyle m_ButtonStyle;
	private Rect m_ButtonRect;
	private Rect m_QueueButtonViewableRect;
	
	private string m_Content;
	private Texture2D m_Icon;

	int Button_ID;

	public bool Selected
	{
		get
		{
			return m_Selected;
		}
		private set
		{
			if (Equals (m_Selected, value))
			{
				return;
			}
			
			m_Selected = value;
			SelectedValueChanged (m_Selected);
		}
	}
	
	public TypeButton(ButtonType type, Rect menuArea)
	{
		m_ButtonType = type;
		
		CalculateSize (menuArea);

		//Create Style

		if (m_ButtonType == ButtonType.Building){

			m_ButtonStyle = GUIStyles.CreateTypeButtonStyleB();
			Debug.Log (m_ButtonType);
		}

		if (m_ButtonType == ButtonType.Ship){
			
			m_ButtonStyle = GUIStyles.CreateTypeButtonStyleSh();
			Debug.Log (m_ButtonType);
			
		}

		if (m_ButtonType == ButtonType.Science){
			
			m_ButtonStyle = GUIStyles.CreateTypeButtonStyleSc();
			Debug.Log (m_ButtonType);
		}

		//Attach to events
		GUIEvents.TypeButtonChanged += ButtonPressedEvent;
	}
	public void ChangeStyle(GUIStyle style)
	{
		m_ButtonStyle = style;
	}
	private void SelectedValueChanged(bool newValue)
	{
		// This is what is doing the selected buttons :I

		if (newValue)
		{
			//Button has been clicked, set to highlight
			if (m_ButtonType == ButtonType.Building){
				
				m_ButtonStyle.normal.background = GUITextures.TypeButtonSelectedB;
				m_ButtonStyle.hover.background = GUITextures.TypeButtonSelectedB;
			}
			
			if (m_ButtonType == ButtonType.Science){
				
				m_ButtonStyle.normal.background = GUITextures2.TypeButtonSelectedSc;
				m_ButtonStyle.hover.background = GUITextures2.TypeButtonSelectedSc;
			}
			
			if (m_ButtonType == ButtonType.Ship){
				
				m_ButtonStyle.normal.background = GUITextures3.TypeButtonSelectedSh;
				m_ButtonStyle.hover.background = GUITextures3.TypeButtonSelectedSh;
			}

		}
		else
		{
			//Button has been deselected, remove highlight
			if (m_ButtonType == ButtonType.Building){
				
				m_ButtonStyle.normal.background = GUITextures.TypeButtonNormalB;
				m_ButtonStyle.hover.background = GUITextures.TypeButtonHoverB;
			}
			
			if (m_ButtonType == ButtonType.Science){
				
				m_ButtonStyle.normal.background = GUITextures2.TypeButtonNormalSc;
				m_ButtonStyle.hover.background = GUITextures2.TypeButtonHoverSc;
			}
			
			if (m_ButtonType == ButtonType.Ship){
				
				m_ButtonStyle.normal.background = GUITextures3.TypeButtonNormalSh;
				m_ButtonStyle.hover.background = GUITextures3.TypeButtonHoverSh;
			}



		}
	}	
	
	public void Execute()
	{
		//Draw type button
		if (GUI.Button (m_ButtonRect, m_Icon, m_ButtonStyle))
		{
			GUIEvents.TypeButtonPressed (this, m_ButtonType);
		}
		if (Selected)
		{
			//Draw Queue Buttons
			foreach (QueueButton queueButton in m_QueueButtons)
			{
				queueButton.Execute ();
			}
		}
	}
	
	private void ButtonPressedEvent(object sender, TypeButtonEventArgs e)
	{
		if (sender == this)
		{
			if (Selected)
			{
				Selected = false;
			}
			else
			{
				Selected = true;
				
				//Set the first queue button to selected if there is one
				if (m_QueueButtons.Count > 0)
				{
					m_QueueButtons[0].SetSelected ();
				}
			}
		}
		else
		{
			Selected = false;
		}
	}

	public void AddNewQueue (Building building)
	{
		m_QueueButtons.Add(new QueueButton(m_QueueButtons.Count, building, (int)m_ButtonType, m_QueueButtonViewableRect));
	}

	public void RemoveQueue (Building building)
	{
		IQueueButton queueToRemove = m_QueueButtons.Find (x => x.BuildingID == building.UniqueID);
		
		if (queueToRemove == null)
		{
			return;
		}
		
		int id = queueToRemove.ID;
		m_QueueButtons.Remove (queueToRemove);
		
		//Button has been removed, tell other queue buttons to update their rect
		foreach (IQueueButton button in m_QueueButtons)
		{
			button.UpdateRect(id);
		}
	}
	
	public void UpdateQueueContents(List<Item> availableItems)
	{
		foreach (QueueButton queueButton in m_QueueButtons)
		{
			queueButton.UpdateQueueContents(availableItems);
		}
	}
	
	public void Resize(Rect newArea)
	{
		//Recalculate the sizes
		CalculateSize (newArea);
		
		//Tell queue buttons to update
		foreach (IQueueButton button in m_QueueButtons)
		{
			button.Resize (m_QueueButtonViewableRect);
		}
	}

	void CalculateSize (Rect menuArea)
	{
		//Need to determine button rect, margins are 1% of width
		float margin = menuArea.width*0.01f;
		
		float buttonSize = (menuArea.width-(margin*2))/5.0f;
		
		float buttonStartY = menuArea.yMin + margin;
		float buttonStartX = menuArea.xMin + margin;		
		
		
		switch (m_ButtonType)
		{
		case ButtonType.Building:
			
			buttonStartX += (buttonSize*0);
			//m_Content = Strings.B;
			//m_ButtonStyle = GUIStyles.CreateTypeButtonStyleB();
			Button_ID = 0;
			//m_Icon = Icons.B;
			
			break;
			
		case ButtonType.Ship:
			
			buttonStartX += (buttonSize*2);
			//m_Content = Strings.S;
			//m_ButtonStyle = GUIStyles.CreateTypeButtonStyleSc();
			Button_ID = 1;
			//m_Icon = Icons2.Sc;

			break;
			
		case ButtonType.Science:
			
			buttonStartX += (buttonSize*4);
			//m_Content = Strings.I;
			//m_ButtonStyle = GUIStyles.CreateTypeButtonStyleSh();
			Button_ID = 2;
			//m_Icon = Icons3.Sh;

			break;
			
		/*case ButtonType.Vehicle:
			
			buttonStartX += (buttonSize*3);
			m_Content = Strings.V;
			
			break;
			
		case ButtonType.Air:
			
			buttonStartX += (buttonSize*4);
			m_Content = Strings.A;
			
			break; */
		}
		
		//Assign rect
		m_ButtonRect = new Rect(buttonStartX, buttonStartY, buttonSize, buttonSize);
		
		//Calculate Queue Button viewable rect
		m_QueueButtonViewableRect = new Rect(menuArea);
		m_QueueButtonViewableRect.yMin = m_ButtonRect.yMax + margin;
	}
}

public enum ButtonType
{
	Building = Const.TYPE_Building,
	Ship = Const.TYPE_Ship,
	Science = Const.TYPE_Science,
	
}
