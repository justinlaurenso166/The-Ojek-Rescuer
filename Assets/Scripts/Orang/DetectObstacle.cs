using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObstacle : MonoBehaviour
{
    public Vector3 boxHalfExtents;
    public float maxDistance;
    public LayerMask layerMask;

    public Transform targetDestination;
    public float speed = 3f;
    public float rotateSpeed = 1f;

    [Header("Waypoints")]
    public List<GameObject> waypoints;
    private int currentWaypointIndex = 0;
    Animator targetAnimator;
    float moveAmount;
    private bool isHit;

    void Start()
    {
        if (GetComponent<Animator>() != null)
        {
            targetAnimator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        RaycastHit hit;
        isHit = Physics.BoxCast(transform.position, boxHalfExtents, transform.forward, out hit, transform.rotation, maxDistance, layerMask);

        // Jika boxcast mendeteksi collider
        // Jika tidak maka korban akan bergerak ke titik waypoints
        if (isHit)
        {
            if (targetAnimator != null)
            {
                targetAnimator.SetFloat("verticalMove", 0f, 0.1f, Time.deltaTime);
            }
            Debug.Log("BoxCast hit: " + hit.collider.name);
            // Jika collider yang dideteksi memiliki tag "Exit" maka gameobject didestroy
            if (hit.collider.CompareTag("Exit"))
            {
                GameManager.score++;
                Destroy(gameObject);
            }

        }
        else
        {
            StartCoroutine(DelayedRaycastCheck(3f));
        }
    }

    IEnumerator DelayedRaycastCheck(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        RaycastHit hit;
        isHit = Physics.BoxCast(transform.position, boxHalfExtents, transform.forward, out hit, transform.rotation, maxDistance, layerMask);

        if (isHit)
        {
            // Handle the raycast hit
            targetAnimator.SetFloat("verticalMove", 0.1f, 0.1f, Time.deltaTime);
            Debug.Log("BoxCast hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Exit"))
            {
                GameManager.score++;
                Destroy(gameObject);
            }
        }
        else
        {
            // Mengambil posisi dari setiap waypoints dan bergerak ke posisi tersebut
            if (targetAnimator != null)
            {
                targetAnimator.SetFloat("verticalMove", 1f, 0.1f, Time.deltaTime);
            }

            Vector3 destination = waypoints[currentWaypointIndex].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;

            // Untuk mendapatkan nilai jarak antara korban dan setiap posisi waypoints
            float distance = Vector3.Distance(transform.position, destination);

            // Melakukan rotasi terhadap setiap waypoints
            Vector3 targetDirection = destination - transform.position;
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }

            // Jika jarak antara orang dan setiap waypoint sudah dekat
            // dan masih ada waypoint selanjutnya, maka index++
            // sehingga korban akan bergerak ke waypoint berikutnya
            if (distance <= 0.05)
            {
                if (currentWaypointIndex < waypoints.Count - 1)
                {
                    currentWaypointIndex++;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = isHit ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, boxHalfExtents * 2);
        //Gizmos.DrawWireCube(transform.position + -transform.forward * maxDistance, boxHalfExtents * 2);
        //Gizmos.DrawWireCube(transform.position + transform.right * maxDistance, boxHalfExtents * 2);
        //Gizmos.DrawWireCube(transform.position + -transform.right * maxDistance, boxHalfExtents * 2);
    }
}
