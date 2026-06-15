using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Controllers;

namespace EstoqueTelecomApp.Views;

public partial class TrabalhoCampoView : ContentPage
{
    private readonly EquipamentoOfflineController _controllerOffline;

    public TrabalhoCampoView()
    {
        InitializeComponent();
        _controllerOffline = new EquipamentoOfflineController();
    }

    private async void OnSalvarOfflineClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(txtQuantidade.Text, out int quantidade))
        {
            await DisplayAlert("Erro", "Insira uma quantidade válida.", "OK");
            return;
        }

        var equipamento = new Equipamento
        {
            NomeModelo = txtModelo.Text,
            Fabricante = txtFabricante.Text,
            QuantidadeEstoque = quantidade
        };

        _controllerOffline.SalvarLocal(equipamento);

        // Mensagem focada na tranquilidade do operador
        await DisplayAlert("Segurança", "Equipamento salvo no seu aparelho de forma infalível. Você pode continuar o trabalho.", "OK");

        txtModelo.Text = string.Empty;
        txtFabricante.Text = string.Empty;
        txtQuantidade.Text = string.Empty;
    }
}