using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] InputAction movement;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float VerticalThrow = movement.ReadValue<Vector2>().y;
        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float VerticalThrow = Input.GetAxis("Vertical");
        Debug.Log(horizontalThrow);
        Debug.Log(VerticalThrow);
    }
}
