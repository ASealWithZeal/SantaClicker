using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public bool purchased = false;
    public bool affectsPlayer = false;
    public string cName = "";
    public int cost = 0;
    public float increase = 0.0f;

    public Button button = null;
    public List<TextMeshProUGUI> cText = null;
    public HireButton hiree;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        cText[0].SetText(cName);

        if (affectsPlayer) cText[1].SetText("+" + increase + " months per click");
        else cText[1].SetText("+" + increase + " months per second to " + hiree.cName);
        cText[2].SetText("Cost:");
        if (cost != 1) cText[3].SetText(cost + " Gifts");
        else cText[3].SetText(cost + " Gift");
    }

    public void CheckButton(int gifts)
    {
        if (gifts >= cost && !purchased)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void ClickButton()
    {
        RemovePurchase();
        if (affectsPlayer) Managers.GiftManager.Instance.IncreaseMonthsPerClick(cost, increase);
        else hiree.Upgrade(cost, increase);
    }

    /// <summary>
    /// Disables and changes the button's visuals
    /// </summary>
    private void RemovePurchase()
    {
        purchased = true;

        // Changes Button Visuals
        button.image.color = new Color(0.5f, 0.5f, 0.5f);
        ColorBlock colors = button.colors;
        colors.disabledColor = Color.white;
        button.colors = colors;
        button.interactable = false;

        // Change Text
        cText[2].SetText("");
        cText[3].fontStyle = FontStyles.Bold;
        cText[3].SetText("PURCHASED");
    }

    /// <summary>
    /// Re-enables button for hiring purposes
    /// </summary>
    public void AddPurchasing()
    {
        purchased = false;

        // Changes Button Visuals
        button.image.color = new Color(1f, 1f, 1f);
        ColorBlock colors = button.colors;
        colors.disabledColor = new Color(0.1960784f, 0.1960784f, 0.1960784f, 0.3921569f);
        button.colors = colors;
        button.interactable = false;

        // Change Text
        cText[2].SetText("Cost:");
        cText[3].fontStyle = FontStyles.Normal;
        cText[3].SetText(cost.ToString());
    }
}
