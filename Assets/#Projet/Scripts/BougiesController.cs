using UnityEngine;
using UnityEngine.UI; 

public class BougiesController : MonoBehaviour
{
    public Image[] bougies; // Assigne tes 4 images dans l'inspecteur
    public float intervalle = 1f; // temps entre l'apparition des bougies en secondes

    private int index = 0;

    void Start()
    {
        // Désactive toutes les bougies au départ
        foreach (Image bougie in bougies)
        {
            bougie.gameObject.SetActive(false);
        }

        // Commence la coroutine pour allumer les bougies
        StartCoroutine(AllumerBougies());
    }

    System.Collections.IEnumerator AllumerBougies()
    {
        yield return new WaitForSeconds(intervalle);
        while (index < bougies.Length)
        {
            bougies[index].gameObject.SetActive(true);
            index++;
            yield return new WaitForSeconds(intervalle); // attend avant la prochaine
        }
    }
}
