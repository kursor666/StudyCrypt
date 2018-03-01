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
        private int _inputNumber;
        private int _outputNumber;

        public PspViewModel(PspModel pspModel)
        {
            _pspModel = pspModel;
            DisplayName = "Нод";
        }

        public List<PspTempItem> PspTempItems => _pspModel.PspTempItems;

        public int OutputNumber => _outputNumber;

        public int InputNumber
        {
            get => _inputNumber;
            set
            {
                _inputNumber = value;
                _outputNumber = _pspModel.GetPsp(_inputNumber);
                Refresh();
            }
        }
    }
}