using UnityEngine;
using UnityEngine.UI;

public class NumericInputValidator : MonoBehaviour
{
    private InputField inputField;

    private void Start()
    {
        // Get the reference to the InputField component
        inputField = GetComponent<InputField>();

        // Add a listener to the OnValueChanged event of the InputField
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string newText)
    {
        // Remove any non-numeric characters from the input
        string numericText = RemoveNonNumericCharacters(newText);

        // Update the InputField text with the cleaned numeric text
        inputField.text = numericText;
    }

    private string RemoveNonNumericCharacters(string input)
    {
        // Use a regular expression to remove non-numeric characters
        return System.Text.RegularExpressions.Regex.Replace(input, "[^0-9]", "");
    }
}