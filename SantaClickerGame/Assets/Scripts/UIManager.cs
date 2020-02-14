﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text months;
    public Text gifts;
    public Button hireButton = null;
    public List<Text> hireText = null;

    public GameObject info = null;
    public GameObject settings = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(int giftNum, int monthNum)
    {
        gifts.text = giftNum.ToString() + "\nGifts";
        months.text = monthNum.ToString() + "\nMonths";
    }

    public void SetButton()
    {
        hireButton.image.color = new Color(0.5f, 0.5f, 0.5f);
        hireButton.interactable = false;
        hireText[0].text = "";
        hireText[1].fontStyle = FontStyle.Bold;
        hireText[1].text = "HIRED";
    }

    public void OpenScene(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        if (obj == info && info.activeSelf)
        {
            settings.SetActive(false);
        }

        if (obj == settings && settings.activeSelf)
        {
            info.SetActive(false);
        }
    }
}
