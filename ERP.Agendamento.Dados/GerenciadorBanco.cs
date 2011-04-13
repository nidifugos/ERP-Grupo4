using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Agendamento.Dados
{
    public class GerenciadorBanco
    {
        static erp_agendamentoEntities entities = new erp_agendamentoEntities();

        public static PacienteSet GetPacienteById(int id)
        {
            List<PacienteSet> listaPaciente = entities.PacienteSets.ToList();
            return (from paciente in entities.PacienteSets.ToList() where paciente.Id == id select paciente).First();
        }

        public static List<AgendamentoSet> GetAgendamentosByMedico(int medico_id)
        {
            return (from agendamento in entities.AgendamentoSets.ToList() where agendamento.Medico_Id == medico_id select agendamento).ToList();
        }

        public static List<AgendamentoSet> GetAllAgendamentos()
        {
            return entities.AgendamentoSets.ToList();
        }

        public static List<PacienteSet> GetAllPacientes()
        {
            return entities.PacienteSets.ToList();
        }

        public static void AddManutencao(DateTime dataInicio, DateTime dataFim, int salaId)
        {
            //criacao de manutencao
            ManutencaoSet manutencao = new ManutencaoSet();
            manutencao.Data_Inicio = dataInicio;
            manutencao.Data_Fim = dataFim;
            manutencao.Sala_Id = salaId;
            entities.AddToManutencaoSets(manutencao);


            //alterando status dos agendamentos atuais
            foreach (AgendamentoSet agendamento in (from agendamentos in entities.AgendamentoSets where agendamentos.Datahora >= manutencao.Data_Inicio && agendamentos.Datahora <= manutencao.Data_Fim && agendamentos.Sala_Id == manutencao.Sala_Id select agendamentos).ToList())
            {
                agendamento.Estado = "remarcar";
            }

            entities.SaveChanges();
        }

        public static void AddFerias(DateTime dataInicio, DateTime dataFim, int medicoId)
        {
            //alterando status dos agendamentos atuais
            foreach (AgendamentoSet agendamento in (from agendamentos in entities.AgendamentoSets 
                                                    where agendamentos.Datahora >= dataInicio && agendamentos.Datahora <= dataFim && agendamentos.Medico_Id == medicoId 
                                                    select agendamentos).ToList())
            {
                agendamento.Estado = "remarcar";
            }

            entities.SaveChanges();
        }
    }
}
