using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConsoleButton : MonoBehaviour
{
    EventTrigger eventTrigger;
    private bool isInside = false;
    ConsoleController consoleController;
    // Start is called before the first frame update
    void Start()
    {
        consoleController = FindObjectOfType<ConsoleController>();
        eventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
        pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
        pointerEnterEntry.callback.AddListener((data) => {OnPointerEnterDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerEnterEntry);

        EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry();
        pointerExitEntry.eventID = EventTriggerType.PointerExit;
        pointerExitEntry.callback.AddListener((data) => {OnPointerExitDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerExitEntry);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isInside)
        {
            consoleController.CheckPassword(this.gameObject);
        }
    }

    private void OnPointerEnterDelegate(PointerEventData data)
    {
        isInside = true;
    }
    private void OnPointerExitDelegate(PointerEventData data)
    {
        isInside = false;
    }    
}
