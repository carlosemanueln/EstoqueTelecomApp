using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Controllers;
using EstoqueTelecomApp.Interfaces;

namespace EstoqueTelecomApp.Views;

public partial class EquipamentoView : ContentPage
{
    private readonly IController<Equipamento> _equipamentoController;

    public EquipamentoView()
    {
        InitializeComponent();
        _equipamentoController = new EquipamentoController();
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        try
        {
            // Validação de segurança para garantir que as caixas numéricas têm mesmo números
            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || !int.TryParse(txtIdCategoria.Text, out int idCategoria))
            {
                await DisplayAlert("Erro", "A quantidade e o ID da Categoria devem ser números inteiros válidos.", "OK");
                return;
            }

            var equipamento = new Equipamento
            {
                NomeModelo = txtModelo.Text,
                Fabricante = txtFabricante.Text,
                QuantidadeEstoque = quantidade,
                IdCategoria = idCategoria
            };

            _equipamentoController.Salvar(equipamento);

            await DisplayAlert("Sucesso", "Equipamento salvo no MySQL com sucesso!", "OK");

            // Limpa as caixas de texto após salvar
            txtModelo.Text = string.Empty;
            txtFabricante.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Atenção", ex.Message, "OK");
        }
    }
}