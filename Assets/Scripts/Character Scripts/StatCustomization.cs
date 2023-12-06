using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatCustomizationController : MonoBehaviour
{
    public TMP_Text statPointsText;
    public TMP_Text[] statAllocationTexts; // Array of TextMeshPro components for displaying allocated stat points
    public Button[] increaseButtons; // Array of increase buttons corresponding to each stat
    public Button[] decreaseButtons; // Array of decrease buttons corresponding to each stat

    private int totalStatPoints = 10;
    private int[] statValues = new int[4]; // CHANGE THIS IF YOU ADD OR REMOVE A STAT

    void Start()
    {
        // Initialize stat values
        for (int i = 0; i < statValues.Length; i++)
        {
            statValues[i] = 2;
            int statIndex = i; // Capture the current value of i for the button click event

            // Attach button click events with lambda expressions to capture the stat index
            increaseButtons[i].onClick.AddListener(() => IncreaseStat(statIndex));
            decreaseButtons[i].onClick.AddListener(() => DecreaseStat(statIndex));
        }

        // Update UI
        UpdateUI();
    }

    void IncreaseStat(int statIndex)
    {
        if (totalStatPoints > 0)
        {
            // Increase the stat value
            statValues[statIndex]++;
            totalStatPoints--;

            // Update UI
            UpdateUI();
        }
    }

    void DecreaseStat(int statIndex)
    {
        if (statValues[statIndex] > 0)
        {
            // Decrease the stat value
            statValues[statIndex]--;
            totalStatPoints++;

            // Update UI
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Update the TMP text to display current stat points
        statPointsText.text = totalStatPoints.ToString();

        // Update allocated stat points for each stat
        for (int i = 0; i < statValues.Length; i++)
        {
            statAllocationTexts[i].text = statValues[i].ToString();
        }

        // You can update additional UI elements here based on your requirements
    }

    public void DoneWithStatCustomization()
    {
        PlayerPrefs.SetInt("InitialStrength", statValues[0]);
        PlayerPrefs.SetInt("InitialSpeed", statValues[1]);
        PlayerPrefs.SetInt("InitialJump", statValues[2]);
        PlayerPrefs.SetInt("InitialMaxHealth", statValues[3]);
        SceneManager.LoadScene("Shop");
    }
}
