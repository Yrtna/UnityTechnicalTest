using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject model;
    [SerializeField]
    private float speed = 10f;

    private float hAxis;
    private float vAxis;

    private Vector3 mousePos;
    private int groundMask;

    private CharacterController characterController;

    void Start()
    {
        groundMask = LayerMask.GetMask("Ground");
        characterController = GetComponent<CharacterController>();
        // Set default mouse position as player position
        mousePos = gameObject.transform.position;
    }

    void Update()
    {
        // Mouse World Position
        mousePos = GetMouseWorldPosition();

        // Player Keyboard Input
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Rotate Player
        model.transform.LookAt(mousePos);

        // Move Player
        var movement = transform.TransformDirection(new Vector3(hAxis, 0, vAxis)) * speed;
        characterController.Move(movement * Time.fixedDeltaTime);
    }

    private Vector3 GetMouseWorldPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // return mouse position if ray hit Ground layer
        // return former mouse position if ray didn't hit
        return Physics.Raycast(ray, out var rayHit, 100, groundMask)
            ? new Vector3(rayHit.point.x, gameObject.transform.position.y, rayHit.point.z)
            : mousePos;
    }
}