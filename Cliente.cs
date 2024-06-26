﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal class Cliente
    {
        private string nombre;
        private string apellido;
        private string tipoAbastecimiento;
        private string cantidadAbastecer;

        private string bombaSeleccionada;

        private DateTime fecha;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string TipoAbastecimiento { get => tipoAbastecimiento; set => tipoAbastecimiento = value; }
        public string CantidadAbastecer { get => cantidadAbastecer; set => cantidadAbastecer = value; }
        public string BombaSeleccionada { get => bombaSeleccionada; set => bombaSeleccionada = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        /*
        public int CantidadRestante { get; set; }

        public bool TimerActivo { get; set; }
        */
        public string CantidadFaltante { get; set; }
        public int CantidadRestante { get; set; }

    }
}
