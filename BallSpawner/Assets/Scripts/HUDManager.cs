using System.Collections;
using TMPro;
using UnityEngine;
public class HUDManager : MonoBehaviour
{
    const string scoreTemplate = "Score: {0}";

    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    private void OnEnable()
    {
        ScoreCounter.OnObstacleEnd += UpdateScore;
        playerMovement.OnGameEvent += Player_OnGameEvent; ;
    }

    private void PlayerMovement_OnGameEvent()
    {
        throw new System.NotImplementedException();
    }

    private void Player_OnGameEvent(eGameEvent gameEvent)
    {
        switch (gameEvent)
        {
            case eGameEvent.GAME_START:
                break;
            case eGameEvent.GAME_PAUSE:
                break;
            case eGameEvent.GAME_OVER:
                ShowGameOver();
                break;
            default:
                break;
        }
    }
    private void OnDisable()
    {
        ScoreCounter.OnObstacleEnd -= UpdateScore;
        playerMovement.OnGameEvent -= Player_OnGameEvent;
    }
    private void UpdateScore(GameObject obstacle, int newScore)
    {
        scoreText.text = string.Format(scoreTemplate, newScore);
    }
    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

}