using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    [SerializeField] GameObject cameraObject;
    [SerializeField] Light flash;
    [SerializeField] GameObject flashLight;
    [SerializeField] Light flashLightSpotLight;
    [SerializeField] GameObject binocs;
    [SerializeField] GameObject propBinocs;
    [SerializeField] GameObject propFlashlight;
    [SerializeField] GameObject propCamera;

    [SerializeField] GameObject flashlightInstructionUI;
    [SerializeField] GameObject cameraInstructionUI;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource flashLightSource;

    [SerializeField] AudioClip flashLightClip;
    [SerializeField] AudioClip photoClip;

    private bool isLightActive = false;
    private bool toggleFlashLightLight = false;

    Binoculars binocScript;

    private void Start()
    {
        flash.enabled = false;
        flashLightSpotLight.enabled = false;
        binocScript = GetComponent<Binoculars>();
    }

    private void Update()
    {
        PlayAudio();
        FlashLightOn();
        CameraShow();
        FlashLightShow();
        BinocularsShow();
    }

    private void PlayAudio()
    {
        if (cameraObject.activeSelf && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            audioSource.PlayOneShot(photoClip);
            ToggleFlash();
        }
    }

    private void ToggleFlash()
    {
        isLightActive = !isLightActive;
        flash.enabled = isLightActive;

        if(isLightActive)
        {
            Invoke("DeactivateFlash", 0.25f);
        }
    }

    private void DeactivateFlash()
    {
        flash.enabled = false;
        isLightActive = false;
    }

    void FlashLightOn()
    {
        if (flashLight.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            flashLightSpotLight.enabled = true;
            toggleFlashLightLight = !toggleFlashLightLight;
            flashLightSource.PlayOneShot(flashLightClip);
        }

        else if(toggleFlashLightLight)
        {
            flashLightSpotLight.enabled = false;
        }
    }

    void CameraShow()
    {
        if (!propCamera.activeSelf)
        {
            if (!cameraObject.activeSelf && !flashLight.activeSelf && !binocs.activeSelf && !binocScript.isZoomed && Input.GetKeyDown(KeyCode.C))
            {
                cameraObject.SetActive(true);
            }

            else if (!cameraObject.activeSelf && (flashLight.activeSelf || binocs.activeSelf) && Input.GetKeyDown(KeyCode.C))
            {
                flashLight.SetActive(false);
                binocs.SetActive(false);
                cameraObject.SetActive(true);
            }

            else if (cameraObject.activeSelf && Input.GetKeyDown(KeyCode.C))
            {
                cameraObject.SetActive(false);
                cameraInstructionUI.SetActive(false);
            }
        }
    }

    void FlashLightShow()
    {
        if (!propFlashlight.activeSelf)
        {
            if (!flashLight.activeSelf && !cameraObject.activeSelf && !binocs.activeSelf && !binocScript.isZoomed && Input.GetKeyDown(KeyCode.F))
            {
                flashLight.SetActive(true);
            }

            else if (!flashLight.activeSelf && (cameraObject.activeSelf || binocs.activeSelf) && Input.GetKeyDown(KeyCode.F))
            {
                cameraObject.SetActive(false);
                binocs.SetActive(false);
                flashLight.SetActive(true);
            }

            else if (flashLight.activeSelf && Input.GetKeyDown(KeyCode.F))
            {
                flashLight.SetActive(false);
                flashlightInstructionUI.SetActive(false);
            }
        }
    }

    void BinocularsShow()
    {
        if(!propBinocs.activeSelf)
        {
            if (!binocs.activeSelf && !cameraObject.activeSelf && !flashLight.activeSelf && !binocScript.isZoomed && Input.GetKeyDown(KeyCode.B))
            {
                binocs.SetActive(true);
            }

            else if (!binocs.activeSelf && (cameraObject.activeSelf || flashLight.activeSelf) && Input.GetKeyDown(KeyCode.B))
            {
                cameraObject.SetActive(false);
                flashLight.SetActive(false);
                binocs.SetActive(true);
            }

            else if (binocs.activeSelf && Input.GetKeyDown(KeyCode.B))
            {
                binocs.SetActive(false);
            }
        }
    }
}
