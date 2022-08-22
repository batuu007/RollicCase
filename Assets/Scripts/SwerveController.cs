using UnityEngine;
using UnityEngine.Events;

public class SwerveController : MonoBehaviour
{
    [SerializeField] private float _mouseSpeed;

    private Vector3 _firstPos, _endPos;

    private float _difference;

    private void FixedUpdate()
    {
        SwerveMovement();
    }
    public void SwerveMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            _endPos = Input.mousePosition;
            _difference = _endPos.x - _firstPos.x;
            transform.Translate(_difference * _mouseSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _firstPos = Vector3.zero;
            _endPos = Vector3.zero;
        }
    }

}