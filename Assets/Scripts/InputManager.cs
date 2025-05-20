using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

public class InputManager : MonoBehaviour
{
    
    

    public Vector2 moveDir;

    [HideInInspector]public UnityEvent onBombP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void OnAttack(CallbackContext context)
    {
        if (context.performed) onBombP?.Invoke();
    }

    public void OnMove(CallbackContext context)
    {
        if (context.performed) moveDir = context.ReadValue<Vector2>();
        else if(context.canceled) moveDir = Vector2.zero;
    }
    // Update is called once per frame
    

}
