using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorController : MonoBehaviour
{
    public GameObject player;
    public GameObject projectorParticles;
    private float destDistance = 3f;
    public bool projectorReady = false;
    public MeshRenderer pointerMR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnterDelegate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= destDistance)
        {
            if (!projectorReady)
            {
                pointerMR.material.color = Color.black;
            }
            else
            {
                pointerMR.material.color = Color.yellow;
            }
        }
    }

    public void OnPointerExitDelegate()
    {
        pointerMR.material.color = Color.white;
    }
    public void ChangeStateProjectorParticles()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= destDistance && projectorReady)
        {
            if (projectorParticles.activeInHierarchy)
                projectorParticles.SetActive(false);
            else
                projectorParticles.SetActive(true);
        }
    }
}
