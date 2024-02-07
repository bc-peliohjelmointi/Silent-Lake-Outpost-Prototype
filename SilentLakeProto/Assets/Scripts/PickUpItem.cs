using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject pickUpUI;
    [SerializeField] GameObject item;

    Camera cam;

    //testit
    [SerializeField] GameObject binocs;
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject cameraUI;
    [SerializeField] GameObject flashlightUI;
    [SerializeField] GameObject binocsUI;
    [SerializeField] LayerMask mask2;
    [SerializeField] LayerMask mask3;
    [SerializeField] LayerMask mask4;

    private void Start()
    {
        cam = Camera.main;   
    }

    private void Update()
    {
        InteractWithObjects(mask, cam, pickUpUI, item);
        InteractWithObjects(mask2, cam, binocsUI, binocs);
        InteractWithObjects(mask3, cam, flashlightUI, flashlight);
        InteractWithObjects(mask4, cam, cameraUI, camera);
    }

    private void InteractWithObjects(LayerMask mask, Camera cam, GameObject UI, GameObject item)
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 4, mask)) 
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
            if(Physics.Raycast(ray, out hit, 4, mask))
            {
                if(hit.collider.gameObject == item)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
