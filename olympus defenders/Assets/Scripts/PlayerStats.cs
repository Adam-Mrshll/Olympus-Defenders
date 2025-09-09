using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400; // starting player money

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start() // runs when the object is created
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }

}
