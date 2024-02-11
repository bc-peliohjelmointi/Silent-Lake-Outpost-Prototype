using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCannibal : MonoBehaviour
{
    [SerializeField] GameObject cannibalPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HideCannibal"))
        {
            cannibalPrefab.SetActive(false);
        }
    }
}
