﻿using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public int startMoney = 400;
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    public static void TakeDamage()
    {
        Lives--;

        if(Lives <= 0)
        {
            GameManager.instance.EndGame();
        }
    }
}
