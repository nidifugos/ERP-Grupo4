using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ERP.Agendamento.Dados;

namespace ERP.Agendamento.Servicos
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://labsoft.pcs.usp.br:3004/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FornecedorServicos : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Agendamento.Dados.Agendamento> AgendamentosByMedicos(int id)
        {
            List<Agendamento.Dados.Agendamento> listaAgendamentos = new List<Dados.Agendamento>();
            foreach (AgendamentoSet agendamento in GerenciadorBanco.GetAgendamentosByMedico(id))
            {
                listaAgendamentos.Add(new Dados.Agendamento(agendamento.Medico_Id, agendamento.Medico_Nome , agendamento.Paciente_Id, agendamento.PacienteSet.Nome, agendamento.Datahora));
            }
            return listaAgendamentos;
        }

        [WebMethod]
        public Agendamento.Dados.Paciente PacienteById(int id)
        {
            Agendamento.Dados.Paciente paciente = new Paciente(GerenciadorBanco.GetPacienteById(id));
            return paciente;
        }

        [WebMethod]
        public void NotificarManutencao(DateTime dataInicio, DateTime dataFim, int salaId)
        {
            GerenciadorBanco.AddManutencao(dataInicio, dataFim, salaId);
        }

        [WebMethod]
        public void NotificarFerias(DateTime dataInicio, DateTime dataFim, int medicoId)
        {
            GerenciadorBanco.AddFerias(dataInicio, dataFim, medicoId);
        }
    }
}