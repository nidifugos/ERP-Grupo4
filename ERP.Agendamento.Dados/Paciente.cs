using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ERP.Agendamento.Dados
{
    [Serializable()]
    public class Paciente : ISerializable
    {
        public string nome;
        public string rg;
        public string cpf;
        public DateTime data_nascimento;
        public int peso;
        public int altura;
        public string tipo_sanguineo;
        public string afiliacao_pai;
        public string afiliacao_mae;
        public string endereco_residencial;
        public string telefone_residencial;
        public string endereco_comercial;
        public string telefone_comercial;
        public string telefone_celular;
        public int convenio;

        public Paciente()
        {
            this.nome = "";
            this.rg = "";
            this.cpf = "";
            this.data_nascimento = DateTime.Now;
            this.peso = 0;
            this.altura = 0;
            this.tipo_sanguineo = "";
            this.afiliacao_pai = "";
            this.afiliacao_mae = "";
            this.endereco_residencial = "";
            this.telefone_residencial = "";
            this.endereco_comercial = "";
            this.telefone_comercial = "";
            this.telefone_celular = "";
            this.convenio = 0;
        }

        public Paciente(PacienteSet paciente)
        {
            this.nome = paciente.Nome;
            this.rg = paciente.Rg;
            this.cpf = paciente.Cpf;
            this.data_nascimento = paciente.DataNascimento;
            this.peso = paciente.Peso;
            this.altura = paciente.Altura;
            this.tipo_sanguineo = paciente.TipoSanguineo;
            this.afiliacao_pai = paciente.AfiliacaoPai;
            this.afiliacao_mae = paciente.AfiliacaoMae;
            this.endereco_residencial = paciente.EnderecoResidencial;
            this.telefone_residencial = paciente.TelefoneResidencial;
            this.endereco_comercial = paciente.EnderecoComercial;
            this.telefone_comercial = paciente.TelefoneComercial;
            this.telefone_celular = paciente.TelefoneCelular;
            this.convenio = (int) paciente.Convenio;
        }

        public Paciente(SerializationInfo info, StreamingContext ctxt)
        {
            this.nome = (string)info.GetValue("Nome", typeof(string));
            this.rg = (string)info.GetValue("RG", typeof(string));
            this.cpf = (string)info.GetValue("CPF", typeof(string));
            this.data_nascimento = (DateTime)info.GetValue("DataNascimento", typeof(DateTime));
            this.peso = (int)info.GetValue("Peso", typeof(int));
            this.altura = (int)info.GetValue("Altura", typeof(int));
            this.tipo_sanguineo = (string)info.GetValue("TipoSanguineo", typeof(string));
            this.afiliacao_pai = (string)info.GetValue("AfiliacaoPai", typeof(string));
            this.afiliacao_mae = (string)info.GetValue("AfiliacaoMae", typeof(string));
            this.endereco_residencial = (string)info.GetValue("EnderecoResidencial", typeof(string));
            this.telefone_residencial = (string)info.GetValue("TelefoneResidencial", typeof(string));
            this.endereco_comercial = (string)info.GetValue("EnderecoComercial", typeof(string));
            this.telefone_comercial = (string)info.GetValue("TelefoneComercial", typeof(string));
            this.telefone_celular = (string)info.GetValue("TelefoneCelular", typeof(string));
            this.convenio = (int)info.GetValue("Convenio", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Nome", nome);
            info.AddValue("RG", rg);
            info.AddValue("DataNascimento", data_nascimento);
            info.AddValue("Peso", peso);
            info.AddValue("Altura", altura);
            info.AddValue("TipoSanguineo", tipo_sanguineo);
            info.AddValue("AfiliacaoPai", afiliacao_pai);
            info.AddValue("AfiliacaoMae", afiliacao_mae);
            info.AddValue("EnderecoResidencial", endereco_residencial);
            info.AddValue("TelefoneResidencial", telefone_residencial);
            info.AddValue("EnderecoComercial", endereco_comercial);
            info.AddValue("TelefoneComercial", telefone_comercial);
            info.AddValue("TelefoneCelular", telefone_celular);
            info.AddValue("Convenio", convenio);
        }
    }
}
