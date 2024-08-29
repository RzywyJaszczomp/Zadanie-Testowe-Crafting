using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _cameraSensitivityV = 70f;
    [SerializeField] private float _cameraSensitivityH = 50f;
    [SerializeField] private float _verticalMaxAngle = 80f;
    private float _yRotationD = 0f;
    private float _xRotation = 0f;


    void Update()
    {
        transform.Rotate(Vector3.up, _yRotationD);
        _camera.localEulerAngles = new Vector3(_xRotation, 0, 0);

    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        var lookVec = ctx.ReadValue<Vector2>();
        _yRotationD = lookVec.x * _cameraSensitivityH;
        var xRotationD = lookVec.y * _cameraSensitivityV;
        _xRotation -= xRotationD;
        _xRotation = Mathf.Clamp(_xRotation, -_verticalMaxAngle, _verticalMaxAngle);
    }
}
