using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject mycube;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    mycube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Vector3 touchPoint = touch.position;
                    touchPoint.z = 8;
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touchPoint);
                    break;
                case TouchPhase.Moved:
                    if (mycube != null)
                    {
                        touchPoint = touch.position;
                        touchPoint.z = 6;
                        touchPosition = Camera.main.ScreenToWorldPoint(touchPoint);
                        mycube.transform.position = touchPosition;

                    }

                    break;
                case TouchPhase.Stationary:

                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Canceled:
                   
                    if (mycube != null)
                    {
                        Destroy(mycube);
                    }
                    break;
                default:
                    break;
            }

        }
    }
}