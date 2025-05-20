using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayersManager : MonoBehaviour
{

    PlayerInputManager playerInputManager;
    [SerializeField] List<Transform> spawnPos;
    [SerializeField] List<Material> playerMaterial;
    
    

    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    public void OnPlayerJoin(PlayerInput playerinput)
    {
        playerinput.gameObject.transform.position = spawnPos[playerInputManager.playerCount -1].position;
        playerinput.gameObject.GetComponent<MeshRenderer>().material =
            playerMaterial[playerInputManager.playerCount - 1];
    }
    public void OnPlayerLeft(PlayerInput playerInput)
    {

    }

   

}
