using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite? Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = [];
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite), "A suíte não pode ser nula.");
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Suite deve ser cadastrada antes de cadastrar hóspedes.");
            }

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new InvalidOperationException("Quantidade de hóspedes excede a capacidade da suíte.");
            }

            Hospedes = hospedes;
            Console.WriteLine($"Reserva de {DiasReservados} dias foi realizada com sucesso.");
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes == null)
            {
                throw new InvalidOperationException("A lista de hóspedes não está inicializada.");
            }

            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Suite deve ser cadastrada antes de calcular o valor da diária.");
            }

            decimal valor = Suite.ValorDiaria * DiasReservados;
            if (DiasReservados >= 10)
            {
                valor *= 0.9M;
            }

            return valor;
        }
    }
}
