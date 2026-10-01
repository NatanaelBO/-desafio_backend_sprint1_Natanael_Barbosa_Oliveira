using System;
using System.Collections.Generic;

public class Program
{
    static List<ContaBancaria> contas = new List<ContaBancaria>();

    static void Main()
    {
        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine();
            Console.WriteLine("===== BANCO =====");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Ver saldo");
            Console.WriteLine("5 - Render poupanca");
            Console.WriteLine("6 - Listar contas");
            Console.WriteLine("0 - Sair");
            Console.Write("Opcao: ");

            try
            {
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CriarConta();
                        break;
                    case 2:
                        Depositar();
                        break;
                    case 3:
                        Sacar();
                        break;
                    case 4:
                        VerSaldo();
                        break;
                    case 5:
                        RenderPoupanca();
                        break;
                    case 6:
                        ListarContas();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;
                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada invalida. Digite apenas numeros.");
                opcao = -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }

    static ContaBancaria BuscarConta()
    {
        Console.Write("Numero da conta: ");
        int numero = int.Parse(Console.ReadLine());

        foreach (ContaBancaria conta in contas)
        {
            if (conta.NumeroConta == numero)
            {
                return conta;
            }
        }

        throw new Exception("Conta nao encontrada.");
    }

    static void CriarConta()
    {
        Console.Write("Numero da conta: ");
        int numero = int.Parse(Console.ReadLine());

        foreach (ContaBancaria c in contas)
        {
            if (c.NumeroConta == numero)
            {
                throw new Exception("Ja existe uma conta com esse numero.");
            }
        }

        Console.Write("Titular: ");
        string titular = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new Exception("Titular invalido.");
        }

        Console.WriteLine("1 - Corrente | 2 - Poupanca | 3 - Empresarial");
        Console.Write("Tipo: ");
        int tipo = int.Parse(Console.ReadLine());

        if (tipo == 1)
        {
            contas.Add(new ContaCorrente(numero, titular));
        }
        else if (tipo == 2)
        {
            contas.Add(new ContaPoupanca(numero, titular));
        }
        else if (tipo == 3)
        {
            contas.Add(new ContaEmpresarial(numero, titular));
        }
        else
        {
            throw new Exception("Tipo de conta invalido.");
        }

        Console.WriteLine("Conta criada com sucesso.");
    }

    static void Depositar()
    {
        ContaBancaria conta = BuscarConta();
        Console.Write("Valor: ");
        decimal valor = decimal.Parse(Console.ReadLine());
        conta.Depositar(valor);
        Console.WriteLine("Deposito realizado. Saldo: R$ " + conta.Saldo.ToString("F2"));
    }

    static void Sacar()
    {
        ContaBancaria conta = BuscarConta();
        Console.Write("Valor: ");
        decimal valor = decimal.Parse(Console.ReadLine());
        conta.Sacar(valor);
        Console.WriteLine("Saque realizado. Saldo: R$ " + conta.Saldo.ToString("F2"));
    }

    static void VerSaldo()
    {
        ContaBancaria conta = BuscarConta();
        Console.WriteLine("Saldo: R$ " + conta.Saldo.ToString("F2"));
    }

    static void RenderPoupanca()
    {
        ContaBancaria conta = BuscarConta();

        if (conta is ContaPoupanca)
        {
            ContaPoupanca poupanca = (ContaPoupanca)conta;
            poupanca.Render();
            Console.WriteLine("Rendimento aplicado. Saldo: R$ " + poupanca.Saldo.ToString("F2"));
        }
        else
        {
            Console.WriteLine("Essa conta nao e poupanca.");
        }
    }

    static void ListarContas()
    {
        if (contas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }

        foreach (ContaBancaria conta in contas)
        {
            Console.WriteLine(conta.NumeroConta + " | " + conta.Titular + " | " + conta.Tipo() + " | R$ " + conta.Saldo.ToString("F2"));
        }
    }
}
