using UnityEngine;
using TMPro;

public class TimeDisplay24HR : MonoBehaviour
{
    public TextMeshPro timeText;

    void Update()
    {
        System.DateTime currentTime = System.DateTime.Now;

        string timeString = currentTime.ToString("HH:mm:ss");

        if (timeText != null)
        {
            timeText.text = timeString;
        }
    }
}
