using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject pickUpUI;
    [SerializeField] GameObject item;
    Camera cam;
    Vector3 mousePos;

    private void Start()
    {
        cam = Camera.main;   
    }

    private void Update()
    {
        InteractWithObjects(mousePos, mask, cam, pickUpUI, item);
    }

    private void InteractWithObjects(Vector3 pos, LayerMask mask, Camera cam, GameObject UI, GameObject item)
    {
        pos = Input.mousePosition;
        pos.z = 100f;
        pos = cam.ScreenToWorldPoint(pos);
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
