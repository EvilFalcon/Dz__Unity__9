using System;
using CodeBase.Hero;

namespace CodeBase.View
{
    public class BarAdapter
    {
        private readonly BarView _barView;
        private readonly CharBarView _viewCharBar;
        private readonly Point _point;

        public BarAdapter(BarView barView, CharBarView hudViewCharBar, Point point)
        {
            _barView = barView ?? throw new ArgumentNullException(nameof(barView));
            _viewCharBar = hudViewCharBar ?? throw new ArgumentNullException(nameof(hudViewCharBar));
            _point = point ?? throw new ArgumentNullException(nameof(point));
        }

        public void Enable()
        {
            OnPointChanged();
            _viewCharBar.Show();
            _barView.Show();
            _point.Changed += OnPointChanged;
        }

        public void Disable()
        {
            _viewCharBar.Hide();
            _barView.Hide();
            _point.Changed -= OnPointChanged;
        }

        private void OnPointChanged()
        {
            _barView.SetValue(_point.Value / _point.Max);
            _viewCharBar.SetValue(_point.Value, _point.Max);
            _barView.OnUpdate();
        }
    }
}