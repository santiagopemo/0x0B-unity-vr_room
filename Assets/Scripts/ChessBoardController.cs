using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessBoardController : MonoBehaviour
{
    public Transform emptySpots;
    public Image progressBar;
    public GameObject loading;
    public GameObject ready;
    public ProjectorController projectorController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckEmpySpots()
    {
        int count = 0;
        foreach (Transform spot in emptySpots)
        {
            if (spot.childCount > 0)
            {
                count++;
            }
        }
        float progress = (float)count / emptySpots.childCount;
        progressBar.fillAmount = progress;
        if (progress == 1.0f)
        {
            loading.SetActive(false);
            ready.SetActive(true);
            projectorController.projectorReady = true;
        }
    }
}
