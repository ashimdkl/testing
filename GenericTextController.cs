using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenericTextController : MonoBehaviour
{
    public TMP_Text text;
    public string preText,postText;

    private void Start()
    {
        text.text = preText + postText;
    }
    public void SetTextWithFloat(float value)
    {
        text.text = preText + value + postText;
    }
}
