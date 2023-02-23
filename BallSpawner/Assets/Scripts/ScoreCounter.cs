using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreCounter : MonoBehaviour
{
    public const string obstacleTag = "Obstracle";
    private int playerScore;
    public delegate void ObstacleReachedEnd(GameObject obstacle, int newScore);
    public static event ObstacleReachedEnd OnObstacleEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            playerScore++;
            OnObstacleEnd?.Invoke(other.gameObject, playerScore);
        }
    }
}