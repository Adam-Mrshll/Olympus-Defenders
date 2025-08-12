using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400; // starting player money

    void Start()
    {
        Money = startMoney;
    }
}
