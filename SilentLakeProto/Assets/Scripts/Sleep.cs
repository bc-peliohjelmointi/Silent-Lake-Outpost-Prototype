using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] GameObject bed;
    [SerializeField] GameObject sleepUI;
    [SerializeField] LayerMask mask;
    Camera cam;
    [SerializeField] GameObject nightSky;
    [SerializeField] GameObject daySky;
    [SerializeField] GameObject darkening;
    [SerializeField] GameObject WakingUp;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        GoSleep(mask, cam, sleepUI, bed);
    }

    static async Task Sleeping(GameObject Darkening, GameObject NightSky, GameObject DaySky, GameObject WakingUp)
    {
        Darkening.SetActive(true);

        await Task.Delay(2000);

        WakingUp.SetActive(true);

        if (NightSky != null)
        {
            NightSky.SetActive(!NightSky.activeSelf);
            DaySky.SetActive(!DaySky.activeSelf);
        }

        await Task.Delay(4000);

        Darkening.SetActive(false);

        await Task.Delay(3000);

        WakingUp.SetActive(false);
    }

    private void GoSleep(LayerMask mask, Camera cam, GameObject UI, GameObject item)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 4, mask))
        {
            if (hit.collider.gameObject == item)
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
            if (Physics.Raycast(ray, out hit, 4, mask))
            {
                if (hit.collider.gameObject == item)
                {
                    // Koodi tähän, että mitä tapahtuu kun pelaaja painaa E:tä. Mahdollisesti uusi scene, missä voisi lukea "Day 2, Day3, Day4 yms...

                    Sleeping(darkening, nightSky, daySky, WakingUp);
                }
            }
        }
    }
}
