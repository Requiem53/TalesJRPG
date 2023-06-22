using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : ReferenceManager
{
    [SerializeField] private PlayerMoveeProperties playerMoveReference;

    private void OnEnable(){
        PlayerMovementInput.OnPlayerMovementInputCreation += AssignPlayerMove;
    }

    private void OnDisable(){
        PlayerMovementInput.OnPlayerMovementInputCreation -= AssignPlayerMove;
    }

    private void AssignPlayerMove(PlayerMovementInput playerMovementInput){
        playerMovementInput.PlayerMoveeProperties = playerMoveReference;
    }
}
