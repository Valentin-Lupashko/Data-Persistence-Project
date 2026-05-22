using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public string playerName;

    public void ReadStringInput(string s)
    {
        playerName = s;
        Debug.Log(playerName);
    }
}
