using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayeController : MonoBehaviour
{
   [SerializeField]  float speed;
   [SerializeField] private float horsePower = 0;
    [SerializeField]  float rpm;
    private const float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWhells;
    [SerializeField] int wheelsOnGround;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        //transform.Translate(0, 0, 1); // ctrl + . = kodlama seçenekleri // (0, 0, 1); = (Vector3.forward); 
        // this is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical"); // unity deki inputlardan yararlanýldý.

        if (IsOnGround())
        {
            //we move the vehicle forward
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);

            // * Time.deltaTime = saniyede bir birim ilerleme kaydeder.
            //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed*horizontalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); //for kmh, change 2.237 to 3.6
            speedometerText.SetText("Speed:" + speed + "mph");

            rpm = (speed % 30) * 40; // rpm has calculeted and writed to screen
            rpmText.SetText("RPM: " + rpm);

        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWhells)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }           
        }

        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
