using UnityEngine;
using UnityEngine.UI;

public class SplashUI: MonoBehaviour
{
    public float duration = 2.0f;
    public Text label;

    private void OnEnable()
    {
        Invoke(nameof(Hide), duration);
    }

    public void Show(string text)
    {
        label.text = text;
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}