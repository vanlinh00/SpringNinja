using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static InforPlayer inforPlayer;
    static DataPlayer()
    {
        inforPlayer = JsonUtility.FromJson<InforPlayer>(PlayerPrefs.GetString(ALL_DATA));

        if (inforPlayer == null)
        {
            inforPlayer = new InforPlayer
            {
                idLoadGameAgain = false,
                bestScore = 0,
 
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(inforPlayer);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static void UpdataLoadGameAgain(bool IsLoadGameAgain)
    {
        inforPlayer.idLoadGameAgain = IsLoadGameAgain;
        SaveData();
    }

    public static void UpdateBestScore(int Score)
    {
        inforPlayer.bestScore = Score;
        SaveData();
    }

    public static InforPlayer getInforPlayer()
    {
        return inforPlayer;
    }

}
public class InforPlayer
{
    public bool idLoadGameAgain;
    public int bestScore;
}