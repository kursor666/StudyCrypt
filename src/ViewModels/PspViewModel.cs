using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Caliburn.Micro;
using Chezar.Models;
using Chezar.Utils;

namespace Chezar.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ConvertToAutoPropertyWithPrivateSetter")]
    public sealed class PspViewModel : Screen, IScreenView
    {
        private readonly PspModel _pspModel;
        private uint _inputNumber;
        private uint _outputNumber;

        public PspViewModel(PspModel pspModel)
        {
            _pspModel = pspModel;
            DisplayName = "Генерация ПСП";
        }

        public List<PspTempItem> PspTempItems => _pspModel.PspTempItems;

        public uint OutputNumber => _outputNumber;

        public uint InputNumber
        {
            get => _inputNumber;
            set
            {
                _inputNumber = value;
                _outputNumber = _pspModel.GetPsp(_inputNumber);
                NotifyOfPropertyChange(() => InputNumber);
                NotifyOfPropertyChange(() => OutputNumber);
                NotifyOfPropertyChange(() => PspTempItems);
            }
        }
    }
}