using CodeBase.Hero;

namespace CodeBase.View
{
    public class BarAdapter
    {
        private readonly BarView _barView;
        private readonly Point _point;

        public BarAdapter(BarView barView, Point point)
        {
            _barView = barView;
            _point = point;
        }

        public void Enable()
        {
            OnPointChanged();
            _barView.Show();
            _point.Changed += OnPointChanged;
        }

        public void Disable()
        {
            _barView.Hide();
            _point.Changed -= OnPointChanged;
        }

        private void OnPointChanged()
        {
            _barView.SetValue(_point.Value / _point.Max);
            _barView.OnUpdate();
        }
    }
}