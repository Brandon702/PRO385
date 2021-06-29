using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float speed = 2;
    Vector2 input;
    public GameObject shot;

    void Start()
    {
        //GetComponent<PlayerInput>().onActionTriggered += HandleAction();
    }

    void Update()
    {
        transform.Translate(input * speed * Time.deltaTime);
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null) return; 
        //input = gamepad.leftStick.ReadValue();
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            onFire();
        }
    }

    public void onFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public void OnMove(InputAction.CallbackContext context) 
    { 
        input = context.ReadValue<Vector2>();
    }

    //private void HandleAction(InputAction.CallbackContext context)
    //{
    //    if(context.action.name == "Fire")
    //    {
    //        onFire();
    //    }
    //    if(context.action.name == "Move")
    //    {
    //        OnMove(context);
    //    }
    //}
}
