using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private bool isMoving = true;
    [SerializeField] private float moveSpeed = 1f;
    public float speed = 6.0F;

    [SerializeField]
    private float moveDistance = 1.0f;

    [SerializeField]
    private float jumpHeight;

    [Header("Keyboard Input")]
    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    KeyCode leftArrowKey = KeyCode.LeftArrow;

    [SerializeField]
    KeyCode rightArrowKey = KeyCode.RightArrow;


    private Vector3 targetPos;
    private float previousX;
    private float targetX;

    private bool isSideMoving;
    private bool isJumping;

    private float jumpingTime;

    private void Awake()
    {
        previousX = transform.position.x;
    }

    void Update()
    {
        if (isMoving)
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        if(!isSideMoving && !isJumping)
        {
            if (Input.GetKeyDown(leftArrowKey))
            {
                targetX = previousX - moveDistance;
                isSideMoving = true;
                Debug.Log(targetPos.ToString());
            }

            if (Input.GetKeyDown(rightArrowKey))
            {
                targetX = previousX + moveDistance;
                isSideMoving = true;
            }

            if (Input.GetKeyDown(jumpKey))
            {
                isJumping = true;
            }
        }

        if(isSideMoving)
        {
            targetPos = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.001f)
            {
                previousX = targetX;
                isSideMoving = false;
            }
        }

        if(isJumping)
        {
            jumpingTime += Time.deltaTime * 2f * Mathf.PI;
            Debug.Log("Jumping TIme: " + isJumping);

            targetPos = new Vector3(transform.position.x, Mathf.Sin(jumpingTime) * jumpHeight, transform.position.z);
            Debug.Log("Time: " + jumpingTime / Mathf.PI / 2f);
            Debug.Log("Jump: " + targetPos.y);
            if (jumpingTime > 0.5f * 2f * Mathf.PI)
            {
                isJumping = false;
                targetPos = new Vector3(transform.position.x, 1f, transform.position.z);
                jumpingTime = 0f;
            }

            transform.position = targetPos;
        }

    }
};