using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace PFViewer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        CreateWorkspaceInteraction = new Interaction<NewWorkspaceViewModel, WorkspaceViewModel>();
        CreateWorkspace = ReactiveCommand.CreateFromTask(async () => await CreateWorkspaceInteraction.Handle(new NewWorkspaceViewModel()));
    }

    public Interaction<NewWorkspaceViewModel, WorkspaceViewModel> CreateWorkspaceInteraction { get; }

    public ICommand CreateWorkspace { get; }
}
