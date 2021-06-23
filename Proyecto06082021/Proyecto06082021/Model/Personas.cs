﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Proyecto06082021.Model
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(250)]
        public String nombres { get; set; }

        [MaxLength(250)]
        public String apellidos { get; set; }
        public int edad { get; set; }

        [MaxLength(100), Unique]
        public String correo { get; set; }

        [MaxLength(300)]
        public String direccion { get; set; }

        [MaxLength(300)]
        public String FechaNacimiento { get; set; }
    }
}
