﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectedManager : MonoBehaviour, ISelectedManager {

    // Singleton
    public static SelectedManager main;

    private List<RTSEntity> m_Selected = new List<RTSEntity>();
    private List<IOrderable> SelectedActiveEntities = new List<IOrderable>();
    private List<int> ListOfGroups = new List<int>();

    void Awake()
    {
        main = this;
    }

    // ### Selection functions ###

    //Adds the unit to selected
    public void AddToSelected(RTSEntity unit)
    {
        m_Selected.Add(unit);
    }

    //Removes the unit from selected
    public void RemoveFromSelected(RTSEntity unit)
    {
        m_Selected.Remove(unit);
    }

    //Removes everything from selected
    public void ClearSelected()
    {
        m_Selected.Clear();
    }

    // ### Grouping functions ###

    //Create Group with selected units and give it a hotkey
    public void CreateGroup(int number)
    {
        //TODO: Create Group-class

    }

    //Adds the group to selected
    public void SelectGroup(int number)
    {

    }
    //Give orders to selected units
    public void GiveOrder(Order order)
    {
        foreach (IOrderable orderable in SelectedActiveEntities)
        {
            orderable.GiveOrder(order);
        }
    }

    public int ActiveEntityCount()
    {
        return SelectedActiveEntities.Count;
    }

    public IOrderable FirstActiveEntity()
    {
        return SelectedActiveEntities[0];
    }

    public List<IOrderable> ActiveEntityList()
    {
        return SelectedActiveEntities;
    }

    public bool IsEntitySelected(GameObject obj)
    {
        return m_Selected.Contains(obj.GetComponent<RTSEntity>());
    }

}
