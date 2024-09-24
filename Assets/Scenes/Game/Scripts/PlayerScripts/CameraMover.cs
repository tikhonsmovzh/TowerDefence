using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Joystick _moveJoy;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _borders;

    void LateUpdate()
    {
        _cameraTransform.position += new Vector3(
            Mathf.Clamp(_moveJoy.Horizontal + Input.GetAxis("Horizontal"), -1, 1),
            Mathf.Clamp(_moveJoy.Vertical + Input.GetAxis("Vertical"), -1, 1), 0
            ) * Time.deltaTime * _moveSpeed;

        _cameraTransform.position = new Vector3(
            Mathf.Clamp(_cameraTransform.position.x, -_borders.x, _borders.x),
            Mathf.Clamp(_cameraTransform.position.y, -_borders.y, _borders.y), _cameraTransform.position.z);
    }
}
