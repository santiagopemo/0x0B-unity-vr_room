using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public Transform boardSpot;

    private bool moveToBoard = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToBoard)
        {
            transform.position = Vector3.Lerp(transform.position, boardSpot.position, 0.3f);
            // transform.rotation = Quaternion.Lerp(transform.rotation, boardSpot.rotation, 0.3f);
            transform.rotation = boardSpot.rotation;
            if (Mathf.Abs(Vector3.Distance(transform.position, boardSpot.position)) <= 0.001f)
            {
                transform.parent = boardSpot;
                moveToBoard = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        
    }

    public void StartMovingToBoard()
    {
        
        if (GetComponent<PickUp>())
        {
            GetComponent<PickUp>().OnPointerUpDelegate(null);
            print("hayPcik");
            GetComponent<PickUp>().enabled = false;
        }
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        moveToBoard = true;        
    } 
}
