using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedoMeter : MonoBehaviour
{
    public Rigidbody target;
    public float maxSpeed, minSpeed, maxSpeedAngle;
    public Text speedLabel;
    // RectTransforms are used for GUI but can also be used for other things. It's used to store and manipulate the position, size, and anchoring of a rectangle and supports various forms of scaling based on a parent RectTransform.
    public RectTransform arrow;
    private float speed;
    
    // Update is called once per frame
    void Update()
    {
        speed = target.velocity.magnitude * 3.6f;

        // If speedLabel is not 0
        if (speedLabel != null)
        {
            // The speedLabel will take the speed and display it on the screen
            speedLabel.text = ((int)speed) + "km/h";
        }
        // If arrow is not 0
        if (arrow != null)
        {
            // Larp make the arrow move smoothly 
            arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeed, maxSpeedAngle, speed / maxSpeed));
        }
    }
}
