using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Caliburn.Micro;
using Chezar.Models;
using Chezar.Utils;

namespace Chezar.ViewModels
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class BelazoPortViewModel : Screen, IScreenView
    {
        private readonly BelazoPortAlgorithmModel _algorithmModel;
        private readonly EntropyModel _entropyModel;
        private string _inputText;
        private string _outputText;
        private string _key;

        public BelazoPortViewModel(BelazoPortAlgorithmModel algorithmModel, EntropyModel entropyModel)
        {
            _algorithmModel = algorithmModel;
            _entropyModel = entropyModel;
            DisplayName = "Алгоритм Белазо-Порта";
        }
        
        public string Key
        {
            get => _algorithmModel.Key;
            set
            {
                _key = "";
                value.ToLower().Where(symbol => ((int) symbol >= 1072 && (int) symbol <= 1104) || symbol == ' ')
                    .Select(c => _key += c).ToList();
                _algorithmModel.Key = _key;
                NotifyOfPropertyChange(() => Key);
            }
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
                NotifyOfPropertyChange(() => InputTextEntropy);
            }
        }

        public double InputTextEntropy => _entropyModel.GetEntropy(_inputText);

        public double OutputTextEntropy => _entropyModel.GetEntropy(_outputText);

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                NotifyOfPropertyChange(() => OutputText);
                NotifyOfPropertyChange(() => OutputTextEntropy);
            }
        }
    }
}