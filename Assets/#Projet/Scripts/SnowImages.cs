using UnityEngine;

public class SnowImages : MonoBehaviour
{
    [System.Serializable]
    public class Cupcake
    {
        public Transform cupcake;       // l'image cupcake dans la scène
        [HideInInspector] public float speed;
    }

    public Cupcake[] cupcakes;          // tes 4 cupcakes
    public Vector2 speedRange = new Vector2(10f, 30f); // vitesse aléatoire

    void Start()
    {
        // Donne une vitesse aléatoire à chaque cupcake
        foreach (var cup in cupcakes)
        {
            cup.speed = Random.Range(speedRange.x, speedRange.y);
        }
    }

    void Update()
    {
        foreach (var cup in cupcakes)
        {
            cup.cupcake.Translate(0, -cup.speed * Time.deltaTime, 0);

            // Quand le cupcake sort en bas, on le replace en haut
            if (cup.cupcake.position.y < -500f) // adapte selon ton Canvas
            {
                Vector3 pos = cup.cupcake.position;
                pos.y = 500f;  // remonter en haut
                cup.cupcake.position = pos;
            }
        }
    }
}
