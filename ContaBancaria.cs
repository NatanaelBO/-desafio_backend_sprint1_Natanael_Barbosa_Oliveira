using System;

public abstract class ContaBancaria
{
    public int NumeroConta { get; private set; }
    public string Titular { get; private set; }
    public decimal Saldo { get; protected set; }

    public ContaBancaria(int numeroConta, string titular)
    {
        NumeroConta = numeroConta;
        Titular = titular;
        Saldo = 0;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de deposito invalido.");
        }
        Saldo += valor;
    }

    public abstract void Sacar(decimal valor);

    public virtual string Tipo()
    {
        return "Conta";
    }
}
