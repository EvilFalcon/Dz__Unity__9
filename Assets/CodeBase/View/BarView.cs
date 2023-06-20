using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BarView : MonoBehaviour
{
    private Slider _slider;
    private float _targetValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, Time.deltaTime);
    }

    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);

    public void SetValue(float value) =>
        _targetValue = value;
}