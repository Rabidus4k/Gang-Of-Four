using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class DialogueMenager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogueText;
    [SerializeField] private RectTransform DialoguePanel;

    public static DialogueMenager inst;

    
    private Coroutine _coroutine;
    private string _textToPrint;

    private void Start()
    {
        if (null != inst)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            inst = this;            
        }
    }

    public void ShowDialogue(string text)
    {
        DialogueText.SetText(string.Empty);
        _textToPrint = text;
        LeanTween.move(DialoguePanel, new Vector3(0, -50, 0), 0.2f).setOnComplete(() => SetText());
    }

    public void HideDialogue()
    {
        if (null != _coroutine)
            StopCoroutine(_coroutine);

        LeanTween.move(DialoguePanel, new Vector3(0, 300, 0), 0.2f);
    }

    private void SetText()
    {
        if (null != _coroutine)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(SetText_Coroutine());
    }

    private IEnumerator SetText_Coroutine()
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = 0; i < _textToPrint.Length; i++)
        {
            stringBuilder.Append(_textToPrint[i]);
            DialogueText.SetText(stringBuilder);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        HideDialogue();
    }
}
