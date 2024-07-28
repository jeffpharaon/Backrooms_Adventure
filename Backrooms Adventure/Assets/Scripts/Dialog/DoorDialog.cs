using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorDialog : MonoBehaviour
{
    [SerializeField] private string[] lines;
    [SerializeField] private float speedText;
    [SerializeField] public Text dialog;
    [SerializeField] private int index;
    [SerializeField] private GameObject obj;

    public void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialog.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void SkipText()
    {
        if (dialog.text == lines[index]) NextLine();

        else
        {
            StopAllCoroutines();
            dialog.text = lines[index];
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
            Destroy(this.obj);
        }
    }
}
