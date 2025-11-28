using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public AudioSource audioSource; 
    
    public void JouerAudio()
    {
        if (audioSource != null)
        {
            audioSource.volume = 0.3f; 
            audioSource.Play();
        }
    }
}
