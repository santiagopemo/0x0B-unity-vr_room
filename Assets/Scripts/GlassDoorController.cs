using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorController : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public GameObject door;
    private float destDistance = 3f;

    public bool isUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ChangeStateGlassDoor()
    {
        if (Vector3.Distance(player.transform.position, door.transform.position) <= destDistance && isUnlocked)
        {
            if (animator.GetBool("character_nearby"))
                animator.SetBool("character_nearby", false);
            else
                animator.SetBool("character_nearby", true);
        }
    }
}
