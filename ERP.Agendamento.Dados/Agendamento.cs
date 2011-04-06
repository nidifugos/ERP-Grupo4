using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ERP.Agendamento.Dados
{
    [Serializable()]
    public class Agendamento : ISerializable
    {

        public int medico_id;
        public string medico_nome;
        public int paciente_id;
        public string paciente_nome;
        public DateTime dataAtendimento;

        public Agendamento()
        {
            this.medico_id = 0;
            this.medico_nome = "";
            this.paciente_id = 0;
            this.paciente_nome = "";
            this.dataAtendimento = DateTime.Now;
        }

        public Agendamento(SerializationInfo info, StreamingContext ctxt)
        {
            medico_id = (int)info.GetValue("MedicoId", typeof(int));
            medico_nome = (string)info.GetValue("MedicoNome", typeof(string));
            paciente_id = (int)info.GetValue("PacienteId", typeof(int));
            paciente_nome = (string)info.GetValue("PacienteNome", typeof(string));
            dataAtendimento = (DateTime)info.GetValue("DataAtendimento", typeof(DateTime));
        }

        public Agendamento(int medico_id, string medico_nome, int paciente_id, string paciente_nome, DateTime dataAtendimento)
        {
            this.medico_id = medico_id;
            this.medico_nome = medico_nome;
            this.paciente_id = paciente_id;
            this.paciente_nome = paciente_nome;
            this.dataAtendimento = dataAtendimento;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("MedicoId", medico_id);
            info.AddValue("MedicoNome", medico_nome);
            info.AddValue("PacienteId", paciente_id);
            info.AddValue("PacienteNome", paciente_nome);
            info.AddValue("DataAtendimento", dataAtendimento);
        }
    }
}
