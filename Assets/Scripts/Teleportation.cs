using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Animator fadeAnimator;
    // public Image fadeImage;

    void Start()
    {
        // fadeImage.CrossFadeAlpha (0f, 0.5f, false);
    }

    public void Teleport()
    {
        // fadeImage.CrossFadeAlpha(1f, 0.075f, false);
        fadeAnimator.SetTrigger("FadeOut");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = transform.position;
        player.GetComponent<CharacterController>().enabled = true;
        // fadeImage.CrossFadeAlpha (0f, 0.150f, false);
    }
}
