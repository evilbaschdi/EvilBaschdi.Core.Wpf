
using Ookii.Dialogs.Wpf;

namespace EvilBaschdi.CoreExtended.Browsers
{
    /// <inheritdoc />
    /// <summary>
    ///     Stellt einen Auswahldialog für Ordner und Systemelemente ab Windows Vista bereit.
    /// </summary>

    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once UnusedType.Global
    public class ExplorerFolderBrowser : IFolderBrowser
    {
        private readonly VistaFolderBrowserDialog _vistaFolderBrowserDialog = new();
        


        /// <inheritdoc />
        public string SelectedPath
        {
            get => _vistaFolderBrowserDialog.SelectedPath;
            set
            {
                if (value != null)
                {
                    _vistaFolderBrowserDialog.SelectedPath = value;
                }
            }
        }

        /// <inheritdoc />
        public void ShowDialog()
        {
            _vistaFolderBrowserDialog.ShowDialog();
        }
    }
}