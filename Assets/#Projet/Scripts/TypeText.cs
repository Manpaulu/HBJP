using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class TypeText : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textUI;

    [Header("Typewriter Settings")]
    [TextArea]
    private string fullText;
    public float charDelay = 0.1f;

    private Coroutine typingCoroutine;

    public UnityAction endTyping;


    public Button button;
    public Button button2;

    void Start()
    {
        fullText = textUI.text;
        if(button) button.gameObject.SetActive(false);
        if(button2) button2.gameObject.SetActive(false);    
        StartTyping();
    }

    public void StartTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeWord());
    }

    IEnumerator TypeWord()
    {
        textUI.text = "";

        // Version invisible (réserve la place)
        string invisibleText =
            $"<alpha=#00>{fullText}</alpha>";

        for (int i = 0; i < fullText.Length; i++)
        {
            // Texte tapé jusqu’à i
            string visible = fullText.Substring(0, i + 1);

            // Texte restant mais invisible
            string hidden = $"<color=#00000000>{fullText.Substring(i + 1)}</color>";

            // Combine
            textUI.text = visible + hidden;
            textUI.ForceMeshUpdate();

            yield return new WaitForSeconds(charDelay);
        }

        endTyping?.Invoke();
        yield return new WaitForSeconds(charDelay);
        if (button) button.gameObject.SetActive(true);
        if (button2) button2.gameObject.SetActive(true);
    }
}
