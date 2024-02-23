using CodeBase.View;
using UnityEngine;
using UnityEngine.UI;

public class HudView : MonoBehaviour
{
    [field: SerializeField] public BarView HealthBar { get; private set; }
    [field: SerializeField] public BarView ManaBar { get; private set; }
    [field: SerializeField] public CharBarView CharHealthBar { get; private set; }
    [field: SerializeField] public CharBarView CharManaBar { get; private set; }
    [field: SerializeField] public Button HealButton { get; private set; }
    [field: SerializeField] public Button TakeDamageButton { get; private set; }
    [field: SerializeField] public Button SpentManaButton { get; private set; }
}