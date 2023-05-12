using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMove;
    float verticalMove;
    float moveAmount;
    Vector3 moveDirection;
    Vector3 targetRotationDirection;
    CharacterController characterController;
    Animator targetAnimator;
    public Transform cameraTransform;

    public float movementSpeed = 7f;
    public float rotationSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        targetAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        // RETURN THE ABSOLUTE NUMBER, (Meaning number without negative sign, so its always positive)
        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalMove) + Mathf.Abs(horizontalMove));

        // WE CALMP THE VALUES, SO THEY ARE 0, 0.5, OR 1
        if (moveAmount <= 0.5f && moveAmount > 0)
        {
            moveAmount = 0.5f;
        }
        else if (moveAmount > 0.5f && moveAmount <= 1)
        {
            moveAmount = 1;
        }

        // IF WE ARE NOT LOCKED ON, ONLY USE THE MOVE AMOUNT
        targetAnimator.SetFloat("verticalMove", moveAmount, 0.1f, Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleAllMovement();
    }

    public void HandleAllMovement()
    {
        HandleGroundedMovement();
        HandleRotation();
    }

    private void HandleGroundedMovement()
    {
        // OUR MOVE DIRECTION IS BASED ON OUR CAMERA FACING PERSPECTIVE & OUR MOVEMENT INPUT
        moveDirection = cameraTransform.forward * verticalMove;
        moveDirection = moveDirection + cameraTransform.right * horizontalMove;
        moveDirection.Normalize();
        moveDirection.y = 0;

        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        targetRotationDirection = Vector3.zero;
        targetRotationDirection = cameraTransform.forward * verticalMove;
        targetRotationDirection = targetRotationDirection + cameraTransform.right * horizontalMove;
        targetRotationDirection.Normalize();
        targetRotationDirection.y = 0;

        if (targetRotationDirection == Vector3.zero)
        {
            targetRotationDirection = transform.forward;
        }

        Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;
    }
}
