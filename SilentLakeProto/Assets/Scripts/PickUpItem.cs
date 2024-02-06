using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject pickUpUI;
    [SerializeField] GameObject item;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;   
    }

    private void Update()
    {
        InteractWithObjects(mask, cam, pickUpUI, item);        
    }

    private void InteractWithObjects(LayerMask mask, Camera cam, GameObject UI, GameObject item)
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 2, mask)) 
        {
            if(hit.collider.gameObject == item)
            {
                UI.SetActive(true);
            }
        }

        else
        {
            UI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(ray, out hit, 2, mask))
            {
                if(hit.collider.gameObject == item)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
