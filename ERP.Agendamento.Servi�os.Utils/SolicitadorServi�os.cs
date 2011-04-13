using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Agendamento.Serviços.Utils
{
    public class SolicitadorServiços
    {
        public static RH_Services.RH_Servico servicoRH = new RH_Services.RH_Servico();


        #region Acesso aos serviços do agendamento (Para testes)

        //public static PacienteSet AccessAgendamento_Paciente(int id)
        //{
        //    return client.Agendamento_Paciente(id);
        //}

        #endregion



        #region Acesso aos serviços do RH

        public static List<string> AccessRH_MedicoEspecialidade(int cod_especialidade, DateTime data_inicio, DateTime data_fim)
        {
            return null;
        }

        public static List<KeyValuePair<int, string>> AccessRH_Especialidade()
        {
            List<KeyValuePair<int, string>> returnList = new List<KeyValuePair<int, string>>();
            foreach (DataTable table in servicoRH.listEspecialidade().Tables)
            {
                foreach(DataRow row in table.Rows)
                {
                    returnList.Add(new KeyValuePair<int, string>(Convert.ToInt32(row["ID"]), row["Nome"].ToString()));
                }
            }
            return returnList;
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
