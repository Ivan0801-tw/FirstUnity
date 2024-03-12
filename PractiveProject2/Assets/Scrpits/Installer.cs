using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<A>().AsSingle().NonLazy();
        Container.Bind(typeof(ITickable)).WithId("B").To<B>().AsSingle();
        Container.Bind(typeof(ITickable)).To<C>().AsSingle();
    }
}

public class A
{
    [Inject(Id = "B")]
    private ITickable _tickableB;

    [Inject]
    private ITickable _tickableC;

    public A()
    {
        Debug.Log("A");
    }
}

public class B : ITickable
{
    public void Tick()
    {
    }
}

public class C : ITickable
{
    public void Tick()
    {
    }
}