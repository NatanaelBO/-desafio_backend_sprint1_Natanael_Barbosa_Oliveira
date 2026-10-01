using System;

public class ContaEmpresarial : ContaBancaria
{
    private const decimal LimiteEmprestimo = 1000m;

    public ContaEmpresarial(int numeroConta, string titular) : base(numeroConta, titular)
    {
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de saque invalido.");
        }
        if (valor > Saldo + LimiteEmprestimo)
        {
            throw new InvalidOperationException("Saldo e limite de emprestimo insuficientes.");
        }
        Saldo -= valor;
    }

    public override string Tipo()
    {
        return "Conta Empresarial";
    }
}
