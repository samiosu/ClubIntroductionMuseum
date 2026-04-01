using System.Reflection;
using System.Runtime.Versioning;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using TMPro;

public class TextController : MonoBehaviour
{
    private string[] textArray;
    private TMP_Text textBox;
    [SerializeField] private TextAsset textFile;
    private float textSpeed = 0.1f;
    
    void Start()
    {
        textArray = textFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        textBox = GetComponent<TMP_Text>();
        StartCoroutine(TextCoroutine(0));
    }

    IEnumerator TextCoroutine(int index)
    {
        textBox.text = textArray[index];
        for(int i=0;i < textArray[index].Length; i++)
        {
            textBox.maxVisibleCharacters = i;
            yield return new WaitForSeconds(textSpeed);
        }
        textBox.maxVisibleCharacters = textArray[index].Length;
        if (index < textArray.Length - 1)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(TextCoroutine(index + 1));
        }
        else
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}