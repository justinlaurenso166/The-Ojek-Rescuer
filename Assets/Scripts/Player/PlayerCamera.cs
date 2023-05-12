using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FKS
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera instance;
        public Camera cameraObject;
        public PlayerController player;
        [SerializeField] Transform cameraPivotTransform;

        private float horizontalRotation;
        private float verticalRotation;
        [Header("Camera Settings")]
        [SerializeField] float cameraSmoothSpeed = 3;    // THE BIGGER THIS NUMBER, THE LONGER FOR THE CAMERA TO REACH ITS POSITION DURING MOVEMENT
        [SerializeField] float leftAndRightRotationSpeed = 220;
        [SerializeField] float upAndDownRotationSpeed = 220;
        [SerializeField] float minimumPivot = -30;  // THE LOWEST POINT YOU ARE ABLE TO LOOK DOWN
        [SerializeField] float maximumPivot = 60;   // THE HIGHEST POINT YOU ARE ABLE TO LOOK UP
        [SerializeField] float cameraCollisionRadius = 0.2f;
        [SerializeField] LayerMask collideWithLayers;

        [Header("Camera Values")]
        private Vector3 cameraVelocity;
        private Vector3 cameraObjectPosition;   // USED FOR CAMERA COLLISION (MOVES THE CAMERA OBEJCT TO THIS POSITION UPON COLLIDING)
        [SerializeField] float leftAndRightLookAngle;
        [SerializeField] float upAndDownLookAngle;
        private float cameraZPosition;    // VALUES USE FOR CAMERA COLLISIONS
        private float targetCameraZPosition;     // VALUES USE FOR CAMERA COLLISIONS


        private void Start()
        {
            cameraZPosition = cameraObject.transform.localPosition.z;
        }

        private void FixedUpdate()
        {
            horizontalRotation = Input.GetAxis("Mouse X");
            verticalRotation = Input.GetAxis("Mouse Y");
            HandleAllCameraActions();
        }

        public void HandleAllCameraActions()
        {
            FollowTarget();
            HandleRotation();
            HandleCollision();
        }

        private void FollowTarget()
        {
            Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
            transform.position = targetCameraPosition;
        }

        private void HandleRotation()
        {

            // ROTATE LEFT AND RIGHT BASED ON HORIZONTAL MOVEMENT INPUT ON THE RIGHT JOYSTICK
            leftAndRightLookAngle += (horizontalRotation * leftAndRightRotationSpeed) * Time.deltaTime;
            // ROTATE UP AND DOWN BASED ON VERTICAL MOVEMENT INPUT ON THE RIGHT JOYSTICK
            upAndDownLookAngle -= (verticalRotation * upAndDownRotationSpeed) * Time.deltaTime;
            // CLAMP THE UP AND DOWN LOOK ANGLE BETWEEN MIN AND MAX VALUE
            upAndDownLookAngle = Mathf.Clamp(upAndDownLookAngle, minimumPivot, maximumPivot);

            Vector3 cameraRotation = Vector3.zero;
            Quaternion targetRotation;

            // ROTATE THIS GAMEOBJECT LEFT AND RIGHT
            cameraRotation.y = leftAndRightLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            transform.rotation = targetRotation;
            // ROTATE PIVOT GAMEOBJECT UP AND DOWN
            cameraRotation = Vector3.zero;
            cameraRotation.x = upAndDownLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            cameraPivotTransform.localRotation = targetRotation;
        }

        private void HandleCollision()
        {
            targetCameraZPosition = cameraZPosition;

            RaycastHit hit;
            // DIRECTION FOR COLLISION CHECK
            Vector3 direction = cameraObject.transform.position - cameraPivotTransform.position;
            direction.Normalize();

            // WE CHECK IF THERE IS AN OBJECT IN FRONT OF OUR DESIRE DIRECTION * (SEE ABOVE)
            if (Physics.SphereCast(cameraPivotTransform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetCameraZPosition), collideWithLayers))
            {
                // IF THERE IS, WE GET DISTANCE FOR IT
                float distanceFromHitObject = Vector3.Distance(cameraPivotTransform.position, hit.point);
                // WE THEN EQUATE OUR TARGET Z POSITION TO THE FOLLOWING
                targetCameraZPosition = -(distanceFromHitObject - cameraCollisionRadius);
            }

            // IF OUR TARGET POSITION IS LESS THAN OUR COLLISIOIN RADIUS, WE SUBTRACT OUR COLLISION RADIUS (MAKING IT SNAP BACK)
            if (Mathf.Abs(targetCameraZPosition) < cameraCollisionRadius)
            {
                targetCameraZPosition = -cameraCollisionRadius;
            }

            // WE THEN APPLY OUR FINAL POSiTION USING A LERP OVER A TIME OF 0.2
            cameraObjectPosition.z = Mathf.Lerp(cameraObject.transform.localPosition.z, targetCameraZPosition, 0.2f);
            cameraObject.transform.localPosition = cameraObjectPosition;
        }
    }
}
