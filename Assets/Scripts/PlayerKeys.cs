using UnityEngine;
using UnityEngine.UI;

public class PlayerKeys : MonoBehaviour
{
    public int currentKeyLevel = 0;
    public Text keyText; // UI text to show key status

    public void AddKey(int level)
    {
        currentKeyLevel = level;
        if (keyText != null)
            keyText.text = "Key Level: " + currentKeyLevel;
    }

    public bool HasKey(int requiredLevel)
    {
        return currentKeyLevel >= requiredLevel;
    }
}
