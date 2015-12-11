using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class BuildingBeingPlaced : MonoBehaviour {

    private List<Material> m_BuildingMaterials = new List<Material>();
    private List<Color> m_ValidBuildingColors = new List<Color>();
    private List<Color> m_InvalidBuildingColors = new List<Color>();

    private float m_AlphaValue = 0.7f;

    public bool BuildValid = true;

    /*
    public Vector3 ColliderCenter
    {
        get
        {
            return ((BoxCollider)GetComponent<Collider>()).center;
        }
        private set
        {
            ((BoxCollider)GetComponent<Collider>()).center = value;
        }
    }

    public Vector3 ColliderSize
    {
        get
        {
            return ((BoxCollider)GetComponent<Collider>()).size;
        }
        private set
        {
            ((BoxCollider)GetComponent<Collider>()).size = value;
        }
    }
    */

    // Use this for initialization
    void Start()
    {
        //Get materials from current renderer and any child renderers
        if (GetComponent<Renderer>() != null)
        {
            m_BuildingMaterials.AddRange(GetComponent<Renderer>().materials);
        }

        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        if (childRenderers != null)
        {
            foreach (Renderer childRenderer in childRenderers)
            {
                m_BuildingMaterials.AddRange(childRenderer.materials);
            }
        }

        //Now we have the materials, we need to set them to see through and assign the relevant colors to the lists
        foreach (Material mat in m_BuildingMaterials)
        {
            //Update Shader
            mat.shader = Shader.Find("Transparent/Diffuse");

            //Set Color to see through
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, m_AlphaValue);

            //Add materials color to list
            m_ValidBuildingColors.Add(mat.color);

            //Add invalid color to list (same color with a red tint)
            m_InvalidBuildingColors.Add(new Color(1, mat.color.g, mat.color.b, m_AlphaValue));
        }
        /*
        //Set up the colliders bounds
        Vector3 lowerBound = new Vector3(10000, 10000, 10000);
        Vector3 upperBound = new Vector3(-10000, -10000, -10000);

        if (GetComponent<Renderer>() != null)
        {
            lowerBound.x = Mathf.Min(lowerBound.x, GetComponent<Renderer>().bounds.min.x);
            lowerBound.y = Mathf.Min(lowerBound.y, GetComponent<Renderer>().bounds.min.y);
            lowerBound.z = Mathf.Min(lowerBound.z, GetComponent<Renderer>().bounds.min.z);

            upperBound.x = Mathf.Max(upperBound.x, GetComponent<Renderer>().bounds.max.x);
            upperBound.y = Mathf.Max(upperBound.y, GetComponent<Renderer>().bounds.max.y);
            upperBound.z = Mathf.Max(upperBound.z, GetComponent<Renderer>().bounds.max.z);
        }

        if (childRenderers != null)
        {
            foreach (Renderer childRenderer in childRenderers)
            {
                lowerBound.x = Mathf.Min(lowerBound.x, childRenderer.bounds.min.x);
                lowerBound.y = Mathf.Min(lowerBound.y, childRenderer.bounds.min.y);
                lowerBound.z = Mathf.Min(lowerBound.z, childRenderer.bounds.min.z);

                upperBound.x = Mathf.Max(upperBound.x, childRenderer.bounds.max.x);
                upperBound.y = Mathf.Max(upperBound.y, childRenderer.bounds.max.y);
                upperBound.z = Mathf.Max(upperBound.z, childRenderer.bounds.max.z);
            }
        }

        //We now have our bounds, make sure they have found the correct values and apply
        if (lowerBound.x != 10000)
        {
            //Figure out center and size
            float xCenter = ((lowerBound.x + upperBound.x) / 2.0f) - transform.position.x;
            float yCenter = ((lowerBound.y + upperBound.y) / 2.0f) - transform.position.y;
            float zCenter = ((lowerBound.z + upperBound.z) / 2.0f) - transform.position.z;

            float xSize = upperBound.x - lowerBound.x;
            float ySize = upperBound.y - lowerBound.y;
            float zSize = upperBound.z - lowerBound.z;

            ColliderCenter = new Vector3(xCenter, yCenter, zCenter);
            ColliderSize = new Vector3(xSize, ySize, zSize); 
        }*/
    }

    void Update()
    {
        if (BuildValid)
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0, 150);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(255, 0, 0, 150);
        }
        if (SceneManager.GetActiveScene().name == "Scene_Multiplayer")
        {
            if (GetComponent<RTSObject>().primaryPlayer.controlledLayer == 8)
            {
                if (Vector3.Distance(gameObject.transform.position, GameObject.Find("Player1").transform.position) <= 50)
                {
                    BuildValid = true;
                }
                else
                {
                    BuildValid = false;
                }
            }
            else
            {

                if (Vector3.Distance(gameObject.transform.position, GameObject.Find("Player2").transform.position) <= 50)
                {
                    BuildValid = true;
                }
                else
                {
                    BuildValid = false;
                }
            }
        }
        else
        {
            if (GetComponent<RTSObject>().primaryPlayer.controlledLayer == 8)
            {
                if (Vector3.Distance(gameObject.transform.position, GameObject.Find("FloatingFortress_1").transform.position) <= 50)
                {
                    BuildValid = true;
                }
                else
                {
                    BuildValid = false;
                }
            }
            else
            {
                if (Vector3.Distance(gameObject.transform.position, GameObject.Find("FloatingFortress_2").transform.position) <= 50)
                {
                    BuildValid = true;
                }
                else
                {
                    BuildValid = false;
                }
            }
        }
    }

    public void SetToValid()
    {
        for (int i = 0; i < m_BuildingMaterials.Count; i++)
        {
            m_BuildingMaterials[i].color = m_ValidBuildingColors[i];
        }
    }

    public void SetToInvalid()
    {
        for (int i = 0; i < m_BuildingMaterials.Count; i++)
        {
            m_BuildingMaterials[i].color = m_InvalidBuildingColors[i];
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 12 || other.gameObject.layer == 3)
        {
            BuildValid = false;
        }
        
    }
        
	void OnDestroy()
	{
		//Make sure to destroy the materials we created
		foreach (Material mat in m_BuildingMaterials)
		{
			Destroy (mat);
		}
	}
}
