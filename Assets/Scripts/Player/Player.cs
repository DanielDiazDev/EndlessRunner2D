using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameFacade _gameFacade;
    private float _score;
    private float _speed = 5;
    private bool _isGameOver;
    private bool _isStart;
    private Animator _animator;
    private void Start()
    {
        _gameFacade = ServiceLocator.Instance.GetService<GameFacade>();
        _animator = GetComponentInChildren<Animator>();
        RestartCommand.OnRestart += Reset;
        GameView.OnStart += StartPlay;
    }
    private void OnDestroy()
    {
        RestartCommand.OnRestart -= Reset;
        GameView.OnStart -= StartPlay;
    }
    public void OnDeath()
    {
        _isGameOver = true;
        _animator.SetBool("IsDead", true);

        StartCoroutine(HandleDeath());
    }

    private IEnumerator HandleDeath()
    {
        AnimatorStateInfo animationState = _animator.GetCurrentAnimatorStateInfo(0);
        while (!animationState.IsName("Death"))
        {
            yield return null;
            animationState = _animator.GetCurrentAnimatorStateInfo(0);
        }
        yield return new WaitForSeconds(animationState.length);
        _gameFacade.GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isGameOver && _isStart)
        {
            _score += _speed * Time.deltaTime;
            _gameFacade.UpdateScore(float.Parse(_score.ToString("F2")));
        }
    }
    private void StartPlay()
    {
        _isStart = true;
        _animator.SetFloat("Running", 1);
    }
    public bool IsGameOver()
    {
        return _isGameOver;
    }
    public bool IsStart()
    {
        return _isStart;
    }
    private void Reset()
    {
        _score = 0;
        _animator.SetFloat("Running", -1);
        _animator.SetBool("IsDead", false);
        _isStart = false;
        _isGameOver = false;
    }
}
