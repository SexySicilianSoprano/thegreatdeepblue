using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectedManager : MonoBehaviour, ISelectedManager {

    public static SelectedManager main;

    private List<RTSEntity> m_Selected = new List<RTSEntity>();
    private List<IOrderable> SelectedActiveEntities = new List<IOrderable>();

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

    //Destroy Group
    public void RemoveGroup(int number)
    {

    }

    //Adds the group to selected
    public void SelectGroup(int number)
    {

    }

    public void GiveOrder(Order order)
    {

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
