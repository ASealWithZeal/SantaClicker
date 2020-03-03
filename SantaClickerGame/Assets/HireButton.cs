using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HireButton : MonoBehaviour
{
    public bool hired = false;
    public string cName = "";
    private int cHiringCost = 0;
    public int oHiringCost = 0;
    private float cMonthBonus = 0.0f;
    public float oMonthBonus = 0.0f;

    public Button button = null;
    public List<TextMeshProUGUI> cText = null;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
        cHiringCost = oHiringCost;
        cMonthBonus = oMonthBonus;

        cText[0].SetText(cName);

        if (oMonthBonus != 1) cText[1].SetText("+" + oMonthBonus + " months per second");
        else cText[1].SetText("+" + oMonthBonus + " month per second");
        cText[2].SetText("Cost:");
        if (oHiringCost != 1) cText[3].SetText(oHiringCost + " Gifts");
        else cText[3].SetText(oHiringCost + " Gift");
    }

    /// <summary>
    /// Upgrades the hired hand depicted in the button
    /// </summary>
    /// <param name="upgradeAmount"></param>
    public void Upgrade(int cost, float upgradeAmount)
    {
        cMonthBonus += upgradeAmount;
        if (cMonthBonus != 1) cText[1].SetText("+" + cMonthBonus + " months per second");
        else cText[1].SetText("+" + cMonthBonus + " month per second");

        Managers.GiftManager.Instance.Hire(cost, cMonthBonus - upgradeAmount);
    }

    public void CheckButton(int gifts)
    {
        if (gifts >= cHiringCost && !hired)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void ClickButton()
    {
        RemoveHiring();
        Managers.GiftManager.Instance.Hire(cHiringCost, cMonthBonus);
    }

    /// <summary>
    /// Disables and changes the button's visuals
    /// </summary>
    private void RemoveHiring()
    {
        hired = true;

        // Changes Button Visuals
        button.image.color = new Color(0.5f, 0.5f, 0.5f);
        ColorBlock colors = button.colors;
        colors.disabledColor = Color.white;
        button.colors = colors;
        button.interactable = false;

        // Change Text
        cText[2].SetText("");
        cText[3].fontStyle = FontStyles.Bold;
        cText[3].SetText("HIRED");
    }

    /// <summary>
    /// Re-enables button for hiring purposes
    /// </summary>
    public void AddHiring()
    {
        hired = false;

        // Changes Button Visuals
        button.image.color = new Color(1f, 1f, 1f);
        ColorBlock colors = button.colors;
        colors.disabledColor = new Color(0.1960784f, 0.1960784f, 0.1960784f, 0.3921569f);
        button.colors = colors;
        button.interactable = false;

        // Change Text
        cText[2].SetText("Cost:");
        cText[3].fontStyle = FontStyles.Normal;
        cText[3].SetText(cHiringCost.ToString());
    }
}
