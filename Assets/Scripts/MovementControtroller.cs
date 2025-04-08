using UnityEngine;

public class MovementControtroller : MonoBehaviour
{
    InputManager inputManager;
    CharacterController CharacterController;

    [SerializeField] float speed;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        CharacterController = GetComponent<CharacterController>();

    }

    
    private void Update()
    {
        if (inputManager.moveDir.magnitude!= 0)
        {
            transform.forward = new Vector3(inputManager.moveDir.x, 0, inputManager.moveDir.y);
            CharacterController.Move(transform.forward * speed * Time.deltaTime);
        }
    }
}
