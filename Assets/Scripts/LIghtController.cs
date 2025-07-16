using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LIghtController : MonoBehaviour
{
    [SerializeField] GameObject RedLight;
    [SerializeField] GameObject GreenLight;
    [SerializeField] GameObject OrangeLight;
    [SerializeField] TextMeshProUGUI countdownText;


    private Color redColor;
    private Color greenColor;
    private Color orangeColor;

    void Start()
    {

        redColor = RedLight.GetComponent<Renderer>().material.color;
        greenColor = GreenLight.GetComponent<Renderer>().material.color;
        orangeColor = OrangeLight.GetComponent<Renderer>().material.color;

        StartCoroutine(SemaforoLight());
    }

    IEnumerator SemaforoLight()
    {
        while (true)
        {
            SetLight(GreenLight, greenColor);
            SetLight(RedLight, Color.black);
            SetLight(OrangeLight, Color.black);
            yield return Countdown(3f);

            SetLight(GreenLight, Color.black);
            SetLight(OrangeLight, orangeColor);
            yield return Countdown(3f);

            SetLight(OrangeLight, Color.black);
            SetLight(RedLight, redColor);
            yield return Countdown(3f);
        }
    }

    void SetLight(GameObject lightObject, Color color)
    {
        Renderer renderer = lightObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
    IEnumerator Countdown(float duration)
    {
        float timer = duration;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (countdownText != null)
                countdownText.text = timer.ToString("F1");
            yield return null;
        }

        if (countdownText != null)
            countdownText.text = "0.0";
    }
}
