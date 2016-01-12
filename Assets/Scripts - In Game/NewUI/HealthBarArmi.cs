using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RTSObject))]
public class HealthBarArmi : MonoBehaviour {

	public RectTransform canvasRectT;
	public RectTransform healthBar;
	public Slider healthBarSlider;
	public Transform objectToFollow;
	public GameObject sliderPrefab;
	public float currentHealth;
	public float maxHealth;

    private int primaryPlayer
    {
        get
        {
            return GameObject.Find("Manager").GetComponent<GameManager>().primaryPlayer().controlledLayer;
        }
    }

    private int enemyPlayer
    {
        get
        {
            return GameObject.Find("Manager").GetComponent<GameManager>().enemyPlayer().controlledLayer;
        }
    }

    void Start()
    {
        GameObject canvas = GameObject.Find("UI_health");
        canvasRectT = canvas.GetComponent<RectTransform>();

        sliderPrefab = Resources.Load("Slider") as GameObject;

		currentHealth = GetComponent<RTSObject>().m_Health;
		maxHealth = GetComponent<RTSObject>().m_MaxHealth;

		GameObject newHealthSlider = Instantiate (sliderPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
		newHealthSlider.transform.SetParent(canvasRectT, true);

		newHealthSlider.transform.position = new Vector3 (0,0,0);
		healthBar = (RectTransform)newHealthSlider.transform;

		healthBarSlider = newHealthSlider.gameObject.GetComponent<Slider>();
		objectToFollow = this.gameObject.transform;
	}
	
	void Update()
	{
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, objectToFollow.position);
		healthBar.anchoredPosition = screenPoint - canvasRectT.sizeDelta / 2f;
		healthBarSlider.value = GetComponent<RTSObject>().m_Health;
		healthBarSlider.maxValue = GetComponent<RTSObject>().m_MaxHealth;
		
		if (gameObject.layer == enemyPlayer)
        {
			healthBarSlider.gameObject.SetActive (false);

			if(GetComponent<RTSObject>().m_Health < GetComponent<RTSObject>().m_MaxHealth)
            {
				healthBarSlider.gameObject.SetActive (true);
			}
		}
	}

}