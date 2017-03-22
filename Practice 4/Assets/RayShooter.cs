using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    Camera cam;
    
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenCenter = new Vector3 (cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(screenCenter) ;
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction*10, Color.yellow, 2); //indicators
       
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    Debug.Log("target hit");
                    target.ReactToHit(); //call the react to hit function
                }
                else
                {
                    //Display a sphere  at hit point, then destroy the sphere
                    StartCoroutine(SphereIndicator(hit.point));
                }
               
            }
        }
	}

    IEnumerator SphereIndicator(Vector3 point)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = point;
        sphere.transform.localScale = new Vector3(.5f, .5f, .5f);
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    public void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*"); //shows the crosshair
    }
}
