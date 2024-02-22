using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BarView : MonoBehaviour
{
    private const float Epsilon = 0.1f;

    private Slider _slider;
    private Coroutine _coroutine;
    private float _targetValue;
    private WaitForSeconds _coroutineDelay = new WaitForSeconds(0.1f);

    private void Awake() =>
        _slider = GetComponent<Slider>();

    public void Show() =>
        gameObject.SetActive(true);

    public void OnUpdate()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Coroutine());
    }

    public void Hide() =>
        gameObject.SetActive(false);

    public void SetValue(float value) =>
        _targetValue = value;

    private IEnumerator Coroutine()
    {
        while (Math.Abs(_slider.value - _targetValue) > Epsilon)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, Time.deltaTime);
            
            yield return _coroutineDelay;
        }
    }
}