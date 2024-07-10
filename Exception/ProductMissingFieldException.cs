namespace gerenciamento_de_produto.Exception
{
    public class ProductMissingFieldException : System.Exception
    {
        public ProductMissingFieldException(String message) : base(string.Format(message)) { }
    }
}
