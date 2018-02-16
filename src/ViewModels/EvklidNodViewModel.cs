using System.Diagnostics.CodeAnalysis;
using Caliburn.Micro;
using Chezar.Models;
using Chezar.Utils;

namespace Chezar.ViewModels
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class EvklidNodViewModel : Screen, IScreenView
    {
        private readonly EvklidNodModel _model;
        private int _firstNumber;
        private int _secondNumber;


        public EvklidNodViewModel(EvklidNodModel model)
        {
            _model = model;
            DisplayName = "Нод";
        }

        public int FirstNumber
        {
            get => _firstNumber;
            set
            {
                _firstNumber = value;
                NotifyOfPropertyChange(() => FirstNumber);
                NotifyOfPropertyChange(() => Result);
            }
        }

        public int SecondNumber
        {
            get => _secondNumber;
            set
            {
                _secondNumber = value;
                NotifyOfPropertyChange(() => SecondNumber);
                NotifyOfPropertyChange(() => Result);
            }
        }

        public int Result => _model.GetNod(_firstNumber, _secondNumber);
    }
}