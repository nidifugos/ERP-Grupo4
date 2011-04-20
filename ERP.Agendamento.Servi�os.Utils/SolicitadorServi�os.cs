using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Agendamento.Serviços.Utils
{
    public class SolicitadorServiços
    {
        private static Administracao_Services.AdministracaoWS servicoAdministracao = new Administracao_Services.AdministracaoWS();
        private static RH_Services.RH_Servico servicoRH = new RH_Services.RH_Servico();
        private static Manutencao_Services.WebService1 servicoManutencao = new Manutencao_Services.WebService1();
        private static Logistica_Services.EspacoFisicoWS servicoLogistica = new Logistica_Services.EspacoFisicoWS();


        #region Acesso aos serviços do agendamento (Para testes)

        //public static PacienteSet AccessAgendamento_Paciente(int id)
        //{
        //    return client.Agendamento_Paciente(id);
        //}

        #endregion


        #region Acesso aos serviços do RH

        public static List<KeyValuePair<int, string>> AccessRH_MedicoEspecialidade(int cod_especialidade, DateTime data)
        {
            List<KeyValuePair<int, string>> returnList = new List<KeyValuePair<int, string>>();
            foreach (DataTable table in servicoRH.RH_MedicoEspecialidade(cod_especialidade, data).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    returnList.Add(new KeyValuePair<int, string>(Convert.ToInt32(row["ID"]), row["Nome"].ToString()));
                }
            }
            return returnList;           
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

        public static List<string> AccessAdministracao_PlanoSaude()
        {
            servicoAdministracao.ListaConvenios();
            return null;
        }

        #endregion


        #region Acesso aos serviços da manutenção

        public static void AccessManutencao_DatasManutencao()
        {
            //servicoManutencao.obterDatasManutencao();
        }

        #endregion


        #region Acesso aos serviços da logistica

        public static void AccessLogistica_EspacoFisico()
        {
            //servicoLogistica.obterEspacoFisico();
        }

        #endregion


        #region Acesso aos serviços do financeiro

        //public static int AccessFinanceiro_SolicitarPagamento()
        //{
        //    return client.Financeiro_SolicitarPagamento();
        //}

        #endregion
    }
}
