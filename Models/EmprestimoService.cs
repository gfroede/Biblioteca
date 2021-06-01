using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models{
    public class EmprestimoService {
        public void Inserir(Emprestimo e){
            using(BibliotecaContext bc = new BibliotecaContext()){
                bc.Emprestimos.Add(e);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Emprestimo e){
            using(BibliotecaContext bc = new BibliotecaContext()){
                Emprestimo emprestimo = bc.Emprestimos.Find(e.Id);
                emprestimo.LivroId = e.LivroId;
                emprestimo.DataEmprestimo = e.DataEmprestimo;
                emprestimo.DataDevolucao = e.DataDevolucao;

                bc.SaveChanges();
            }
        }

        public ICollection<Emprestimo> ListarTodos(FiltrosEmprestimos filtro){
            using(BibliotecaContext bc = new BibliotecaContext()){
                IQueryable<Emprestimo> query;
                
                if(filtro != null){
                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro){
                        case "Usuario":
                            query = bc.Emprestimos.Where(l => l.NomeUsuario.Contains(filtro.Filtro));
                        break;
                        case "Livro":
                            List<Livro> LivrosFiltrados = bc.Livros.Where(l => l.Titulo.Contains(filtro.Filtro)).ToList();
                            List<int> LivrosIds = new List<int>();
                            for(int i = 0; i < LivrosFiltrados.Count; i++){
                                LivrosIds.Add(LivrosFiltrados[i].Id);
                            }
                            query = bc.Emprestimos.Where(l => LivrosIds.Contains(l.LivroId));
                            var debug = query.ToList();
                        break;
                        default:
                            query = bc.Emprestimos;
                        break;
                    }
                }else{
                    query = bc.Emprestimos;
                }
                List<Emprestimo> ListaQuery = query.OrderBy(l => l.DataEmprestimo).ToList();
                for(int i = 0; i < ListaQuery.Count; i++){
                    ListaQuery[i].Livro = bc.Livros.Find(ListaQuery[i].LivroId);
                }
                return ListaQuery;
            }
        }
        public Emprestimo ObterPorId(int id){
            using(BibliotecaContext bc = new BibliotecaContext()){
                return bc.Emprestimos.Find(id);
            }
        }
    }
}