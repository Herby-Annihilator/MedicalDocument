using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.ViewModels.Base
{
    public class ClosableViewModel : ViewModel
    {
        public event EventHandler<CloseWindowEventArgs> CloseWindow;
        protected virtual void OnCloseWindow(CloseWindowEventArgs args) => CloseWindow?.Invoke(this, args);
    }

    public class CloseWindowEventArgs : EventArgs
    {
        public bool DialogResult { get; set; }
        public CloseWindowEventArgs(bool dialogResult) => DialogResult = dialogResult;
    }
}
