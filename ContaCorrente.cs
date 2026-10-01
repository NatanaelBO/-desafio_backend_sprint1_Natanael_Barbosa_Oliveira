using System;

public class ContaCorrente : ContaBancaria
{
    private const decimal Taxa = 2.50m;

    public ContaCorrente(int numeroConta, string titular) : base(numeroConta, titular)
    {
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de saque invalido.");
        }
        if (valor + Taxa > Saldo)
        {
            throw new InvalidOperationException("Saldo insuficiente (taxa de R$ 2,50 por saque).");
        }
        Saldo -= valor + Taxa;
    }

    public override string Tipo()
    {
        return "Conta Corrente";
    }
}
