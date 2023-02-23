using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour

{
    public float speed;
    private Vector3 direction;
    public delegate void GameEvent(eGameEvent e);
    public static event GameEvent OnGameEvent;
    public bool isGameRunning;
     void Start()
    {
        isGameRunning = true;
    }
    void Update()
    {
        direction = Vector3.zero;
     
        if(isGameRunning)
        {
            direction.z = Input.acceleration.y;
            direction.x = Input.acceleration.x;


            if (direction.sqrMagnitude > 0) 
            direction.Normalize();



            transform.Translate(direction * speed * Time.deltaTime);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag(ScoreCounter.obstacleTag))
        {
            isGameRunning = false;
            OnGameEvent?.Invoke(eGameEvent.GAME_OVER);           
        }
    }
}

public enum eGameEvent
{
    GAME_START,
    GAME_PAUSE,
    GAME_OVER
}

