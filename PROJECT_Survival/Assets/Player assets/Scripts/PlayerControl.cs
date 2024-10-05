using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController controller;

    

    [SerializeField]
    float speed = 20.0f;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    float gravity = -9.81f;

    [SerializeField]
    Transform collisionCheck;

    [SerializeField]
    bool isGrounded;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    GameObject HUD;
    
    public bool isInInventory = false;

    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        GameObject HUDinst =  Instantiate(HUD);
        HUDinst.name = "HUD";
        HUDinst.GetComponent<Canvas>().transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(collisionCheck.position, 0.4f, layerMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (!isInInventory)
        {
            controller.Move(move * Time.deltaTime * speed);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(2 * -2f * gravity);
        }

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        velocity.y += gravity * Time.deltaTime;
        if (!isInInventory)
        {
            controller.Move(velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            isInInventory = !isInInventory;
        }
    }
}
