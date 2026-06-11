using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerHealth _playerHealth;
    private CoinsManeger _coinsManeger;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle();
        Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle();
        Container.Bind<CoinsManeger>().FromInstance(new CoinsManeger()).AsSingle();
    }
}
