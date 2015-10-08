using UnityEngine;
using System.Collections;

public class UnitControl : MonoBehaviour {



    Vector3 currentPos;
    Vector3 targetPos;
    private float velocity = 10;
    private float distance;
    public bool selected;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        currentPos = new Vector3(0, 0, 0); // Current position

        
            // On right click, pick distance from 
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse Down 1");

                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

                if (hit)
                {
                    Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                    if (hitInfo.transform.gameObject.tag == "Cube")
                    {
                        Debug.Log("Success");
                    }
                    else
                    {
                        Debug.Log("Failure");
                    }
                }
                else {
                    Debug.Log("No hit");
                }

                Debug.Log("Mouse Down 2");
                 /* targetPos = Input.mousePosition; // Get target position from mouse position
                distance = Vector3.Distance(currentPos, targetPos); // Get distance between current and target positions
                float angle = Vector3.Angle(currentPos, targetPos); // Get angle between current and target positions

                // Assign positions and distance to create a targeting vector
                if (Physics.Raycast(currentPos, targetPos, distance))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(targetPos.x, targetPos.y, targetPos.z * velocity);
                } */
            }
        

    }

    void OnMouseOver() {

    }
    
}
