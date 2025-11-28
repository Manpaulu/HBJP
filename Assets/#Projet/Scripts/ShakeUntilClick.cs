using UnityEngine;
using UnityEngine.EventSystems;

public class ShakeUntilClick : MonoBehaviour, IPointerClickHandler
{
    public float shakeAmount = 10f;   // amplitude du shake
    public float shakeSpeed = 10f;    // vitesse
    private Vector3 initialPos;
    private bool shaking = true;

    void Start()
    {
        initialPos = transform.localPosition;
        StartCoroutine(Shake());
    }

    private System.Collections.IEnumerator Shake()
    {
        while (shaking)
        {
            // Mouvement en sinus
            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float offsetY = Mathf.Cos(Time.time * shakeSpeed * 0.8f) * shakeAmount * 0.5f;

            transform.localPosition = initialPos + new Vector3(offsetX, offsetY, 0);

            yield return null;
        }

        // Remet en place proprement après l'arrêt
        transform.localPosition = initialPos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        shaking = false; // On arrête la secousse quand on clique dessus
    }
}