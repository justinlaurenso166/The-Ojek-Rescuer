using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [Header("PLAYER")]
    public GameObject player;
    public GameObject playerCamera;
    public GameObject playerFPSCamera;

    public GameObject aparCamera;

    [Header("UI elements")]
    public GameObject canUseText;

    public GameObject vfxAPAR;
    public Transform position;

    bool canEnter = false;
    bool enter = false;
    bool spawnEffect = false;
    private GameObject instantiateApar;
    bool isMouseDown = false;
    public BoxCollider boxCollider1;
    public BoxCollider boxCollider2;

    public Transform exitPosition;
    public Transform currentAparPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //it can enter
            canUseText.SetActive(true);
            canEnter = true;
        }
    }

    //when the player is far away of the forklift
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //it can not enter
            canUseText.SetActive(false);
            canEnter = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        if (canEnter == true && Input.GetKeyDown(KeyCode.F) && enter == false)
        {
            player.SetActive(false);
            playerCamera.SetActive(false);
            canUseText.SetActive(false);
            playerFPSCamera.SetActive(true);
            enter = true;
            GetComponent<Renderer>().enabled = false;
            boxCollider1.enabled = false;
            boxCollider2.enabled = false;
        }

        if (enter == true)
        {
            changeAparVfxPosition();
            if (isMouseDown && spawnEffect == false)
            {
                vfxAPAR.SetActive(true);
                instantiateApar = Instantiate(vfxAPAR, new Vector3(position.position.x, position.position.y, position.position.z), Quaternion.Euler(30f, 120f, position.transform.rotation.z));
                spawnEffect = true;
            }
            if (!isMouseDown && spawnEffect == true)
            {
                Destroy(instantiateApar);
                spawnEffect = false;
            }
        }

        if (enter == true && Input.GetKeyDown(KeyCode.Z))
        {
            this.gameObject.transform.position = currentAparPosition.position;
            player.transform.position = exitPosition.position;
            playerFPSCamera.SetActive(false);
            player.SetActive(true);
            playerCamera.SetActive(true);
            enter = false;
            GetComponent<Renderer>().enabled = true;
            boxCollider1.enabled = true;
            boxCollider2.enabled = true;
            canUseText.SetActive(false);
        }

        this.transform.position = currentAparPosition.position;
    }

    void changeAparVfxPosition()
    {
        if (instantiateApar != null)
        {
            instantiateApar.transform.position = position.transform.position;
            instantiateApar.transform.rotation = position.transform.rotation;
            // instantiateApar.transform.rotation = Quaternion.Euler(instantiateApar.transform.rotation.eulerAngles.x, 120f, instantiateApar.transform.rotation.eulerAngles.z);
        }
    }
}
