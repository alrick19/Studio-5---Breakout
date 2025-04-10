﻿using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private float cameraShakeDuration = 1f;
    [SerializeField] private float cameraShakeStrength = 0.5f;
    [SerializeField] private GameObject brickDestroyEffect;

    private int currentBrickCount;
    private int totalBrickCount;
    

    private void OnEnable()
    {   
        InputHandler.Instance.OnFire.AddListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        ball.FireBall();
    }

    public void OnBrickDestroyed(Vector3 position)
    {
        // fire audio here
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.brick);
        
        // implement particle effect here
        Instantiate(brickDestroyEffect, position, Quaternion.Euler(-90, 0, 0));

        // add camera shake here
        CameraShake.Shake(cameraShakeDuration, cameraShakeStrength);

        currentBrickCount--;
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        if (currentBrickCount == 0) SceneHandler.Instance.LoadNextScene();
    }

    public void KillBall()
    {
        maxLives--;
        // update lives on HUD here
        // game over UI if maxLives < 0, then exit to main menu after delay
        ball.ResetBall();
    }
}
