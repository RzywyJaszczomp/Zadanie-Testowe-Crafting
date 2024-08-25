using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
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

    public void RegisterInventory(GameObject inventory)
    {
        var playerMap = _input.actions.FindActionMap("Player");
        var menuMap = _input.actions.FindActionMap("Menu");

        playerMap.FindAction("OpenInventory").performed += _ => inventory.GetComponent<InventoryScript>().OnOpenInventory(); 
        menuMap.FindAction("CloseInventory").performed += _ => inventory.GetComponent<InventoryScript>().OnCloseInventory(); 
    }
    public void RegisterPlayer(GameObject player)
    {
        var playerMap = _input.actions.FindActionMap("Player");
        playerMap.FindAction("Move").performed += ctx => player.GetComponent<PlayerMovement>().OnMove(ctx); 
        playerMap.FindAction("Move").canceled += ctx => player.GetComponent<PlayerMovement>().OnMove(ctx); 
        playerMap.FindAction("Look").performed += ctx => player.GetComponent<CameraLookAt>().OnLook(ctx); 
        playerMap.FindAction("Interact").performed += _ => player.GetComponent<InteractionMaker>().OnInteract(); 
    }

    public void SetInputMapToInventory()
    {
        _input.SwitchCurrentActionMap("Menu");
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

    private void Test()
    {
        Debug.Log("Test");
    }
}
