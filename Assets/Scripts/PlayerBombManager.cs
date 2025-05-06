using UnityEngine;
using UnityEngine.Events;

public class LayerBombManager : MonoBehaviour
{

    InputManager InputManager;
    public GameObject bombPrefab;

    private void Awake()
    {
        InputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        InputManager.OnBombPressed.AddListener(DeployBomb);
    }

    private void OnDisable()
    {
        InputManager.OnBombPressed.RemoveListener(DeployBomb);
    }

    private void DeployBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
