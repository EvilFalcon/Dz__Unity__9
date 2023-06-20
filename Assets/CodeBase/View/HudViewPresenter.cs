namespace CodeBase.View
{
    public class HudViewPresenter
    {
        private readonly HudView _view;
        private readonly Hero.Hero _hero;
        private readonly BarAdapter _healthBarAdapter;
        private readonly BarAdapter _manaBarAdapter;

        public HudViewPresenter(HudView view, Hero.Hero hero)
        {
            _view = view;
            _hero = hero;
            _healthBarAdapter = new BarAdapter(view.HealthBar, hero.Health);
            _manaBarAdapter = new BarAdapter(view.ManaBar, hero.Mana);
        }

        public void Enable()
        {
            _healthBarAdapter.Enable();
            _manaBarAdapter.Enable();
            AddListeners();
        }

        public void Disable()
        {
            _healthBarAdapter.Disable();
            _manaBarAdapter.Disable();
            RemoveListeners();
        }

        private void AddListeners()
        {
            _view.HealButton.onClick.AddListener(HealHero);
            _view.TakeDamageButton.onClick.AddListener(DamageHero);
            _view.SpentManaButton.onClick.AddListener(SpentMana);
        }

        private void RemoveListeners()
        {
            _view.HealButton.onClick.RemoveListener(HealHero);
            _view.TakeDamageButton.onClick.RemoveListener(DamageHero);
            _view.SpentManaButton.onClick.RemoveListener(SpentMana);
        }

        private void SpentMana()
        {
            _hero.Mana.TakeDamage(5);
        }

        private void DamageHero()
        {
            _hero.Health.TakeDamage(20);
        }

        private void HealHero()
        {
            _hero.Health.Heal(10);
        }
    }
}