using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerHands;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.tag == "Player")
        // {
        //     print("hay player items: " + playerHands.transform.childCount);
        //     if (playerHands.transform.childCount > 0)
        //     {
        //         print("manos ocupadas");
        //         GameObject item = playerHands.transform.GetChild(0).gameObject;
        //         if (item.GetComponent<ChessPiece>())
        //         {
        //             print("hay ficha de ajedrez");
        //             item.GetComponent<ChessPiece>().StartMovingToBoard();
        //         }
        //     }
        // }
        if (other.GetComponent<ChessPiece>())
        {
            print("hay ficha de ajedrez");
            other.GetComponent<ChessPiece>().StartMovingToBoard();
        }
    }
}
