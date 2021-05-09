using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{
    public Transform dest;
    private Transform initialParent;
    public Material higligthedMaterial;
    private Material defaultMaterial;

    private bool grabed = false;

    private float ThrowForce = 500f;
    private bool movingObject = false;
    private float destDistance = 1.5f;
    private bool reachable = false;
    public EventTrigger eventTrigger;
    void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material;
        initialParent = this.transform.parent;
        SetEventTrigger();
    }

    void SetEventTrigger()
    {
        eventTrigger = this.gameObject.AddComponent<EventTrigger>();
        // Pointer Enter
        EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
        pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
        pointerEnterEntry.callback.AddListener((data) => {OnPointerEnterDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerEnterEntry);

        // Pointer Down
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => {OnPointerDownDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerDownEntry);

        // Pointer Up
        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => {OnPointerUpDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerUpEntry);

        // Pointer Exit
        EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry();
        pointerExitEntry.eventID = EventTriggerType.PointerExit;
        pointerExitEntry.callback.AddListener((data) => {OnPointerExitDelegate((PointerEventData)data);});
        eventTrigger.triggers.Add(pointerExitEntry);
    }

    
    public void OnPointerEnterDelegate(PointerEventData data)
    {
        if (!(Vector3.Distance(dest.transform.position, transform.position) <= destDistance))
            return;
        if (grabed == false)
            GetComponent<MeshRenderer>().material = higligthedMaterial;
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        if (!(Vector3.Distance(dest.transform.position, transform.position) <= destDistance))
            return;
        grabed = true;
        GetComponent<MeshRenderer>().material = defaultMaterial;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        //---------------------------------------
        // GetComponent<Collider>().isTrigger = true;
        //---------------------------------------
        // this.transform.position = dest.position;
        this.transform.parent = dest.transform;
        movingObject = true;
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {        
        GetComponent<MeshRenderer>().material = defaultMaterial;
        this.transform.parent = initialParent;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().isTrigger = false;
        dest.transform.rotation = Quaternion.identity;
        grabed = false;
    }

    public void OnPointerExitDelegate(PointerEventData data)
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingObject && grabed)
        {
            // this.transform.position = Vector3.MoveTowards(transform.position, dest.position, 3.5f * Time.deltaTime);
            this.transform.position = Vector3.Lerp(transform.position, dest.position, 0.3f);
            if (Mathf.Abs(Vector3.Distance(transform.position, dest.position)) <= 0.01f)
            {
                movingObject = false;
                GetComponent<Collider>().isTrigger = true;
            }
        }
        if (Input.GetButton("Fire3") && grabed)
        {
            ThrowObject();
        }
        if (grabed)
        {
            transform.Rotate(Input.GetAxis("Vertical2") * 100f * Time.deltaTime, Input.GetAxis("Horizontal2") * 100f * Time.deltaTime, 0);
        }
        // if (Vector3.Distance(dest.transform.position, transform.position) <= destDistance)
        // {
        //     reachable = true;
        // }
        // else
        // {
        //     reachable = false;
        // }
    }

    void ThrowObject()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        this.transform.parent = initialParent;
        GetComponent<Collider>().isTrigger = false;
        grabed = false;
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * ThrowForce);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChessBoardTrigger>() || other.GetComponent<PlayerController>())
            return;
        GetComponent<Collider>().isTrigger = false;
        GetComponent<MeshRenderer>().material = defaultMaterial;
        this.transform.parent = initialParent;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        dest.transform.rotation = Quaternion.identity;
        grabed = false;
    }
}

