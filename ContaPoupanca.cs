using System;

public class ContaPoupanca : ContaBancaria
{
    private const decimal Rendimento = 0.005m;

    public ContaPoupanca(int numeroConta, string titular) : base(numeroConta, titular)
    {
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de saque invalido.");
        }
        if (valor > Saldo)
        {
            throw new InvalidOperationException("Saldo insuficiente.");
        }
        Saldo -= valor;
    }

    public void Render()
    {
        Saldo += Saldo * Rendimento;
    }

    public override string Tipo()
    {
        return "Conta Poupanca";
    }
}
