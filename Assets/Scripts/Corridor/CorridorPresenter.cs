using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Corridor
{
    public class CorridorPresenter : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField]
        private Text _level;

        [SerializeField]
        private Button _upgradeLevelButton;

        [SerializeField]
        private Image _levelImage;

        private CorridorModel _corridorModel;
        private CorridorController _corridorController;
        private ICorridorViewData _corridorViewData;

        private CompositeDisposable _disposer;

        [Inject]
        public void Construct(CorridorModel corridorModel, CorridorController corridorController,
            ICorridorViewData corridorViewData)
        {
            _corridorModel = corridorModel;
            _corridorController = corridorController;
            _corridorViewData = corridorViewData;
        }

        public void Initialize()
        {
            _disposer = new CompositeDisposable();
            _corridorModel.Level.SubscribeToText(_level).AddTo(_disposer);
            _corridorModel.Level.Subscribe(SetLevelSprite).AddTo(_disposer);
            _corridorController.UpgradeLevel.BindTo(_upgradeLevelButton).AddTo(_disposer);
        }

        private void SetLevelSprite(int level)
        {
            if (level >= 1 && level <= 5)
            {
                _levelImage.sprite = _corridorViewData.Level1To5Sprite;
            }
            else if (level >= 6 && level <= 10)
            {
                _levelImage.sprite = _corridorViewData.Level6To10Sprite;
            }
        }

        public void Dispose()
        {
            if (_disposer != null)
            {
                _disposer.Dispose();
            }
        }
    }
}