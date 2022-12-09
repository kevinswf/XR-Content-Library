using UnityEngine;
using TMPro;

public class ConsoleToText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI debugText;

    private string output = "";
    private string stack = "";

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
        ClearLog();
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // append the new log
        output = logString + "\n" + output;

        stack = stackTrace;
    }

    private void OnGUI()
    {
        debugText.text = output;
    }

    private void ClearLog()
    {
        output = "";
    }
}
