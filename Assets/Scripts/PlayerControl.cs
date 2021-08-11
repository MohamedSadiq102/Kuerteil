using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [Header ("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")] 
    [SerializeField] float controlSpeed  = 10f;

    [Tooltip("How far player moves horizontally")] 
    [SerializeField] float xRange = 10f;

    [Tooltip("How far player moves vertically")] 
    [SerializeField] float yRange = 5f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;


    [Header("Player input based tuning")]
    [SerializeField] float controlrollFactor = -20f;
    [SerializeField] float controlPitchFactor = -15f;

    // [SerializeField] InputAction fire;

    float horizontalThrow, verticalThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalThrow * controlPitchFactor;
        float pitch =  pitchDueToPosition + pitchDueToControlThrow;
        
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToControl = horizontalThrow * controlrollFactor;

        float roll = rollDueToControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void ProcessTranslation()
    {
        // it controls the plane to go left or right

        // read the value of movement x
         horizontalThrow = Input.GetAxis("Horizontal");
        // read the value of movement y
         verticalThrow = Input.GetAxis("Vertical");
        // To print in the console when movthe player 
        // I must press WASD during the play time 
        // in order to see the changes value
        // Debug.Log(horizontalThrow);
        // Debug.Log(verticalThrow);


        float xOffset = horizontalThrow * Time.deltaTime * controlSpeed;
        //  float xOffset = .1f;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float yOffset = verticalThrow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        // float zOffset = 13f;
        float newZPos = transform.localPosition.z;

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, newZPos);
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }

    }

    // The Func active the laserEmission or deactivated it
    void SetLaserActive(bool isActived)
    {
        // Active or Deactive each of lasers
        foreach(GameObject laser in lasers)
        {
            // laser.SetActive(true);
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActived;
        }

    }

}
