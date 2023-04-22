﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MV2AudioRecorder.Models
{
    public class AudioModel
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public DateTime Date { get; set; }
    }
}
