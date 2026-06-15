using EstoqueTelecomApp.Models;
using EstoqueTelecomApp.Controllers;
using EstoqueTelecomApp.Interfaces;

namespace EstoqueTelecomApp.Views;

public partial class CategoriaView : ContentPage
{
    // A View só conhece a Interface do Controller 
    private readonly IController<Categoria> _categoriaController;

    public CategoriaView()
    {
        InitializeComponent();
        _categoriaController = new CategoriaController();
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        try
        {
            var categoria = new Categoria
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text
            };

            // Chama o Controller para processar o pedido
            _categoriaController.Salvar(categoria);

            await DisplayAlert("Sucesso", "Categoria cadastrada no MySQL!", "OK");

            // Limpa a tela
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
        }
        catch (Exception ex)
        {
            // Mostra o erro que veio lá do Service (Ex: nome vazio)
            await DisplayAlert("Erro de Validação", ex.Message, "OK");
        }
    }
}