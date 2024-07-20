using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //[SerializeField] InputAction movement;

    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 7.5f; // min, max
    [SerializeField] float yRange = 5f; // min, max

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow;
    float yThrow;

    /*//InputSystem
    private void OnEnable()
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }*/

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = -90f + pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = 90f + xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); // È¸Àü
    }
    private void ProcessTranslation()
    {
        /*//InputSystem
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;*/

        //InputManager
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

        

        /*Debug.Log(xThrow);
        Debug.Log(yThrow);*/
    }
}
