using CodeBase.Hero;
using CodeBase.View;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    private HudViewPresenter _presenter;
    private Hero _hero;
    
    private void Awake()
    {
        _hero = new Hero(100, 80);
        HudView hudView = Load<HudView>("HudView");

        _presenter = new HudViewPresenter(hudView, _hero);
    }

    private void OnEnable() =>
        _presenter.Enable();

    private void OnDisable() =>
        _presenter.Disable();

    private T Load<T>(string path) where T : MonoBehaviour =>
        Instantiate(Resources.Load<T>(path));
}
