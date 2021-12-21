using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMovement : MonoBehaviour
{


    private PlayerInputsTest playerInputsTest;


    private void Awake()
    {
        playerInputsTest = new PlayerInputsTest();
    }

    private void OnEnable()
    {
        playerInputsTest.Enable();
    }

    private void OnDisable()
    {
        playerInputsTest.Disable();
    }


    private void Update()
    {
        var movement_direction = playerInputsTest.Player.KeyboardMove.ReadValue<Vector2>();

        transform.position += new Vector3(movement_direction.x, 0f,movement_direction.y) * 10f * Time.deltaTime;
    }
}
