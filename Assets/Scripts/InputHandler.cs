using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public string pName;
    public ScoreManager scoreManager;

    public void ReadStringInput(string s)
    {
        pName = s;
        scoreManager.currentPlayerName = pName;
    }
}
