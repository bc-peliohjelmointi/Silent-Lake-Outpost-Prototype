using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binoculars : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;

    [SerializeField] GameObject binoculars;
    [SerializeField] GameObject crosshair;
    [SerializeField] float minZoom = 2f;
    [SerializeField] float maxZoom = 50f;
    [SerializeField] float sensitivity = 10f;
    private float fov;

    public bool isZoomed;

    [SerializeField] Texture2D binocImage;

    private void Update()
    {
        CheckZoom();

        if(isZoomed)
        {
            ScrollWheelZoom();
        }

        else 
        {
            _virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_virtualCamera.m_Lens.FieldOfView, maxZoom, Time.deltaTime * sensitivity);
        }
    }

    void CheckZoom()
    {
        if(binoculars.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isZoomed = true;
        }

        else if (isZoomed && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isZoomed = false;
            binoculars.SetActive(true);
        }

        else if (!isZoomed)
        {
            isZoomed = false;
            crosshair.SetActive(true);
        }
    }

    void OnGUI()
    {
        if(isZoomed)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), binocImage);
            binoculars.SetActive(false);
            crosshair.SetActive(false);
        } 
        
    }

    void ScrollWheelZoom()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        scrollWheelInput *= -1;

        fov = _virtualCamera.m_Lens.FieldOfView;
        fov += scrollWheelInput * sensitivity;
        fov = Mathf.Clamp(fov, minZoom, maxZoom);
        _virtualCamera.m_Lens.FieldOfView = fov;        
    }
}
