using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorController : MonoBehaviour
{
    public GameObject player;
    public GameObject projectorParticles;
    private float destDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStateProjectorParticles()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= destDistance)
        {
            print("projector");
            if (projectorParticles.activeInHierarchy)
                projectorParticles.SetActive(false);
            else
                projectorParticles.SetActive(true);
        }
    }
}
