using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TypeButton : ITypeButton
{
	private bool m_Selected = false;
	private List<IQueueButton> m_QueueButtons = new List<IQueueButton>();
	private ButtonType m_ButtonType;
	
	private GUIStyle m_ButtonStyle;
	private Rect m_ButtonRect;
	private Rect m_QueueButtonViewableRect;
	
	private string m_Content;
	
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
		m_ButtonStyle = GUIStyles.CreateTypeButtonStyle();
		
		//Attach to events
		GUIEvents.TypeButtonChanged += ButtonPressedEvent;
	}
	
	private void SelectedValueChanged(bool newValue)
	{
		if (newValue)
		{
			//Button has been clicked, set to highlight
			m_ButtonStyle.normal.background = GUITextures.TypeButtonSelected;
			m_ButtonStyle.hover.background = GUITextures.TypeButtonSelected;
		}
		else
		{
			//Button has been deselected, remove highlight
			m_ButtonStyle.normal.background = GUITextures.TypeButtonNormal;
			m_ButtonStyle.hover.background = GUITextures.TypeButtonHover;
		}
	}	
	
	public void Execute()
	{
		//Draw type button
		if (GUI.Button (m_ButtonRect, m_Content, m_ButtonStyle))
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
			m_Content = Strings.B;
		
			break;
			
		case ButtonType.Vehicle:
			
			buttonStartX += (buttonSize*1);
			m_Content = Strings.V;
			
			break;
			
		case ButtonType.Science:
			
			buttonStartX += (buttonSize*2);
			m_Content = Strings.S;
			
			break;
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
	Vehicle = Const.TYPE_Vehicle,
	Science = Const.TYPE_Science,
}
