using System;
using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public int keypadCode;
    
    [SerializeField] private TMP_Text _inputText;
    [SerializeField] private string _keypadInput;
    [SerializeField] private Animator _doorAnimator;
    
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
            LaunchAnimation();
        }
    }

    public void ResetInput()
    {
        _keypadInput = "";
    }

    public void LaunchAnimation()
    {
        _doorAnimator.SetTrigger("Open");
    }
}
