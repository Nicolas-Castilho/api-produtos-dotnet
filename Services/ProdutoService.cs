using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Services
{
    public class ProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public Produto? GetById(int id)
        {
            return _context.Produtos.Find(id);
        }

        public Produto Create(string nome, decimal preco)
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }

        public bool Update(int id, string nome, decimal preco)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return false;

            produto.Nome = nome;
            produto.Preco = preco;

            _context.SaveChanges();

            return true;
        }
        public bool Delete(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return true;
        }
    }
}