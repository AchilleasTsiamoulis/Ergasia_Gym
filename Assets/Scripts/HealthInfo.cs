using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthInfo : MonoBehaviour
{
    public GameObject healthInfoPanel;
    public TextMeshProUGUI muscleText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI enduranceText;
    private PlayerController playerController;

    private int muscle = 30;
    private int weight = 80;
    private int endurance = 30;

    private bool isPanelVisible = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        healthInfoPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleHealthInfoPanel();
        }
    }

    void ToggleHealthInfoPanel()
    {
        isPanelVisible = !isPanelVisible;
        healthInfoPanel.SetActive(isPanelVisible);

        if (isPanelVisible)
        {
            UpdateHealthInfo();
            playerController.LockControls();
        }
        else
        {
            playerController.UnlockControls();
        }
    }

    void UpdateHealthInfo()
    {
        muscleText.text = $"Μύης: {muscle} ({GetMuscleCondition(muscle)})";
        weightText.text = $"Βάρος: {weight} ({GetWeightCondition(weight)})";
        enduranceText.text = $"Aντοχή: {endurance} ({GetEnduranceCondition(endurance)})";
    }

    string GetMuscleCondition(int value)
    {
        if (value >= 0 && value <= 30) return "Καθόλου Μυική Μάζα";
        else if (value > 30 && value <= 60) return "Λίγη Μυική Μάζα";
        else if (value > 60 && value <= 90) return "Πολύ Μυική Μάζα";
        else return "Υπερβολική Μυική Μάζα";
    }

    string GetWeightCondition(int value)
    {
        if (value >= 0 && value <= 45) return "Πολύ Λεπτός";
        else if (value > 45 && value <= 60) return "Λεπτός";
        else if (value > 60 && value <= 75) return "Κανονικός";
		else if (value > 75 && value <= 100) return "Υπέρβαρος";
        else return "Παχύσαρκος";
    }

    string GetEnduranceCondition(int value)
    {
        if (value >= 0 && value <= 25) return "Πολύ Χαμηλή";
        else if (value > 25 && value <= 50) return "Χαμηλή";
        else if (value > 50 && value <= 75) return "Υψηλή";
        else return "Άριστη";
    }

    public void Change()
    {
        muscle += 5;
        weight -= 1;
        endurance += 5;
        UpdateHealthInfo();
    }
}
