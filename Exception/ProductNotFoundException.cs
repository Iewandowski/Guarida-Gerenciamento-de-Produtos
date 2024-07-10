namespace gerenciamento_de_produto.Exception
{
    public class ProductNotFoundException : System.Exception
    {
        public ProductNotFoundException() : base(string.Format("Produto(s) não encontrado(s)")) { }
    }
}
