using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //InputManager inputManager;
    private float horizontalRotation;
    private float verticalRotation;

    public Transform targetTransform;   // Object that camera will follow
    public Transform cameraPivot;       // Object that camera use to pivot (look up and down)
    public Transform cameraTransform;   // Transform of actual camera on the scene
    public LayerMask collisionLayer;    // The layer we want that camera will collide with
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;

    public float lookAngle;     // Camera look up and down
    public float pivotAngle;    // Camera look left and right
    public float cameraLookSpeed = 15;
    public float cameraPivotSpeed = 15;
    public float minPivotAngle = -35;
    public float maxPivotAngle = 35;

    public float cameraFollowSpeed = 0.2f;
    public float cameraCollisionRadius = 0.2f;
    public float cameraCollisionOffset = 0.2f;  // How much camera will jump off of objects its colliding with
    public float minCollisionOffset = 0.2f;

    private void Awake()
    {
        //inputManager = FindObjectOfType<InputManager>();
        //targetTransform = FindObjectOfType<PlayerManager>().transform;
        //cameraTransform = Camera.main.transform;

        defaultPosition = cameraTransform.localPosition.z;
    }

    private void Update()
    {
        horizontalRotation = Input.GetAxis("Mouse X");
        verticalRotation = Input.GetAxis("Mouse Y");
        HandleAllCameraMovement();
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollision();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle = lookAngle + (horizontalRotation * cameraLookSpeed * Time.deltaTime);
        pivotAngle -= (verticalRotation * cameraPivotSpeed * Time.deltaTime);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollision()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayer))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minCollisionOffset)
        {
            targetPosition = targetPosition - minCollisionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
