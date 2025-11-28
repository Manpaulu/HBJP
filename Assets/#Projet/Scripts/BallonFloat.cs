using UnityEngine;
using UnityEngine.EventSystems;

public class BalloonFloat : MonoBehaviour, IPointerClickHandler
{
    public float moveSpeed = 50f;       // vitesse verticale
    public float floatAmplitude = 20f;  // flottement horizontal
    public float floatFrequency = 1f;   // vitesse du flottement horizontal

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
        StartCoroutine(FloatCoroutine());
    }

    private System.Collections.IEnumerator FloatCoroutine()
    {
        while (true)
        {
            // Déplacement vertical
            transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;

            // Flottement horizontal
            float offsetX = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            transform.localPosition = new Vector3(startPos.x + offsetX, transform.localPosition.y, startPos.z);

            // Détruire le ballon si il sort du haut
            if (transform.localPosition.y > 2600) // Ajuste selon ton Canvas
            {
                Destroy(gameObject);
                yield break;
            }

            yield return null;
        }
    }

    // Disparaît quand on clique dessus
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
