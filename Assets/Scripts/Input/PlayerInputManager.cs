using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private bool _lockCursor = true;
    [SerializeField] private bool _disableControls = false;
    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        if(_lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(_disableControls)
        {
            _input.actions.Disable();
        }
    }

    public void SetInputMapToInventory()
    {
        _input.SwitchCurrentActionMap("UI");
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SetInputMapToGame()
    {
        _input.SwitchCurrentActionMap("Player");
        if(_lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
