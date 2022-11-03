﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Information
{
    public class ThreadInformation
    {
        public int Id { get; }

        public long ElapsedTime { get; private set; }

        public List<MethodInformation> Methods { get; } = new List<MethodInformation>();

        public ThreadInformation() {}
        public ThreadInformation(int id)
        {
            Id = id;
        }
    }
}
