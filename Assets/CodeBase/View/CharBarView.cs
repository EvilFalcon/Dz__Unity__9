using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.View
{
    [RequireComponent(typeof(Text))]
    public class CharBarView: MonoBehaviour
    {
        private Text _textMeshPro;

        private void Awake() =>
            _textMeshPro = GetComponent<Text>();

        public void Show() =>
            gameObject.SetActive(true);
        

        public void Hide() =>
            gameObject.SetActive(false);

        public void SetValue(float currentValue, float maxValue) =>
            _textMeshPro.text = $" {currentValue} / {maxValue}";
        
    }
}