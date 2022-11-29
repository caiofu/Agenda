namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contato> ListaContatos = new List<Contato>();
            ListaContatos.Add(new Contato(Console.ReadLine(), Console.ReadLine()));

            foreach (var Contato in ListaContatos)
            {
                Console.WriteLine("Nome: {0} Telefone: {1}", Contato.Nome, Contato.Telefone);

            }
        }
    }
}