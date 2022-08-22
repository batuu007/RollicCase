using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet;

    private float smoothSpeed = 0.150f;

    private void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 desiredPos = _target.position + _offSet;
            Vector3 newPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = newPos;
        }
        else
        {
            return;
        }
    }
}
