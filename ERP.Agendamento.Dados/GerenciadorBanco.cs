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
    }
}
