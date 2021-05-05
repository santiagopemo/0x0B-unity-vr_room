using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour
{
    public GameObject codeButtons;

    public GlassDoorController doorController;
    public GameObject doorLockedGO;
    public GameObject doorUnlockedGO;


    private string password = "120";

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPassword(GameObject btnGO)
    {
       AddOne(btnGO);
       CheckButtons();
    }

    private void AddOne(GameObject btnGO)
    {
       string btnGOTxt = btnGO.transform.GetChild(0).GetComponent<Text>().text;
       int.TryParse(btnGOTxt, out int count);
       count = (count + 1) % 10;
       btnGO.transform.GetChild(0).GetComponent<Text>().text = "" + count;
    }
    private void CheckButtons()
    {
        string combination = "";
        foreach (Transform btn in codeButtons.transform)
        {
            combination += btn.transform.GetChild(0).GetComponent<Text>().text;
        }
        if (combination.Equals(password))
        {
            doorController.isUnlocked = true;
            doorLockedGO.SetActive(false);
            doorUnlockedGO.SetActive(true);
        }
    }
}
