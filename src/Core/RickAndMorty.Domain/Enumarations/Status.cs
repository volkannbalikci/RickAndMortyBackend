using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Enumarations;

public class Status : Enumeration
{
    public static Status Alive = new(1, nameof(Alive));
    public static Status Dead = new(2, nameof(Dead));
    public static Status Unknown = new(3, nameof(Unknown));
    public Status(int id, string name) : base(id, name)
    {

    }
}
