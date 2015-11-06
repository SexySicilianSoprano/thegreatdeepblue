using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ItemDB {
	
	private static GameObject m_SmallExplosion = Resources.Load ("", typeof(GameObject)) as GameObject;
	private static GameObject m_MediumExplosion = Resources.Load ("", typeof(GameObject)) as GameObject;
	private static GameObject m_LargeExplosion = Resources.Load ("", typeof(GameObject)) as GameObject;
	private static GameObject m_GiantExplosion = Resources.Load ("", typeof(GameObject)) as GameObject;
	
	private static List<Item> AllItems = new List<Item>();

    // ##### STEAM HOUSE BUILDINGS #####

    public static Item Scout = new Item
    {
        ID = 0,
        TypeIdentifier = Const.TYPE_Vehicle,
        TeamIdentifier = Const.TEAM_STEAMHOUSE,
        Name = "Scout",
        Health = 40.0f,
        Armour = 1.0f,
        Speed = 20.0f,
        RotationSpeed = 100.0f,
        Acceleration = 5.0f,
        Explosion = m_SmallExplosion,
        Prefab = Resources.Load("Models/Units/SteamHouse/Scout/Scout", typeof(GameObject)) as GameObject,
        ItemImage = Resources.Load("Item Images/GRI/Units/Vehicles/CubeTank/CubeTank", typeof(Texture2D)) as Texture2D,
        SortOrder = 0,
        RequiredBuildings = new int[] { 40 },
        Cost = 100,
        BuildTime = 10.0f,
    };

    public static Item Destroyer = new Item
    {
        ID = 1,
        TypeIdentifier = Const.TYPE_Vehicle,
        TeamIdentifier = Const.TEAM_STEAMHOUSE,
        Name = "Destroyer",
        Health = 100.0f,
        Armour = 3.0f,
        Speed = 10.0f,
        RotationSpeed = 80.0f,
        Acceleration = 2.0f,
        Explosion = m_SmallExplosion,
        Prefab = Resources.Load("Models/Units/SteamHouse/Destroyer/Destroyer", typeof(GameObject)) as GameObject,
        ItemImage = Resources.Load("Item Images/GRI/Units/Vehicles/CubeTank/CubeTank", typeof(Texture2D)) as Texture2D,
        SortOrder = 1,
        RequiredBuildings = new int[] { 40 },
        Cost = 100,
        BuildTime = 10.0f,
    };
	
    // ##### STEAM HOUSE BUILDINGS #####    

	public static Item FloatingFortress = new Item
	{
		ID = 0,
		TypeIdentifier = Const.TYPE_Building,
		TeamIdentifier = Const.TEAM_STEAMHOUSE,
		Name = "Floating Fortress",
		Health = 1000.0f,
		Armour = 10.0f,
		Explosion = m_LargeExplosion,
		Prefab = Resources.Load ("Models/Buildings/SteamHouse/Floating Fortress/FloatingFortress", typeof(GameObject)) as GameObject,
		SortOrder = 100,
		RequiredBuildings = new int[] { 7, 6, 100 },
		Cost = 700,
		BuildTime = 10.0f,
		ObjectType = typeof(FloatingFortress),
	};
	
	public static Item NavalYard = new Item
	{
		ID = 1,
		TypeIdentifier = Const.TYPE_Building,
		TeamIdentifier = Const.TEAM_STEAMHOUSE,
		Name = "Naval Yard",
		Health = 100.0f,
		Armour = 3.0f,
		Explosion = m_LargeExplosion,
		Prefab = Resources.Load ("Models/Buildings/SteamHouse/Naval Yard/NavalYard", typeof(GameObject)) as GameObject,
        ItemImage = Resources.Load ("Item Images/GRI/Buildings/Power Plant/PowerPlant", typeof(Texture2D)) as Texture2D,
		SortOrder = 0,
		RequiredBuildings = new int[] { 0 },
		Cost = 700,
		BuildTime = 2.0f,
		ObjectType = typeof(NavalYard),
	};

    // Functions
			
	public static void Initialise()
	{
        InitialiseItem (Scout);
        InitialiseItem (Destroyer);
        InitialiseItem (FloatingFortress);
		InitialiseItem (NavalYard);
	}
	
	private static void InitialiseItem(Item item)
	{
		item.Initialise ();
		AllItems.Add (item);
	}
	
	public static List<Item> GetAvailableItems(int ID, List<Building> CurrentBuildings)
	{
		List<Item> valueToReturn = AllItems.FindAll(x => 
		{
			if (x.RequiredBuildings.Length == 1)
			{
				if (x.RequiredBuildings[0] == ID)
				{
					return true;
				}
			}
			else
			{
				bool otherBuildingsPresent = true;
				
				//Does this item require the added building ID?
				if (x.RequiredBuildings.Contains (ID))
				{
					//If so do we have the other required ID's?
					foreach (int id in x.RequiredBuildings)
					{
						if (id != ID && CurrentBuildings.FirstOrDefault(building => building.ID == id) == null)
						{
							otherBuildingsPresent = false;
							break;
						}
					}
				}
				else
				{
					otherBuildingsPresent = false;
				}
				
				return otherBuildingsPresent;
			}
			
			
			return false;
		});
		
		return valueToReturn;
	}
}
