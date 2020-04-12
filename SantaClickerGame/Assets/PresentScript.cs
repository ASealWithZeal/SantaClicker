using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentScript : MonoBehaviour
{
    public Sprite[] giftSprites = null;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = giftSprites[Random.Range(0, giftSprites.Length)];
    }

    public void DestroyGift()
    {
        Destroy(gameObject);
    }
}
