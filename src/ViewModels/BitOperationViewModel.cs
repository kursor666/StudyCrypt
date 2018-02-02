using System;
using System.Diagnostics.CodeAnalysis;
using Caliburn.Micro;
using Chezar.Models;
using Chezar.Utils;

namespace Chezar.ViewModels
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public sealed class BitOperationViewModel : Screen, IScreenView
    {
        private readonly BitOperationModel _algorithmModel;

        private string _inputText;
        private string _outputText;
        private readonly EntropyModel _entropyModel;

        public BitOperationViewModel(BitOperationModel algorithmModel, EntropyModel entropyModel)
        {
            _algorithmModel = algorithmModel;
            _entropyModel = entropyModel;
            _algorithmModel.IsEncode = true;
            DisplayName = "Побитовое шифрование";
        }

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OutputText = _algorithmModel.Transform(_inputText);
            }
        }

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                Refresh();
            }
        }

        public string InputBinary => _algorithmModel.InputBinary;

        public string OutputBinary => _algorithmModel.OutputBinary;
        
        public double InputTextEntropy => Math.Round(_entropyModel.GetEntropy(_inputText), 4);

        public double OutputTextEntropy => Math.Round(_entropyModel.GetEntropy(_outputText), 4);

        public void SetDecode()
        {
            _algorithmModel.IsEncode = false;
        }

        public void SetEncode()
        {
            _algorithmModel.IsEncode = true;
        }
    }
}