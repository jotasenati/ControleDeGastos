using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleDeGastos.Models
{
    public class ControleGastos
    {
        [Key()]
        public int CodGasto { get; set; }

        public string TipoGasto {get;set;}

        public string Descricao { get; set; }
        public int Valor { get; set; }
        public Nullable<DateTime> DataCadastro { get; set; }
        public Nullable<DateTime> DataAlteracao { get; set; }
        public Nullable<DateTime> DataExcluido { get; set; }
    }
}