using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunchAction : MonoBehaviour
{
    [HideInInspector]
    public bool hasLaunched;

    LaunchBall Ball;

    private void Awake()
    {
        Ball = GameObject.FindObjectOfType<LaunchBall>()?.GetComponent<LaunchBall>();
    }

    private void Update()
    {
        Launch();
    }

    void Launch()
    {
        if (Ball != null)
        {
            if (Input.GetButtonDown("Fire1") && Ball.CanFire == true)
            {
                Debug.Log("Fire");
                hasLaunched = true;
            }
        }

        else
        {
            Ball = null;
        }
    }
}
