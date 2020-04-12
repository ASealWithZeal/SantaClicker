using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowflakeScript : MonoBehaviour
{
    private RectTransform t;
    private Image im;
    private float fallSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<RectTransform>();
        im = GetComponent<Image>();
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        transform.localPosition = new Vector2(Random.Range(-325, 320), 565);

        StartCoroutine(FallDown());
    }

    public void Init(float speed)
    {
        fallSpeed = speed;
    }

    IEnumerator FallDown()
    {
        while (t.localPosition.y > -300)
        {
            t.position -= new Vector3(0, fallSpeed, 0);
            yield return new WaitForSeconds(0.02f);
        }
        while (t.localPosition.y > -450)
        {
            t.position -= new Vector3(0, fallSpeed, 0);
            im.color -= new Color(0, 0, 0, fallSpeed * 0.0075f);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }
}
