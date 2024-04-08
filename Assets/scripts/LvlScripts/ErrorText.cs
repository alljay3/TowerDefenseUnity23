using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorText : MonoBehaviour
{
    [SerializeField] private float TimeToOff;
    private TextMeshProUGUI _textComponent;
    private bool _isEnable = false;
    // Update is called once per frame
    private void Start()
    {
        _textComponent = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void SandErrorMassage(string errorText)
    {
        if (!_isEnable)
        {
            _textComponent.SetText(errorText);
            StartCoroutine(Off());
        }
    }

    IEnumerator Off()
    {
        _isEnable = true;
        yield return new WaitForSeconds(TimeToOff);
        _textComponent.SetText("");
        _isEnable = false;
    }
}
