﻿using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class forklift : MonoBehaviour
{
    [Header("PLAYER")]
    public GameObject player;
    public GameObject playerCamera;

    [Header("UI elements")]
    public TextMeshProUGUI gearText;
    public TextMeshProUGUI speedText;
    public GameObject canEnterText;
    public GameObject inForkliftMenu;
    [Header("WHEEL COLLIDERS")]
    public WheelCollider frontR;
    public WheelCollider frontL;
    public WheelCollider rearR;
    public WheelCollider rearL;

    [Header("WHEEL TRANSFORMS")]
    public Transform frontRightT;
    public Transform frontLeftT;
    public Transform rearRightT;
    public Transform rearLeftT;

    public Transform exitPosition;
    public Transform loader;
    public Transform centerOfMass;
    public GameObject steeringWheel;
    public Rigidbody rb;
    public GameObject cameraInteriorForklift;
    public GameObject cameraExteriorForklift;
    public GameObject FPS;

    [Header("VALUES")]
    public float torque;
    public float brakeTorque;
    public float maxSteerAngle;
    public static float currentSpeed;
    public float maxSpeed;

    [Header("KeyCodes")]
    public KeyCode upGearKey = KeyCode.E;
    public KeyCode downGearKey = KeyCode.Q;
    public KeyCode upLoaderKey = KeyCode.R;
    public KeyCode downLoaderKey = KeyCode.F;

    [Header("Untuk Mobil Terbalik")]
    public GameObject forkliftSpawner;
    //public GameObject loaderSpawner;

    public GameObject speedometer;

    [Range(-1, 1)]
    int currentGear = 0;
    bool canEnter = false;
    bool enter = false;
    float maxPositionY = 3.5f;

    public AudioClip audioClipMesinHidup;
    public AudioClip audioClipMesinIdle;
    public AudioClip audioClipMesinJalan;
    public AudioSource audioSource;
    public CameraForklift cameraForklift;

    //when the player is close to the forklift
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //it can enter
            canEnterText.SetActive(true);
            canEnter = true;
        }
    }

    //when the player is far away of the forklift
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //it can not enter
            canEnterText.SetActive(false);
            canEnter = false;
        }
    }

    private void Start()
    {
        //ignore that
        Application.targetFrameRate = 60;

        //aply the center of mass
        rb.centerOfMass = new Vector3(rb.centerOfMass.x, centerOfMass.position.y, rb.centerOfMass.z);
    }

    void Update()
    {
        if (GameManager.scoreTarget != 0)
        {
            if (GameManager.score == GameManager.scoreTarget)
            {
                cameraForklift.enabled = false;
            }
        }

        //if can enter and press F key and is not in
        if (canEnter == true && Input.GetKeyDown(KeyCode.F) && enter == false)
        {
            //then enter the forklift
            //FPS.SetActive(false);
            audioSource.clip = audioClipMesinHidup;
            audioSource.Play();
            audioSource.loop = false;
            player.SetActive(false);
            playerCamera.SetActive(false);
            cameraInteriorForklift.SetActive(true);
            cameraExteriorForklift.SetActive(false);
            canEnterText.SetActive(false);
            enter = true;
            speedometer.SetActive(true);
            inForkliftMenu.SetActive(true);
        }

        if (enter == true)
        {
            // Jika mobil terbalik, reset position
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ResetCarRotation();
            }
        }

        //if is not enter, execute again the update method
        if (enter == false) return;

        currentSpeed = rb.velocity.magnitude;

        bool isMoving = currentSpeed > 0.1f;

        // Play the appropriate audio clip based on whether the forklift is moving or idle
        if (isMoving)
        {
            if (!audioSource.isPlaying || audioSource.clip != audioClipMesinJalan)
            {
                audioSource.clip = audioClipMesinJalan;
                audioSource.Play();
            }
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audioClipMesinIdle;
                audioSource.Play();
            }
        }

        if (currentSpeed < maxSpeed)
        {
            //aply motor torque
            frontL.motorTorque = Input.GetAxis("Vertical") * torque * currentGear;
            frontR.motorTorque = Input.GetAxis("Vertical") * torque * currentGear;
            rearL.motorTorque = Input.GetAxis("Vertical") * torque * currentGear;
            rearR.motorTorque = Input.GetAxis("Vertical") * torque * currentGear;
        }
        else
        {
            frontL.motorTorque = 0;
            frontR.motorTorque = 0;
            rearL.motorTorque = 0;
            rearR.motorTorque = 0;
        }

        if (Input.GetAxis("Vertical") <= 0)
        {
            //aply brake torque
            frontL.brakeTorque = brakeTorque;
            frontR.brakeTorque = brakeTorque;
            rearL.brakeTorque = brakeTorque;
            rearR.brakeTorque = brakeTorque;
        }
        else
        {
            frontL.brakeTorque = 0;
            frontR.brakeTorque = 0;
            rearL.brakeTorque = 0;
            rearR.brakeTorque = 0;
        }

        //make the wheels turn
        rearL.steerAngle = -maxSteerAngle * Input.GetAxis("Horizontal");
        rearR.steerAngle = -maxSteerAngle * Input.GetAxis("Horizontal");
        steeringWheel.transform.localEulerAngles = new Vector3(53f, 0f, rearL.steerAngle * 6);

        //up the loader
        if (Input.GetKey(KeyCode.R) && loader.position.y < maxPositionY)
        {
            loader.Translate(new Vector3(0f, 1f, 0f) * Time.deltaTime);
        }

        //down the loader
        if (Input.GetKey(KeyCode.F) && loader.position.y > 0.001f)
        {
            loader.Translate(new Vector3(0f, -1f, 0f) * Time.deltaTime);
        }

        //update wheel poses
        UpdateWheelPoses();

        //if press Z key
        if (Input.GetKeyDown(KeyCode.C))
        {
            //exit the forklift
            audioSource.Stop();
            inForkliftMenu.SetActive(false);
            enter = false;
            //FPS.transform.position = exitPosition.position;
            //FPS.SetActive(true);
            player.transform.position = exitPosition.position;
            player.SetActive(true);
            playerCamera.SetActive(true);
            cameraInteriorForklift.SetActive(false);
            cameraExteriorForklift.SetActive(false);
            speedometer.SetActive(false);
            canEnterText.SetActive(false);
        }

        if (Input.GetKeyDown(upGearKey))
        {
            if (currentGear < 1)
            {
                currentGear++;
            }
        }

        if (Input.GetKeyDown(downGearKey))
        {
            if (currentGear > -1)
            {
                currentGear--;
            }
        }

        //update texts
        gearText.text = "Gear: " + currentGear;
        // speedText.text = "Speed: " + currentSpeed.ToString("f2") + "Km/h";
        print(currentSpeed);
    }

    private void UpdateWheelPoses()
    {
        //update wheels position
        // Debug.Log("JALAN");
        UpdateWheelPose(frontR, frontRightT);
        UpdateWheelPose(frontL, frontLeftT);
        UpdateWheelPose(rearL, rearLeftT);
        UpdateWheelPose(rearR, rearRightT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        // audioSource.clip = audioClip;
        // audioSource.Play();
        //makes the whhels turn to the same speed as the wheel collider
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.rotation = _quat.normalized;
    }

    private void ResetCarRotation()
    {
        Debug.Log("Reset car position!");
        //rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = Vector3.zero;
        //transform.rotation = initialRotation;
        gameObject.transform.position = forkliftSpawner.transform.position;
        gameObject.transform.rotation = forkliftSpawner.transform.rotation;
        //loader.transform.position = loaderSpawner.transform.position;
    }
}