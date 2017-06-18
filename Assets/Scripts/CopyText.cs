using UnityEngine;
using System.Collections;
using TMPro;

public class CopyText : MonoBehaviour
{

    public UnityEngine.UI.Text _text;
    public TextMeshProUGUI _myText;

    // Use this for initialization
    void Start()
    {
        _myText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _myText.text = MTGFormatter.FormatManaCost(_text.text);

    }
}
