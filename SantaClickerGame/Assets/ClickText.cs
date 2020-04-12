using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickText : MonoBehaviour
{
    private TextMeshProUGUI t;

    public void Init(float val)
    {
        transform.position = Input.mousePosition;

        string s = "+" + (Mathf.FloorToInt(val * 10.0f) / 10.0f).ToString();
        if (val == 1)
            s += " Month";
        else
            s += " Months";

        t = GetComponent<TextMeshProUGUI>();
        t.SetText(s);
        t.color += new Color(0, 0, 0, 1);

        StartCoroutine(Rise());
    }

    IEnumerator Rise()
    {
        RectTransform rt = GetComponent<RectTransform>();
        while (t.color.a > 0)
        {
            rt.anchoredPosition += new Vector2(0, 1.5f);
            t.color -= new Color(0, 0, 0, 0.025f);
            yield return new WaitForSeconds(0.02f);
        }

        Destroy(gameObject);
    }
}
