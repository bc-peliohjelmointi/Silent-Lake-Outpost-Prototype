using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [SerializeField] GameObject taskBarrier;
    [SerializeField] GameObject taskList;
    [SerializeField] GameObject cannibal;
    [SerializeField] LayerMask mask;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    public void SpotAnimal()
    {
        if (taskBarrier.activeSelf)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000, mask))
            {
                if (hit.collider.gameObject == cannibal)
                {
                    taskBarrier.SetActive(false);
                    taskList.SetActive(false);
                }
            }
        }
    }
}

