using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Agendamento.Models
{
    public class GerenciadorRelatórios
    {

        //Agenda médica falta mudar item do dictionary para list
        public class AgendaMédica
        {
            private List<AgendamentoSet> agendamentos;
            private Dictionary<int, List<AgendamentoSet>> agendamentoMes;

            public AgendaMédica(int medico_id, int meses)
            {
                this.agendamentos = GerenciadorBanco.GetAgendamentosByMedico(medico_id);
                this.agendamentos = (from agendamento in agendamentos where agendamento.Datahora >= DateTime.Today && agendamento.Datahora < DateTime.Today.AddMonths(meses) select agendamento).ToList();

                this.agendamentoMes = new Dictionary<int, List<AgendamentoSet>>();
                foreach (AgendamentoSet agendamento in agendamentos)
                {
                    if (agendamentoMes.ContainsKey(agendamento.Datahora.Month))
                    {
                        agendamentoMes[agendamento.Datahora.Month].Add(agendamento);
                    }
                    else
                    {
                        agendamentoMes[agendamento.Datahora.Month] = new List<AgendamentoSet>();
                        agendamentoMes[agendamento.Datahora.Month].Add(agendamento);
                    }
                }
            }

            public Dictionary<int, List<AgendamentoSet>> Agenda
            {
                get
                {
                    return this.agendamentoMes;
                }
            }
        }

        public class AgendamentosSetores
        {
            private Dictionary<string, float> porcentagemAgendamentos;

            public AgendamentosSetores()
            {
                porcentagemAgendamentos = new Dictionary<string, float>();
                float agendamentosTotais = 0;

                foreach (AgendamentoSet agendamento in GerenciadorBanco.GetAllAgendamentos())
                {
                    if (porcentagemAgendamentos.ContainsKey(agendamento.Especialidade))
                    {
                        porcentagemAgendamentos[agendamento.Especialidade] = porcentagemAgendamentos[agendamento.Especialidade] + 1;
                    }
                    else
                    {
                        porcentagemAgendamentos.Add(agendamento.Especialidade, 1);
                    }
                    agendamentosTotais++;
                }
            }

            public Dictionary<string, float> AgendamentosSetor
            {
                get
                {
                    return porcentagemAgendamentos;
                }
            }
        }

        public class AgendamentosEstatísticas
        {
            private float porcentagemCancelados;
            private Dictionary<int, int> agendamentosMes;

            public AgendamentosEstatísticas()
            {
                agendamentosMes = new Dictionary<int, int>();
                float agendamentosCancelados = 0;
                float agendamentosTotais = 0;

                foreach (AgendamentoSet agendamento in GerenciadorBanco.GetAllAgendamentos())
                {
                    agendamentosTotais++;
                    if (agendamento.Estado == "cancelado")
                    {
                        agendamentosCancelados++;
                    }

                    if (agendamentosMes.ContainsKey(agendamento.Datahora.Month))
                    {
                        agendamentosMes[agendamento.Datahora.Month] = agendamentosMes[agendamento.Datahora.Month] + 1;
                    }
                    else
                    {
                        agendamentosMes.Add(agendamento.Datahora.Month, 1);
                    }
                }

                this.porcentagemCancelados = agendamentosCancelados / agendamentosTotais;
            }

            public Dictionary<int, int> AgendamentosMes
            {
                get
                {
                    return this.agendamentosMes;
                }
            }

            public float PorcentagemCancelados
            {
                get
                {
                    return this.porcentagemCancelados;
                }
            }
        }

    }
}
