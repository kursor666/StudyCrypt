using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Caliburn.Micro;
using Chezar.Models;
using Chezar.Utils;

namespace Chezar.ViewModels
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
    public sealed class ChezarViewModel : Screen, IScreenView
    {
        private readonly ChezarAlgorithmModel _algorithmModel;

        private string _inputText;
        private string _outputText;

        public ChezarViewModel(ChezarAlgorithmModel algorithmModel)
        {
            _algorithmModel = algorithmModel;
            MarginShift = 3;
            DisplayName = "Алгоритм Цезаря";
        }

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = "";
                value.ToLower().Where(symbol => ((int) symbol >= 1072 && (int) symbol <= 1104) || symbol == ' ')
                    .Select(c => _inputText += c).ToList();
                OutputText = _algorithmModel.Transform(_inputText);
                NotifyOfPropertyChange(() => InputText);
            }
        }

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                NotifyOfPropertyChange(() => OutputText);
            }
        }

        public int MarginShift
        {
            get => _algorithmModel.MarginShift;
            set
            {
                _algorithmModel.MarginShift = value;
                NotifyOfPropertyChange(() => MarginShift);
            }
        }

        public void SetDecode()
        {
            _algorithmModel.IsDecode = true;
        }

        public void SetEncode()
        {
            _algorithmModel.IsDecode = false;
        }
    }
}