using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400; // starting player money

    public static int Lives;
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
