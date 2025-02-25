using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public int keypadCode;
    
    [SerializeField] private TMP_Text _inputText;
    [SerializeField] private string _keypadInput;
    [SerializeField] private GameObject _door;
    public UnityEvent OnValidCode;
    
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
            OnValidCode?.Invoke();
        }
    }

    public void ResetInput()
    {
        _keypadInput = "";
    }
}
