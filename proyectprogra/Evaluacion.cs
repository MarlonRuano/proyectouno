﻿using System;

namespace ProyectoProgra.Models
{
    public class Evaluacion
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int CursoID { get; set; }
    }
}

