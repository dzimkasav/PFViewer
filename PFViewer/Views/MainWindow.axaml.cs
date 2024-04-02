using Avalonia.ReactiveUI;
using PFViewer.ViewModels;
using PFViewer.Views.Workspace;
using ReactiveUI;
using System.Threading.Tasks;

namespace PFViewer.Views;

public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(action => action(ViewModel!.CreateWorkspaceInteraction.RegisterHandler(ShowCreateWorkspaceDialog)));
    }

    private async Task ShowCreateWorkspaceDialog(InteractionContext<NewWorkspaceViewModel, WorkspaceViewModel> interaction)
    {
        var dialog = new NewWorkspaceWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<WorkspaceViewModel>(this);
        interaction.SetOutput(result);
    }
}
