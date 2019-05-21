using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public int rayLength = 10;

    private int countItems;

    public int CountItems
    {
        get
        {
            return countItems;
        }
    }

    BasicWheelChair chair;

    private void Start()
    {
        chair = GetComponent<BasicWheelChair>();
        countItems = 0;
    }

    void FixedUpdate () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.DrawLine(ray.origin, hit.point);
            //print("Found an " + hit.collider.tag + " - distance: " + hit.distance + ": " + hit.collider.transform.position.ToString());
            if (Input.GetMouseButtonDown(0))
            {
                GameObject obj = hit.collider.gameObject;
                print("This is " + obj.tag + " at distance: " + hit.distance + ": " + obj.transform.position.ToString() + "-> " + obj.name);
                if (obj.GetComponent<Item>().destroyItem())
                {
                    countItems++;
                }
            }
        }
    }
}
