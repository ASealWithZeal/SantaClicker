using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftManager : MonoBehaviour
{
    public int gifts = 0;
    public int months = 12;
    public float monthsPerSecond = 0.0f;
    public UIManager ui = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gifts >= 1 && ui.hireText[1].text != "HIRED")
            ui.hireButton.interactable = true;
    }

    public void HitSanta()
    {
        months--;
        if (months <= 0)
        {
            months = 12;
            gifts++;
        }

        ui.SetText(gifts, months, monthsPerSecond);
    }

    public void Hire()
    {
        gifts--;
        monthsPerSecond = 0.25f;
        ui.SetText(gifts, months, monthsPerSecond);
        ui.SetButton();
    }
}
