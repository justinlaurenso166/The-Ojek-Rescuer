using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    public string targetObjectName = "Target"; // Nama gameobject target yang ingin dideteksi
    public float raycastDistance = 5f; // Jarak raycast
    public LayerMask layerMask; // Layer yang akan diperiksa

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
        }
        else
        {
            Debug.Log("Hasil: False");
            // Lakukan tindakan jika gameobject target tidak terdeteksi
        }
    }
}