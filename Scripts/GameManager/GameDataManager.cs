using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = "/Users/dimakulinich/FishingSimulator/Assets/Scripts/GameManager/gamedata.json";
    }

    public void SaveGameData(GameData data)
    {
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public GameData LoadGameData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        else
        {
            return null;
        }
    }

    public bool GameDataExists()
    {
        return File.Exists(filePath);
    }
}