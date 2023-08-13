using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController controller;
    Vector3 moveInput;
    public float moveSpeed;
    public float gravity;

    Vector3 mousePosition;
    Vector3 direction;
    Vector3 playerPosition;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        playerPosition = Camera.main.WorldToScreenPoint(transform.position);

        direction = mousePosition - playerPosition;

        float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-rotationAngle, Vector3.up);
    }

    private void FixedUpdate()
    {
        moveInput.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveInput.z = Input.GetAxis("Vertical") * moveSpeed;

        if (!controller.isGrounded)
        {
            moveInput.y -= gravity;
        }

        controller.Move(moveInput);
    }
}
