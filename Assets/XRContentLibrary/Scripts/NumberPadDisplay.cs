using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberPadDisplay : MonoBehaviour
{
    [SerializeField]
    private string correctCode;
    [SerializeField]
    private TextMeshProUGUI codeText;
    [SerializeField]
    private GameObject keycardPrefab;
    [SerializeField]
    private Transform keycardSpawnLocation;

    private string currentInput;
    private string codeDisplayText;
    private bool keycardSpawned = false;

    void OnEnable()
    {
        TouchButton.onButtonPress += receiveButtonNumber;
    }

    void OnDisable()
    {
        TouchButton.onButtonPress -= receiveButtonNumber;
    }

    private void receiveButtonNumber(int number)
    {
        // add a new digit to the code
        currentInput = currentInput + number;
        codeDisplayText = codeDisplayText + "*";
        codeText.text = codeDisplayText;

        // when 4 digits are entered, check code
        if (currentInput.Length >= 4)
        {
            if (currentInput.Equals(correctCode))
            {
                // show correct
                codeDisplayText = "Code Valid";
                codeText.color = Color.green;
                codeText.text = codeDisplayText;

                // dispense the keycard
                if (!keycardSpawned)
                {
                    Instantiate(keycardPrefab, keycardSpawnLocation.position, keycardSpawnLocation.rotation, transform);
                    keycardSpawned = true;
                }
            }
            else
            {
                // show incorrect
                codeDisplayText = "Code invalid";
                codeText.color = Color.red;
                codeText.text = codeDisplayText;
            }


            // clear the code
            currentInput = "";
            StartCoroutine(ClearCodeDisplay());
        }
    }

    // Wait some time to clear the display
    private IEnumerator ClearCodeDisplay()
    {
        yield return new WaitForSeconds(2);

        codeDisplayText = "";
        codeText.color = Color.black;
        codeText.text = codeDisplayText;
    }
}
