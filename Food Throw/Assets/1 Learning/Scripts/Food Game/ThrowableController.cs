using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableController : MonoBehaviour
{
    private GameController _gameController;
    
    public void Initialize(GameController gameController)
    {
        _gameController = gameController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Target")) return;
        
        _gameController.AddScore();
        Destroy(gameObject);
    }
}