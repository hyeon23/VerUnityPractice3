using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    // Update is called once per frame
    void Update()
    {
        InputMoveAxis();
        InputRotateAxis();
        InputInteractAction();
        InputJump();
    }

    private void InputMoveAxis()
    {
        controlTarget.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
    private void InputRotateAxis()
    {
        controlTarget.Rotate(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
    }
    private void InputInteractAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            controlTarget.Interact();
        }
    }
    private void InputJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controlTarget.Jump();
        }
    }
}
