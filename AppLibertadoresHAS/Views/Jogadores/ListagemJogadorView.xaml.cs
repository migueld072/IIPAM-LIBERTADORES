using AppLibertadoresHAS.ViewModels;

namespace AppLibertadoresHAS.Views.Jogadores;

public partial class ListagemJogadorView : ContentPage
{
    ListagemJogadorViewModel viewModel;

    public ListagemJogadorView()
    {
        InitializeComponent();

        viewModel = new ListagemJogadorViewModel();
        BindingContext = viewModel;
        Title = "Jogadores";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.ObterJogadores();
    }
}
