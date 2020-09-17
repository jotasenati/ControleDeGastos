using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleDeGastos.Models
{
    public class ControleGastoContext: DbContext
    {

        public ControleGastoContext() : base("Controle de Gastos") { }
        public DbSet<ControleGastos> ControleGastos { get; set; }

    }
}