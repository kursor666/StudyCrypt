using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Caliburn.Micro;
using Chezar.Utils;

namespace Chezar.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ShellViewModel : Conductor<IScreenView>.Collection.OneActive
    {
        public ShellViewModel(IEnumerable<IScreenView> tabs)
        {
            Items.AddRange(tabs);
        }
        
        
    }
}