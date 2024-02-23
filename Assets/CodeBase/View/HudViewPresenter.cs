using System;

namespace CodeBase.View
{
    public class HudViewPresenter
    {
        private readonly HudView _hudView;
        private readonly Hero.Hero _hero;
        private readonly HudView _hudViewText;
        private readonly BarAdapter _healthBarAdapter;
        private readonly BarAdapter _manaBarAdapter;

        public HudViewPresenter(Hero.Hero hero, HudView hudView)
        {
            _hudView = hudView ?? throw new ArgumentNullException(nameof(hudView));
            _hero = hero ?? throw new ArgumentNullException(nameof(hero));
            _healthBarAdapter = new BarAdapter(hudView.HealthBar,hudView.CharHealthBar, hero.Health);
            _manaBarAdapter = new BarAdapter(hudView.ManaBar,hudView.CharManaBar, hero.Mana);
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
            _hudView.HealButton.onClick.AddListener(HealHero);
            _hudView.TakeDamageButton.onClick.AddListener(DamageHero);
            _hudView.SpentManaButton.onClick.AddListener(SpentMana);
        }

        private void RemoveListeners()
        {
            _hudView.HealButton.onClick.RemoveListener(HealHero);
            _hudView.TakeDamageButton.onClick.RemoveListener(DamageHero);
            _hudView.SpentManaButton.onClick.RemoveListener(SpentMana);
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