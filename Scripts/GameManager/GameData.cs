using System;

[Serializable]
public class GameData
{
    public int coins;
    public int[] bait; // Массив для хранения количества наживки (4 типа)
    public int[] fish; // Массив для хранения количества пойманных рыб (4 вида)

    public GameData()
    {
        coins = 0;
        bait = new int[4];
        fish = new int[4];
    }
}