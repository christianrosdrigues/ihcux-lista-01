using System; 

//Heurística 1 - Visibilidade do Status:
//Mostra em qual passo o usuário está.

//Heurística 3 - Controle e Liberdade:
//Permite digitar "voltar" e "cancelar".

//Heurística 9 - Ajuda e Erros:
//Mensagens claras para entradas inválidas.

class Program
{
    static void Main()
    {
        int passo = 1;
        int produto = 0;
        int quantidade = 0;

        while (true)
        {
            if (passo == 1)
            {
                Console.WriteLine("\n[Passo 1 de 3] Escolha o produto");
                Console.WriteLine("1 - Pão");
                Console.WriteLine("2 - Suco");
                Console.WriteLine("3 - Salgado");
                Console.Write("Digite o código (ou 'cancelar'): ");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    break;
                }

                if (!int.TryParse(entrada, out produto))
                {
                    Console.WriteLine("Entrada inválida. Digite apenas números.");
                    continue;
                }

                if (produto < 1 || produto > 3)
                {
                    Console.WriteLine($"Código {produto} não encontrado. Use valores de 1 a 3.");
                    continue;
                }

                passo = 2;
            }

            else if (passo == 2)
            {
                Console.WriteLine("\n[Passo 2 de 3] Quantidade");
                Console.Write("Digite a quantidade (ou 'voltar'): ");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "voltar")
                {
                    passo = 1;
                    continue;
                }

                if (!int.TryParse(entrada, out quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Quantidade inválida. Digite um número maior que zero.");
                    continue;
                }

                passo = 3;
            }

            else if (passo == 3)
            {
                Console.WriteLine("\n[Passo 3 de 3] Confirmação");
                Console.WriteLine($"Produto: {produto}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.Write("Confirmar pedido? (digite 'sim' ou 'nao'): ");

                string confirmacao = Console.ReadLine().ToLower();

                if (confirmacao == "nao")
                {
                    passo = 2;
                    continue;
                }
                else if (confirmacao == "sim")
                {
                    Console.WriteLine("Pedido realizado com sucesso!");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite apenas 'sim' ou 'nao'.");
                    continue;
                }
            }
        }
    }
}