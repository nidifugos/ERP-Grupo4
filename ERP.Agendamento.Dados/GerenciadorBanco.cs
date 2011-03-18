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
    }
}
