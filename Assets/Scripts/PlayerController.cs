using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.5f;
    public MeshRenderer pointerMR;
    public Animator fadeAnimator;
    private float gravity = 10f;
    private CharacterController controller;

    private float horizontal, vertical;

    private Vector3 direction, velocity;

    private bool teleport = false;
    private Vector3 teleportPosition;
    private Transform playerCamera;
    public Transform torso;
    private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        PlayerTeleportation();
    }

    private void PlayerMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0, vertical);
        velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.fixedDeltaTime);
        torso.transform.eulerAngles = new Vector3(torso.eulerAngles.x, playerCamera.eulerAngles.y, torso.eulerAngles.z);
    }
    private void PlayerTeleportation()
    {
        if (Input.GetButton("Fire2"))
        {
            int layer_mask = LayerMask.NameToLayer("Character");
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit _hit, layer_mask))
            {
                if (_hit.transform.parent != null && _hit.transform.parent.transform.parent != null && _hit.transform.parent.transform.parent.name == "Floors")
                {
                    pointerMR.material.color = Color.green;
                    teleport = true;
                    teleportPosition = _hit.point;
                }
                else
                {
                    pointerMR.material.color = Color.red;
                }
            }
        }
        if (Input.GetButtonUp("Fire2"))
        {
            if (teleport)
            {
                fadeAnimator.SetTrigger("FadeOut");
                GetComponent<CharacterController>().enabled = false;
                transform.position = new Vector3(teleportPosition.x, teleportPosition.y + GetComponent<CharacterController>().height / 2, teleportPosition.z);
                GetComponent<CharacterController>().enabled = true;
                teleport = false;
            }
            pointerMR.material.color = Color.white;
        }
    }
}
