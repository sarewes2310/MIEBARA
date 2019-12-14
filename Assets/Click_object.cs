using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("TESTTT");
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                Debug.LogWarning(Hit.transform.name);
                if(Hit.transform.name == "Cube")
                {
                    Debug.LogWarning(Hit.transform.name);
                }
            } 
        }
    }
}
