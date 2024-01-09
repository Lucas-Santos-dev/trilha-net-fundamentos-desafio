using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        static bool IsValidPlaca(string placa)
        {
            string pattern = @"^[A-Z]{3}[0-9][A-Za-z0-9][0-9]{2}$";
            return Regex.IsMatch(placa, pattern);
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            
            if (IsValidPlaca(placa))
            {
                if(veiculos.Any(x => x.ToUpper() == placa))
                {
                    Console.WriteLine("Já existe um veículo estacionado com essa placa.");
                }
                else
                {
                    veiculos.Add(placa);
                    Console.WriteLine("Veículo adicionado!");
                }
            } 
            else 
            {
                Console.WriteLine("Placa inválida!");
            }
        }
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo que deseja remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Quantas horas o veículo ficou estacionado:");
                int.TryParse(Console.ReadLine(), out int horas);
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido, e o valor a ser pago é de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado, por favor tente digitar a placa novamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
