using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SantaHeadScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<Sprite> santaImages;
    public Image theImage;
    private bool pulsing = true;
    private bool canPulse = true;
    private float pulseSpeed = 0.025f;
    private float pulseAmount = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        theImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Pulse();
    }

    private void Pulse()
    {
        if (canPulse)
        {
            if (!pulsing && theImage.rectTransform.localScale.x < 1.025f)
                theImage.rectTransform.localScale += new Vector3(pulseAmount * Time.deltaTime, pulseAmount * Time.deltaTime);
            else if (!pulsing && theImage.rectTransform.localScale.x >= 1.025f)
                pulsing = true;
            else if (pulsing && theImage.rectTransform.localScale.x > 0.975f)
                theImage.rectTransform.localScale -= new Vector3(pulseAmount * Time.deltaTime, pulseAmount * Time.deltaTime);
            else if (pulsing && theImage.rectTransform.localScale.x <= 0.975f)
                pulsing = false;
        }
    }

    public void CheckSantaColor(float percent)
    {
        if (percent < 0.5f)
            theImage.sprite = santaImages[0];
        else if (percent >= 0.5f && percent < 0.75f)
            theImage.sprite = santaImages[1];
        else if (percent >= 0.75f)
            theImage.sprite = santaImages[2];
    }

    public void OnPointerEnter(PointerEventData pointer)
    {
        theImage.rectTransform.localScale = new Vector3(1.05f, 1.05f);
        canPulse = false;
    }
    
    public void OnPointerExit(PointerEventData pointer)
    {
        theImage.rectTransform.localScale = new Vector3(1f, 1f);
        canPulse = true;
    }
}
