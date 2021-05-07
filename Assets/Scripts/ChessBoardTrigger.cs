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
        if (other.GetComponent<ChessPiece>() && other.GetComponent<ChessPiece>().inSpot == false)
        {
            other.GetComponent<ChessPiece>().StartMovingToBoard();
        }
    }
}
