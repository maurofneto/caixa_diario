using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Domain.Enums;
using CashFlowTracker.Domain.Repositories;
using CashFlowTracker.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowTracker.Domain.Services.Implementations
{
    public class ConsolidacaoService : IConsolidacaoService
    {
        private readonly ILancamentosRepository _lancamentosRepository;

        public ConsolidacaoService(ILancamentosRepository lancamentosRepository)
        {
            _lancamentosRepository = lancamentosRepository;
        }

        public async Task<IEnumerable<SaldoConsolidado>> ConsolidarLancamentosAsync(DateTime dataInicio, DateTime dataFim)
        {
            var lancamentos = await _lancamentosRepository.GetByDateRangeAsync(dataInicio, dataFim);

            var consolidadosDiarios = new Dictionary<DateTime, SaldoConsolidado>();
            var consolidadosMensais = new Dictionary<(int, int), SaldoConsolidado>();
            var consolidadosAnuais = new Dictionary<int, SaldoConsolidado>();

            foreach (var lancamento in lancamentos.OrderBy(l => l.Data))
            {
                var dataLancamento = lancamento.Data.Date;

                if (!consolidadosDiarios.ContainsKey(dataLancamento))
                {
                    consolidadosDiarios[dataLancamento] = new SaldoConsolidado
                    {
                        Data = dataLancamento,
                        LancamentosRealizados = new List<Lancamento>()
                    };
                }

                consolidadosDiarios[dataLancamento].LancamentosRealizados.Add(lancamento);

                var chaveMensal = (dataLancamento.Month, dataLancamento.Year);
                if (!consolidadosMensais.ContainsKey(chaveMensal))
                {
                    consolidadosMensais[chaveMensal] = new SaldoConsolidado
                    {
                        Mes = dataLancamento.Month,
                        Ano = dataLancamento.Year,
                        LancamentosRealizados = new List<Lancamento>()
                    };
                }

                consolidadosMensais[chaveMensal].LancamentosRealizados.Add(lancamento);

                var chaveAnual = dataLancamento.Year;
                if (!consolidadosAnuais.ContainsKey(chaveAnual))
                {
                    consolidadosAnuais[chaveAnual] = new SaldoConsolidado
                    {
                        Ano = dataLancamento.Year,
                        LancamentosRealizados = new List<Lancamento>()
                    };
                }

                consolidadosAnuais[chaveAnual].LancamentosRealizados.Add(lancamento);
            }

            var consolidados = new List<SaldoConsolidado>();
            consolidados.AddRange(consolidadosDiarios.Values);
            consolidados.AddRange(consolidadosMensais.Values);
            consolidados.AddRange(consolidadosAnuais.Values);

            foreach (var saldoConsolidado in consolidados)
            {
                var saldoInicial = GetSaldoInicial(lancamentos, saldoConsolidado.Data, saldoConsolidado.Mes, saldoConsolidado.Ano);
                saldoConsolidado.SaldoInicial = saldoInicial;

                saldoConsolidado.Saldo = saldoConsolidado.SaldoInicial + saldoConsolidado.LancamentosRealizados
                    .Sum(l => l.Tipo == TipoLancamento.Debito ? -l.Valor : l.Valor);
            }

            return consolidados;
        }

        private decimal GetSaldoInicial(IEnumerable<Lancamento> lancamentos, DateTime data, int mes, int ano)
        {
            var saldoInicial = lancamentos
                .Where(l => l.Data < data && l.Data.Year == ano && l.Data.Month == mes)
                .Sum(lancamento => lancamento.Tipo == TipoLancamento.Debito ? -lancamento.Valor : lancamento.Valor);
            return saldoInicial;
        }
    }
}
