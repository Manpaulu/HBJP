using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    public Image imageToBlink;  // L'image à faire clignoter
    public float blinkSpeed = 0.2f;  // Durée entre ON/OFF
    public float duration = 5f;      // Durée totale du clignotement

    public TypeText typeText;   

    private void Start()
    {
        if(typeText == null) typeText = FindAnyObjectByType<TypeText>();
        imageToBlink.enabled = false;
        typeText.endTyping += BlinkStart; 
    }

    void BlinkStart()
    {
        StartCoroutine(Blink());
    }

    private System.Collections.IEnumerator Blink()
    {
        float timer = 0f;

        while (timer < duration)
        {
            imageToBlink.enabled = !imageToBlink.enabled;
            yield return new WaitForSeconds(blinkSpeed);
            timer += blinkSpeed;
        }

        imageToBlink.enabled = true; // Rallume l’image à la fin (optionnel)
    }
}
