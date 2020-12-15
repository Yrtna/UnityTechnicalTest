using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform Target;

    [SerializeField]
    private float cameraYPosOffset = 0f;
    [SerializeField]
    private float cameraZPosOffset = 0f;

    void Update()
    {
        var position = Target.position;
        gameObject.transform.position = new Vector3(position.x, position.y + cameraYPosOffset, position.z + cameraZPosOffset);
    }
}