using System;
using TMPro;
using UnityEngine;

public class TestKeypad : MonoBehaviour
{
    public int keypadCode;
    
    [SerializeField] private TMP_Text _inputText;
    [SerializeField] private string _keypadInput;
    
    // Update is called once per frame
    void Update()
    {
        _inputText.text = _keypadInput;
    }

    public void AddInput(int val)
    {
        _keypadInput += val.ToString();
    }
    
    public void CheckInput()
    {
        if (keypadCode.ToString() == _keypadInput)
        {
            Debug.Log("YOOOOO");
        }
    }

    public void ResetInput()
    {
        _keypadInput = "";
    }
}
