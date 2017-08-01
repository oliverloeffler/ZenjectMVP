using System;
using UniRx;

namespace CustomRx
{
    public static class ReactiveCommandExtensions
    {
        public static IDisposable BindTo<T>(this ReactiveCommand<T> command, UnityEngine.UI.Button button, T arg)
        {
            var d1 = command.CanExecute.SubscribeToInteractable(button);
            var d2 = button.OnClickAsObservable().SubscribeWithState(command, (_, c) => c.Execute(arg));
            return StableCompositeDisposable.Create(d1, d2);
        }
    }
}