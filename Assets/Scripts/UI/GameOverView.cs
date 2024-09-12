using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _goToMenuButton;
    [SerializeField] private GameView _gameView;
    [SerializeField] private GameObject _gameOverView; 
    private void Start()
    {
        _goToMenuButton.onClick.AddListener(GoToMenu);
        _restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        _gameView.Reset();
        CommandQueue.Instance.AddCommand(new RestartCommand());
    }

    private void GoToMenu()
    {
        CommandQueue.Instance.AddCommand(new GoToMenuCommand());
    }
    public void ActiveGameOverPanel()
    {
        _gameView.DontStartButtonPressed();
        _gameOverView.SetActive(true);
    }
    public void DeactivateGameOverPanel()
    {
        _gameOverView.SetActive(false);
    }
}
