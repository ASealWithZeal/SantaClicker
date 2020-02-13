using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text months;
    public Text gifts;

    private int monthNum = 12;
    private int giftNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitSanta()
    {
        monthNum--;
        if (monthNum <= 0)
        {
            monthNum = 12;
            giftNum++;
            gifts.text = giftNum.ToString() + "\nGifts";
        }

        months.text = monthNum.ToString() + "\nMonths";
    }
}
