using System.Reflection;
using System.Runtime.Versioning;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using TMPro;

public class TextController : MonoBehaviour
{
    private TMP_Text textBox;
    [SerializeField] private List<TextAsset> textFile = new List<TextAsset>();
    private float textSpeed = 0.01f;
    private float waitTime = 0.1f;
    
    void Start()
    {
        textBox = GetComponent<TMP_Text>();
        StartCoroutine(TextCoroutine(0));
    }

    IEnumerator TextCoroutine(int index)
    {
        string[] textArray = textFile[index].text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        for(int j=0; j < textArray.Length; j++)
        {
            textBox.text = textArray[j];
            for(int i=0;i < textArray[j].Length; i++)
            {
                textBox.maxVisibleCharacters = i;
                yield return new WaitForSeconds(textSpeed);
            }
            textBox.maxVisibleCharacters = textArray[j].Length;
            yield return new WaitForSeconds(waitTime);
        }
        yield return new WaitForSeconds(waitTime);
        if(textFile.Count > index + 1){
            StartCoroutine(TextCoroutine(index + 1));
        }
        else
        {
            textBox.text = "";
        }
    }
}