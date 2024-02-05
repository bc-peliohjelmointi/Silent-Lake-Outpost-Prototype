using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [SerializeField] GameObject taskBarrier;
    [SerializeField] GameObject taskList;
    [SerializeField] GameObject[] wolfs;
    [SerializeField] LayerMask mask;
    Camera cam;
    Vector3 pos;

    private void Start()
    {
        cam = Camera.main;
    }
    public void SpotAnimal()
    {
        if(taskBarrier.activeSelf)
        {
            pos = Input.mousePosition;
            pos.z = 100f;
            pos = cam.ScreenToWorldPoint(pos);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            foreach(GameObject wolf in wolfs)
            {
                if (Physics.Raycast(ray, out hit, 10000, mask))
                {
                    if (hit.collider.gameObject == wolf)
                    {
                        taskBarrier.SetActive(false);
                        taskList.SetActive(false);
                    }
                }
            }
        }
    }
}

