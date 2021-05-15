using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Desktop : MonoBehaviour
{
    public GameObject canvasScreen1;
    public GameObject canvasScreen2;
    public GameObject canvasScreen3;
    public GameObject canvasScreen4;
    public GameObject player;
    private float destDistance = 3f;
    public MeshRenderer pointerMR;

    private bool deskOn = false;
    // Start is called before the first frame update
    void Start()
    {
        SetEventTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetEventTrigger()
    {
        EventTrigger eventTrigger = this.gameObject.AddComponent<EventTrigger>();
        // Pointer Enter
        EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
        pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
        pointerEnterEntry.callback.AddListener((data) => {OnPointerEnterDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerEnterEntry);

        // Pointer click
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => {OnPointerClickDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerDownEntry);

        // Pointer Exit
        EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry();
        pointerExitEntry.eventID = EventTriggerType.PointerExit;
        pointerExitEntry.callback.AddListener((data) => {OnPointerExitDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerExitEntry);
    }

    private void OnPointerExitDelegate(PointerEventData data)
    {
        
        pointerMR.material.color = Color.white;
        
    }

    private void OnPointerUpDelegate(PointerEventData data)
    {
        
    }

    private void OnPointerClickDelegate(PointerEventData data)
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= destDistance)
        {
            if (deskOn)
            {
                canvasScreen1.SetActive(false);
                canvasScreen2.SetActive(false);
                // canvasScreen3.SetActive(false);
                canvasScreen4.SetActive(false);
                deskOn = false;
            }
            else
            {
                canvasScreen1.SetActive(true);
                canvasScreen2.SetActive(true);
                // canvasScreen3.SetActive(true);
                canvasScreen4.SetActive(true);
                deskOn = true;
            }
        }
    }

    private void OnPointerEnterDelegate(PointerEventData data)
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= destDistance)
        {
            pointerMR.material.color = Color.yellow;
        }
    }     
}
