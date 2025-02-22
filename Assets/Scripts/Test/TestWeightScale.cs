using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestWeightScale : MonoBehaviour
{
    [SerializeField] private TMP_Text _weightDisplayText;
    [SerializeField] private float _targetWeight;
    [SerializeField] private float _maxVelocity;
    
    private List<GameObject> _objectsOnScale, _stillObjects;
    private Rigidbody _checkRB;
    private float _currentWeight, previousWeight;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _objectsOnScale = new List<GameObject>();
        _stillObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Find another way to do this, because I need eye-bleach
        foreach (GameObject obj in _objectsOnScale)
        {
            _checkRB = obj.GetComponent<Rigidbody>();
            if (_checkRB.isKinematic == false)
            {
                if (_checkRB.linearVelocity.magnitude <= _maxVelocity)
                {
                    if (_stillObjects.Contains(obj) == false)
                    { 
                        Debug.Log("Added Object");
                        _stillObjects.Add(obj);
                    }
                } else {
                    _stillObjects.Remove(obj);
                }
            };
        }
        CheckWeight();
        _weightDisplayText.text = _currentWeight.ToString();
    }

    private void CheckWeight()
    {
        _currentWeight = 0;
        
        foreach (GameObject obj in _stillObjects)
        {
            _checkRB = obj.GetComponent<Rigidbody>();
            _currentWeight += _checkRB.mass;
        }
        
        if (_currentWeight == _targetWeight)
            Debug.Log("Weight is the same as the target");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() == null)
            return;
        
        _objectsOnScale.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_stillObjects.Contains(other.gameObject))
            _stillObjects.Remove(other.gameObject);
        
        _objectsOnScale.Remove(other.gameObject);
    }
    
}
