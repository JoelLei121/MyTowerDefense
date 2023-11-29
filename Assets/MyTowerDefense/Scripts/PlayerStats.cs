using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 400;

    public static int Lives;
    public int startLives = 10;

    public static int Rounds;

    void Start()
    {
        Money = StartMoney;
        Lives = startLives;
        Rounds = 0;
    }

    //Todo: add money per second
}
