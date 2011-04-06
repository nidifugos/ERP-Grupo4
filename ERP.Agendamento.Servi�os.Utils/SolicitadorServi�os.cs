using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Agendamento.Serviços.Utils
{
    class SolicitadorServiços
    {

        #region Acesso aos serviços do agendamento (Para testes)

        //public static PacienteSet AccessAgendamento_Paciente(int id)
        //{
        //    return client.Agendamento_Paciente(id);
        //}

        #endregion



        #region Acesso aos serviços do RH

        public static List<string> AccessRH_MedicoEspecialidade(int cod_especialidade)
        {
            return null;
        }

        public static List<string> AccessRH_Especialidade()
        {
            RH_Servicos.RH_Servico service = new RH_Servicos.RH_Servico();
            var a = service.listEspecialidade();
            a = null;
            return null;
        }

        #endregion



        #region Acesso aos serviços da administração

        //public static List<string> AccessAdministracao_PlanoSaude()
        //{
        //    return new List<string>(client.Administracao_PlanoSaude());
        //}

        #endregion



        #region Acesso aos serviços do financeiro

        //public static int AccessFinanceiro_SolicitarPagamento()
        //{
        //    return client.Financeiro_SolicitarPagamento();
        //}

        #endregion
    }
}
