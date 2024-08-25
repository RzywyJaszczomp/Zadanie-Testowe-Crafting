using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed = 20; 
    private Rigidbody _rigidbody;
    private Vector3 _movementVector;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        _rigidbody.AddRelativeForce(_movementVector * _MovementSpeed, ForceMode.Force);
    }

    public void OnMove(InputValue value)
    {
        var movVec = value.Get<Vector2>().normalized;
        _movementVector = new Vector3(movVec.x, 0, movVec.y);
    }
}
