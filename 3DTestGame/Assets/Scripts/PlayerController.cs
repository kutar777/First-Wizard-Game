using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   CharacterController characterController;

    public float turnSpeed = 45f;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;


    [Header("Keyboard Input")]
    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    KeyCode leftArrowKey = KeyCode.LeftArrow;

    [SerializeField]
    KeyCode rightArrowKey = KeyCode.RightArrow;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKey(leftArrowKey))
                transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);

            if (Input.GetKey(rightArrowKey))
                transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);

            moveDirection = transform.forward * Input.GetAxis("Vertical");

            moveDirection *= speed;

            if (Input.GetKeyDown(jumpKey))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
