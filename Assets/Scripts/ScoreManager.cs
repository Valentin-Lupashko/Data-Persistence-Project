using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public InputHandler inputHandler;
    public TextMeshProUGUI menuHighScoreText;

    public int hScore;
    public string currentPlayerName;
    public string bestPlayerName;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();

        menuHighScoreText.text = $"Best score : {bestPlayerName} : {hScore}";
    }

    [System.Serializable]
    class SaveData
    {
        public int hScore;
        public string bestPlayerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.hScore = hScore;
        data.bestPlayerName = currentPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // public void SaveName()
    // {
    //     SaveData data = new SaveData();
    //     data.playerName = playerName;

    //     string json = JsonUtility.ToJson(data);

    //     File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    // }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hScore = data.hScore;
            bestPlayerName = data.bestPlayerName;
        }
    }
}
