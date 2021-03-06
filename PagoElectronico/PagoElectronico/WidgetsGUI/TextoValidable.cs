﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.WidgetsGUI
{
    public partial class TextoValidable : Texto, Validable
    {
        public TextoValidable()
        {
            InitializeComponent();
        }

        public bool esValido()
        {
            return Text != "";
        }

        public String obtenerMensajeDeError()
        {
            return "El campo " + Name + " no puede estar vacío";
        }
    }
}
