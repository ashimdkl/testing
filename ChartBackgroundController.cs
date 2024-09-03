using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChartBackgroundController : MonoBehaviour
{
    public TMP_Text yMaxLabel;

    public void SetYLabel(float y)
    {
        yMaxLabel.text = y.ToString("n1");
    }

}
