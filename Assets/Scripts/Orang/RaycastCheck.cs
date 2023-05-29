using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    public string targetObjectName = "Target"; // Nama gameobject target yang ingin dideteksi
    public Transform targetDestination;
    public float raycastDistance = 5f; // Jarak raycast
    public float speed = 5f;
    public float rotateSpeed = 1.0f;
    public LayerMask layerMask; // Layer yang akan diperiksa

    [Header("Waypoints")]
    public List<GameObject> waypoints;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        // Membuat raycast ke depan
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Mengecek apakah raycast mengenai gameobject dengan nama yang diinginkan
        bool hitTarget = Physics.Raycast(ray, out hit, raycastDistance, layerMask) && hit.collider.gameObject.name == targetObjectName;

        // Menggambar garis raycast di Editor Unity
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, hitTarget ? Color.green : Color.red);

        // Menggunakan nilai hitTarget sesuai kebutuhan
        if (hitTarget)
        {
            Debug.Log("Hasil: True");
            // Lakukan tindakan jika gameobject target terdeteksi
            // Mengambil posisi dari setiap waypoints dan bergerak ke posisi tersebut
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
        else
        {
            Debug.Log("Hasil: False");
            // Lakukan tindakan jika gameobject target tidak terdeteksi
        }
    }

    // Jika korban telah sampai ke tujuan (dalam hal ini gameobject dengan tag "Exit"), gameobject akan didestroy
}