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
	
	void Start(){
		currentHealth = GetComponent<RTSObject>().m_Health;
		maxHealth = GetComponent<RTSObject>().m_MaxHealth;
		GameObject newHealthSlider = Instantiate (sliderPrefab, this.gameObject.transform.position, Quaternion.identity) as GameObject;
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
		
		if (gameObject.layer == 9){
			healthBarSlider.gameObject.SetActive (false);
			if(GetComponent<RTSObject>().m_Health < GetComponent<RTSObject>().m_MaxHealth){
				healthBarSlider.gameObject.SetActive (true);
			}
		}
	}

}